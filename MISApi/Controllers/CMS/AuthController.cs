using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MISApi.Controllers.CMS.AuthController.HttpEntity;
using static MISApi.Tools.AuthHelper;
using MISApi.Tools;
using MISApi.HttpClients;
using System.Collections.Generic;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 验证
    /// </summary>
    public class AuthController : BaseController<User>
    {
        #region IActionResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetToken", Name = "MIS_CMS_Auth_Get_Token")]
        [HttpPost]
        public IActionResult GetToken(DTO_AccountNameAndAccountPwd dto)
        {
            var user = new UserService.RowService().Verify(dto.AccountName, dto.AccountPwd);
            if (user != null)
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
                        new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                        new Claim(JwtClaimTypes.Name,user.Name),
                    }),
                    Expires = expiresAt,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                return new JsonResult(new DTO_Result
                {
                    Result = true,
                    Token = token,
                    UserInfo = new DTO_User { UserId = user.Id, UserName = user.Name, RealName = user.RealName }
                });

            }
            else
            {
                return new JsonResult(new
                {
                    Result = false,
                    Message = "Authentication Failure"
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetEntity", Name = "MIS_CMS_Auth_Get_Entity")]
        [HttpPost]
        public IActionResult GetAuthEntity([FromBody] DTO_Token dto)
        {
            ClaimEntity claim = GetClaimFromToken(dto.Token);

            return new JsonResult(new DTO_Result { Result = true, Token = dto.Token, UserInfo = new DTO_User { UserId = claim.UserId, UserName = claim.UserName, RealName = claim.RealName } });
        }
        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetAuthCode", Name = "MIS_CMS_Auth_Get_AuthCode")]
        [HttpPost]
        public IActionResult GetAuthCode([FromBody] DTO_Auth dto)
        {
            var account = "manyun106vgx2";
            var timestamps = Convert.ToInt64((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds).ToString();
            var mobile = dto.Mobile;
            // 接口密码(msvZrIhi) + 手机号 + 时间戳 MD5加密
            var password = EncryptHelper.GetMD5($"msvZrIhi{dto.Mobile}{timestamps}");
            var code = RandHelper.GenerateRandomNumber(6);
            var content = $"您的验证码是：{code}，有效时间10分钟。";
            // 调用短信API
            HttpClientHelper.HttpGetResponse(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("account", account),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("mobile", mobile),
                    new KeyValuePair<string, string>("content", content),
                    new KeyValuePair<string, string>("timestamps", timestamps),
                    new KeyValuePair<string, string>("extNumber", ""),
                    new KeyValuePair<string, string>("extInfo", "")
                },
                "http://sapi.appsms.cn:8088/msgHttp/json/mt"
            );
            // 存Redis
            RedisHelper.SetStringValue(dto.Mobile, $"{dto.Mobile}^{code}");
            // 返回
            return new JsonResult(new DTO_Auth { Mobile = dto.Mobile, Code = code, Result = true });
        }
        /// <summary>
        /// 校验短信验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/GetAuth", Name = "MIS_CMS_Auth_Get_Auth")]
        [HttpPost]
        public IActionResult GetAuth([FromBody] DTO_Auth dto)
        {
            return new JsonResult(new DTO_Auth { 
                Mobile = dto.Mobile, 
                Code = dto.Code, 
                Result = RedisHelper.GetStringValue(dto.Mobile).Equals($"{dto.Mobile}^{dto.Code}")
            });

        }
        #endregion

        #region HttpEntity

        /// <summary>
        /// 
        /// </summary>
        public class HttpEntity
        {
            #region DTO
            /// <summary>
            /// 
            /// </summary>
            public class DTO_AccountNameAndAccountPwd
            {
                /// <summary>
                /// 账户名
                /// </summary>
                [Description("账户名")]
                [JsonProperty("accountName")]
                public string AccountName { get; set; } = "";
                /// <summary>
                /// 账户密码
                /// </summary>
                [Description("账户密码")]
                [JsonProperty("accountPwd")]
                public string AccountPwd { get; set; } = "";
            }
            /// <summary>
            /// 
            /// </summary>
            public class DTO_Token
            {
                /// <summary>
                /// Token
                /// </summary>
                [Description("Token")]
                [JsonProperty("token")]
                public string Token { get; set; } = "";
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
                public string Mobile { get; set; } = "";
                /// <summary>
                /// 验证码
                /// </summary>
                [Description("验证码")]
                [JsonProperty("code")]
                public string Code { get; set; } = "";
                /// <summary>
                /// 结果
                /// </summary>
                [Description("结果")]
                [JsonProperty("result")]
                public bool Result { get; set; } = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public class DTO_Result
            {
                /// <summary>
                /// 结果
                /// </summary>
                [Description("结果")]
                [JsonProperty("result")]
                public bool Result { get; set; } = false;
                /// <summary>
                /// Token
                /// </summary>
                [Description("Token")]
                [JsonProperty("token")]
                public string Token { get; set; } = "";
                /// <summary>
                /// 用户
                /// </summary>
                [Description("用户")]
                [JsonProperty("userInfo")]
                public DTO_User UserInfo { get; set; } = new DTO_User();
            }
            /// <summary>
            /// 
            /// </summary>
            public class DTO_User
            {
                /// <summary>
                /// 用户Id
                /// </summary>
                [Description("用户Id")]
                [JsonProperty("userId")]
                public int UserId { get; set; } = -1;
                /// <summary>
                /// 用户名
                /// </summary>
                [Description("用户名")]
                [JsonProperty("userName")]
                public string UserName { get; set; } = "";
                /// <summary>
                /// 实名
                /// </summary>
                [Description("实名")]
                [JsonProperty("realName")]
                public string RealName { get; set; } = "";
            }
            #endregion
        }
        #endregion

    }
}