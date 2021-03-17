using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.AVM;
using MISApi.Services.AVM;
using System;
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
        /// 根据Token获取用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/Auth/GetEntity", Name = "MIS_AVM_Auth_Get_Entity")]
        [HttpPost]
        public IActionResult GetEntity([FromBody] DTO_Token dto)
        {
            ClaimEntity claim = GetClaimFromToken(dto.Token);

            return new JsonResult(new DTO_Result { Result = true, Token = dto.Token, UserInfo = new DTO_User { UserId = claim.Id, UserName = claim.Name, RealName = claim.RealName } });
        }
        #endregion

    }
}