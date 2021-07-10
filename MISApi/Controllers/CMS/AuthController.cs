using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using MISApi.Tools;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MISApi.Tools.AuthHelper;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 验证
    /// </summary>
    public class AuthController : BaseController<Member>
    {
        #region IActionResult
        /// <summary>
        /// 验证获取会员Token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetToken", Name = "MIS_CMS_Auth_GetToken")]
        [HttpPost]
        public IActionResult GetToken(DTO_Login dto)
        {
            var member = new MemberService.RowService().Verify(dto.Name, dto.Password);
            if (member != null)
            {
                var token = GetToken(member);
                return new JsonResult(new DTO_Result_Member
                {
                    Result = true,
                    Token = token,
                    Member = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName, AvatarUrl = member.AvatarUrl }
                });
            }
            else
            {
                return new JsonResult(new DTO_Result_Member
                {
                    Result = false,
                    Token = "",
                    Member = null,
                    Message = "Authentication Failure"
                });
            }
        }
        /// <summary>
        /// 根据Token获取会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetEntity", Name = "MIS_CMS_Auth_GetEntity")]
        [HttpPost]
        public IActionResult GetAuthEntity([FromBody] DTO_Token dto)
        {
            ClaimEntity claim = GetClaimFromToken(dto.Token);

            return new JsonResult(new DTO_Result_Member { Result = true, Token = dto.Token, Member = new DTO_Member { MemberId = claim.Id, MemberName = claim.Name, RealName = claim.RealName, AvatarUrl = claim.NickName } });
        }
        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetAuthCode", Name = "MIS_CMS_Auth_GetAuthCode")]
        [HttpPost]
        public IActionResult GetAuthCode([FromBody] DTO_Auth dto)
        {
            // 判断是否已有手机号
            SMSHelper.Entity smsEntity = RedisHelper.GetValue<SMSHelper.Entity>(dto.Mobile);
            // 判断短信发送时间间隔
            if(smsEntity != null &&  smsEntity.SMSDate.AddMinutes(1) >= DateTime.Now)
            {
                return new JsonResult(new DTO_Result_Auth { Mobile = dto.Mobile, Result = false, Message = "发送间隔小于一分钟，发送失败。" });
            }
            // 发送验证码
            string code = SMSHelper.AuthCode(dto.Mobile);
            // 存Redis
            RedisHelper.SetValue(dto.Mobile, new SMSHelper.Entity { Mobile = dto.Mobile, Code = code, SMSDate = DateTime.Now });
            // 返回
            return new JsonResult(new DTO_Result_Auth { Mobile = dto.Mobile, Result = true });
        }
        /// <summary>
        /// 校验短信验证码
        /// </summary> 
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetAuth", Name = "MIS_CMS_Auth_GetAuth")]
        [HttpPost]
        public IActionResult GetAuth([FromBody] DTO_Auth dto)
        {
            SMSHelper.Entity smsEntity = RedisHelper.GetValue<SMSHelper.Entity>(dto.Mobile);
            // 返回
            return new JsonResult(new DTO_Result_Auth
            {
                Mobile = dto.Mobile,
                Result = smsEntity.Mobile == dto.Mobile && smsEntity.Code == dto.Code
            });
        }
        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Regist", Name = "MIS_CMS_Auth_Regist")]
        [HttpPost]
        public IActionResult MIS_CMS_Auth_Regist(DTO_Auth dto)
        {
            try
            {
                // 验证短信
                SMSHelper.Entity smsEntity = RedisHelper.GetValue<SMSHelper.Entity>(dto.Mobile);
                // 验证码校验
                if(smsEntity.Mobile == dto.Mobile && smsEntity.Code == dto.Code)
                {
                    // Entity
                    if (dto.Member != null)
                    {
                        dto.Member.Password = EncryptHelper.GetBase64String(dto.Member.Password);
                        dto.Member.RegistDateTime = DateTime.Now;
                        if (string.IsNullOrEmpty(dto.Member.Name))
                        {
                            dto.Member.Name = RandHelper.GenerateRandomAlphabet(12);
                        }
                    }
                    var existMember = new MemberService.RowService().ByMobile(dto.Member.Mobile);
                    if (existMember == null)
                    {
                        var member = new MemberService.CreateService().Regist(dto.Member);
                        // 返回
                        return new JsonResult(new DTO_Result_Member
                        {
                            Result = true,
                            Member = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName }
                        });
                    }
                    else
                    {
                        return new JsonResult(new DTO_Result_Member
                        {
                            Result = false,
                            Member = new DTO_Member { MemberId = existMember.Id, MemberName = existMember.Name, RealName = existMember.RealName, AvatarUrl = existMember.AvatarUrl },
                            Message = "手机号已被注册。"
                        });
                    }
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "验证码错误。"
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result_Member
                {
                    Result = false,
                    Message = ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Forget", Name = "MIS_CMS_Auth_Forget")]
        [HttpPost]
        public IActionResult MIS_CMS_Auth_Forget(DTO_Auth dto)
        {
            try
            {
                // 验证短信
                SMSHelper.Entity smsEntity = RedisHelper.GetValue<SMSHelper.Entity>(dto.Mobile);
                // 验证码校验
                if (smsEntity.Mobile == dto.Mobile && smsEntity.Code == dto.Code)
                {
                    var member = new Member();
                    // Entity
                    if (dto.Member != null)
                    {
                        member = new MemberService.RowService().ByMobile(dto.Member.Mobile);
                        member.Password = EncryptHelper.GetBase64String(dto.Member.Password);
                    }
                    // 提交
                    member = new MemberService.UpdateService().Execute(member);
                    // 返回
                    return new JsonResult(new DTO_Result_Member
                    {
                        Result = true,
                        Member = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName, AvatarUrl = member.AvatarUrl }
                    });
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "验证码错误。"
                    });
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// 验证发卡是否有效
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/VerifyCard", Name = "MIS_CMS_Auth_VerifyCard")]
        [HttpPost]
        public IActionResult VerifyCard(DTO_Card dto)
        {
            var card = new CardService.RowService().Verify(dto.CardNo, dto.CardPassword);
            if (card != null)
            {
                return new JsonResult(new DTO_Result_Card
                {
                    Result = true,
                    Card = new DTO_Card{ CardNo = card.CardNo, CardPassword = card.CardPassword},
                    Message = "发现未激活的卡号，验证有效！"
                });
            }
            else
            {
                return new JsonResult(new DTO_Result_Member
                {
                    Result = false,
                    Token = "",
                    Member = null,
                    Message = "未找到有效卡号！"
                });
            }
        }
        /// <summary>
        /// 激活卡号绑定会员账户，现有会员绑定现有会员，未发现现有会员注册新会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/ActivateCard", Name = "MIS_CMS_Auth_ActivateCard")]
        [HttpPost]
        public IActionResult ActivateCard(DTO_ActivateCard dto)
        {
            var card = new CardService.RowService().Verify(dto.CardNo, dto.CardPassword);
            var member = new MemberService.RowService().Verify(dto.MemberName, dto.MemberPassword);
            if (card != null && member != null)
            {
                string token = GetToken(member);
                new CardService.UpdateService().Activate(card.Id, member.Id);
                return new JsonResult(new DTO_Result_Member
                {
                    Result = true,
                    Token = token,
                    Member = new DTO_Member { MemberId=member.Id, MemberName=member.Name, AvatarUrl=member.AvatarUrl, Mobile=member.Mobile, RealName=member.RealName},
                    Message = "激活成功，已绑定老会员！"
                });
            }
            else if(card != null && member == null)
            {
                dto.MemberPassword = EncryptHelper.GetBase64String(dto.MemberPassword);
                var result = new MemberService.CreateService().ToStatus(
                    new Member { Name = dto.MemberName, Password = dto.MemberPassword, CreateDateTime = DateTime.Now, EditDateTime = DateTime.Now },
                    "cms.member.open"
                );
                string token = GetToken(new Member() { Id = result.Id, Name = result.Name, AvatarUrl = ""});
                new CardService.UpdateService().Activate(card.Id, result.Id);
                return new JsonResult(new DTO_Result_Member
                {
                    Result = false,
                    Token = token,
                    Member = new DTO_Member { MemberId = result.Id, MemberName = result.Name, AvatarUrl = result.AvatarUrl, Mobile = result.Mobile, RealName = result.RealName },
                    Message = "激活成功，并创建了会员！"
                });
            }
            else
            {
                return new JsonResult(new DTO_Result_Member
                {
                    Result = false,
                    Token = "",
                    Member = null,
                    Message = "激活失败，未发现有效卡号或未绑定有效会员！"
                });
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private string GetToken(Member member)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("This is ocelot security key");
                var authTime = DateTime.Now;
                var expiresAt = authTime.AddDays(1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtClaimTypes.Audience, "api"),
                        new Claim(JwtClaimTypes.Issuer, "http://localhost:44319"),
                        new Claim(JwtClaimTypes.Id, member.Id.ToString()),
                        new Claim(JwtClaimTypes.Name,member.Name),
                        new Claim(JwtClaimTypes.NickName,member.AvatarUrl),
                    }),
                    Expires = expiresAt,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.GetToken", ex);
            }
        }
        #endregion

        #region HttpEntities
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Result_Member : DTO_Result
        {
            /// <summary>
            /// Token
            /// </summary>
            [Description("Token")]
            [JsonProperty("token")]
            [DefaultValue("")]
            public string Token { get; set; } = "";
            /// <summary>
            /// 会员
            /// </summary>
            [Description("会员")]
            [JsonProperty("member")]
            public DTO_Member Member { get; set; } = new DTO_Member();
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Member
        {
            /// <summary>
            /// 会员Id
            /// </summary>
            [Description("会员Id")]
            [JsonProperty("memberId")]
            [DefaultValue(-1)]
            public int MemberId { get; set; } = -1;
            /// <summary>
            /// 会员名
            /// </summary>
            [Description("会员名")]
            [JsonProperty("memberName")]
            [DefaultValue("")]
            public string MemberName { get; set; } = "";
            /// <summary>
            /// 实名
            /// </summary>
            [Description("实名")]
            [JsonProperty("realName")]
            [DefaultValue("")]
            public string RealName { get; set; } = "";
            /// <summary>
            /// 头像路径
            /// </summary>
            [Description("头像路径")]
            [JsonProperty("avatarUrl")]
            [DefaultValue("")]
            public string AvatarUrl { get; set; } = "";
            /// <summary>
            /// 手机
            /// </summary>
            [Description("手机")]
            [JsonProperty("mobile")]
            [DefaultValue("")]
            public string Mobile { get; set; } = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Auth
        {
            /// <summary>
            /// 手机号
            /// </summary>
            [Description("手机号")]
            [JsonProperty("mobile")]
            [DefaultValue("")]
            public string Mobile { get; set; } = "";
            /// <summary>
            /// 验证码
            /// </summary>
            [Description("验证码")]
            [JsonProperty("code")]
            [DefaultValue("")]
            public string Code { get; set; } = "";
            /// <summary>
            /// 验证码类型
            /// </summary>
            [Description("验证码类型")]
            [JsonProperty("type")]
            [DefaultValue("")]
            public string Type { get; set; } = "";
            /// <summary>
            /// 会员
            /// </summary>
            [Description("会员")]
            [JsonProperty("member")]
            public Member Member { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class DTO_Result_Card : DTO_Result
        {
            /// <summary>
            /// 卡
            /// </summary>
            [Description("卡")]
            [JsonProperty("card")]
            public DTO_Card Card { get; set; } = new DTO_Card();
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Card
        {
            /// <summary>
            /// 卡号
            /// </summary>
            [Description("卡号")]
            [JsonProperty("cardNo")]
            [DefaultValue("")]
            public string CardNo { get; set; } = "";
            /// <summary>
            /// 卡密
            /// </summary>
            [Description("卡密")]
            [JsonProperty("cardPassword")]
            [DefaultValue("")]
            public string CardPassword { get; set; } = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_ActivateCard
        {
            /// <summary>
            /// 卡号
            /// </summary>
            [Description("卡号")]
            [JsonProperty("cardNo")]
            [DefaultValue("")]
            public string CardNo { get; set; } = "";
            /// <summary>
            /// 卡密
            /// </summary>
            [Description("卡密")]
            [JsonProperty("cardPassword")]
            [DefaultValue("")]
            public string CardPassword { get; set; } = "";
            /// <summary>
            /// 会员名
            /// </summary>
            [Description("会员名")]
            [JsonProperty("memberName")]
            [DefaultValue("")]
            public string MemberName { get; set; } = "";
            /// <summary>
            /// 会员密码
            /// </summary>
            [Description("会员密码")]
            [JsonProperty("memberPassword")]
            [DefaultValue("")]
            public string MemberPassword { get; set; } = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Result_Auth : DTO_Result
        {
            /// <summary>
            /// 手机号
            /// </summary>
            [Description("手机号")]
            [JsonProperty("mobile")]
            [DefaultValue("")]
            public string Mobile { get; set; } = "";
        }

        #endregion

    }
}