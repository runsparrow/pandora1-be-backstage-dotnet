using MISApi.Entities.AVM;
using MISApi.Services.AVM;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MISApi.Controllers.AVM.AuthController.HttpEntity;
using static MISApi.Tools.AuthHelper;

namespace MISApi.Controllers.AVM
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
        [Route("MIS/AVM/Auth/GetToken", Name = "MIS_AVM_Auth_Get_Token")]
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
        [Route("MIS/AVM/Auth/GetEntity", Name = "MIS_AVM_Auth_Get_Entity")]
        [HttpPost]
        public IActionResult GetEntity([FromBody] DTO_Token dto)
        {
            ClaimEntity claim = GetClaimFromToken(dto.Token);

            return new JsonResult(new DTO_Result { Result = true, Token = dto.Token, UserInfo = new DTO_User { UserId = claim.UserId, UserName = claim.UserName, RealName = claim.RealName } });
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