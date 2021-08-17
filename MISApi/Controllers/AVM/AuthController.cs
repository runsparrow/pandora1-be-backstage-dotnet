using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.AVM;
using MISApi.Services.AVM;
using MISApi.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        /// 验证获取用户Token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/Auth/GetToken", Name = "MIS_AVM_Auth_Get_Token")]
        [HttpPost]
        public IActionResult GetToken(DTO_Login dto)
        {
            var user = new UserService.RowService().Verify(dto.Name, dto.Password);
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
                return new JsonResult(new DTO_Result_User
                {
                    Result = true,
                    Token = token,
                    User = new DTO_User { UserId = user.Id, UserName = user.Name, RealName = user.RealName }
                });

            }
            else
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = "Authentication Failure"
                });
            }
        }
        /// <summary>
        /// 根据Token获取用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/Auth/GetEntity", Name = "MIS_AVM_Auth_Get_Entity")]
        [HttpPost]
        public IActionResult GetEntity([FromBody] DTO_Token dto)
        {
            ClaimEntity claim = GetClaimFromToken(dto.Token);

            return new JsonResult(new DTO_Result_User { Result = true, Token = dto.Token, User = new DTO_User { UserId = claim.Id, UserName = claim.Name, RealName = claim.RealName } });
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/Auth/ChangePassword", Name = "MIS_AVM_Auth_ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword([FromBody] DTO_ChangePassword dto)
        {
            var user = new UserService.RowService().Verify(dto.UserName, dto.OldPassword);
            if (user != null)
            {
                user.Password = EncryptHelper.GetBase64String(dto.NewPassword);
                new UserService.UpdateService().Update(user);
                return new JsonResult(new DTO_Result { Result = true, Message = "密码修改成功！" });
            }
            else
            {
                return new JsonResult(new DTO_Result { Result = false, Message = "旧密码输入错误！" });
            }
        }
        /// <summary>
        /// 初始密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/Auth/InitPassword", Name = "MIS_AVM_Auth_InitPassword")]
        [HttpPost]
        [Authorize]
        public IActionResult InitPassword([FromBody] DTO_Login dto)
        {
            List<User> existList = new UserService.RowsService().ByName(dto.Name);
            if (existList.Count > 0)
            {
                existList[0].Password = EncryptHelper.GetBase64String(dto.Password);
                new UserService.UpdateService().Update(existList[0]);
                return new JsonResult(new DTO_Result { Result = true, Message = "密码初始成功！" });
            }
            else
            {
                return new JsonResult(new DTO_Result { Result = false, Message = "未找到该用户！" });
            }
        }
        #endregion

        #region HttpEntities
        /// <summary>
        /// 
        /// </summary>
        public class DTO_Result_User : DTO_Result
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
            [JsonProperty("user")]
            public DTO_User User { get; set; } = new DTO_User();
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_User
        {
            /// <summary>
            /// 会员Id
            /// </summary>
            [Description("会员Id")]
            [JsonProperty("userId")]
            [DefaultValue(-1)]
            public int UserId { get; set; } = -1;
            /// <summary>
            /// 会员名
            /// </summary>
            [Description("会员名")]
            [JsonProperty("userName")]
            [DefaultValue("")]
            public string UserName { get; set; } = "";
            /// <summary>
            /// 实名
            /// </summary>
            [Description("实名")]
            [JsonProperty("realName")]
            [DefaultValue("")]
            public string RealName { get; set; } = "";
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
            [JsonProperty("user")]
            public User User { get; set; }
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
            /// <summary>
            /// 验证码
            /// </summary>
            [Description("验证码")]
            [JsonProperty("code")]
            [DefaultValue("")]
            public string Code { get; set; } = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public class DTO_ChangePassword
        {
            /// <summary>
            /// 用户名
            /// </summary>
            [Description("用户名")]
            [JsonProperty("userName")]
            [DefaultValue("")]
            public string UserName { get; set; } = "";
            /// <summary>
            /// 旧密码
            /// </summary>
            [Description("旧密码")]
            [JsonProperty("oldPassword")]
            [DefaultValue("")]
            public string OldPassword { get; set; } = "";
            /// <summary>
            /// 新密码
            /// </summary>
            [Description("新密码")]
            [JsonProperty("newPassword")]
            [DefaultValue("")]
            public string NewPassword { get; set; } = "";
        }

        #endregion
    }
}