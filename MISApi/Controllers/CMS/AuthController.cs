using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using MISApi.Tools;
using System;
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
        public IActionResult GetToken(DTO_AccountNameAndAccountPwd dto)
        {
            var member = new MemberService.RowService().Verify(dto.AccountName, dto.AccountPwd);
            if (member != null)
            {
                // 更新登录时间
                member.LoginDateTime = DateTime.Now;
                new MemberService.UpdateService().Execute(member);
                // 获取Token
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
                    }),
                    Expires = expiresAt,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                return new JsonResult(new DTO_Result
                {
                    Result = true,
                    Token = token,
                    MemberInfo = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName }
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    message = "Authentication Failure"
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

            return new JsonResult(new DTO_Result { Result = true, Token = dto.Token, MemberInfo = new DTO_Member { MemberId = claim.Id, MemberName = claim.Name, RealName = claim.RealName } });
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
            // 发送验证码
            string code = SMSHelper.AuthCode(dto.Mobile);
            // 存Redis
            RedisHelper.SetValue(dto.Mobile, new SMSHelper.Entity { Mobile = dto.Mobile, Code = code, SMSDate = DateTime.Now});
            // 返回
            return new JsonResult(new DTO_Auth { Mobile = dto.Mobile, Code = code, Result = true });
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
            return new JsonResult(new DTO_Auth
            {
                Mobile = dto.Mobile,
                Code = dto.Code,
                Result = smsEntity.Mobile == dto.Mobile && smsEntity.Code == dto.Code
            });
        }
        #endregion

    }
}