using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 文件处理
    /// </summary>
    public class RMSController : ControllerBase
    {
        #region RPC
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/RMS/Upload", Name = "MIS_CMS_RMS_Upload")]
        [HttpPost]
        [Authorize]
        public IActionResult Upload(DTO_RMS dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new RMSService().Upload(
                        new RMS
                        {
                            Goods = dto,
                            Member = new Member
                            {
                                Id = dto.MemberId,
                                Name = dto.MemberName,
                            }
                        }
                    );
                    return new JsonResult(new DTO_Result
                    {
                        Result = true
                    });
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "传入参数为空。"
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = $"上传记录创建失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/RMS/Down", Name = "MIS_CMS_RMS_Down")]
        [HttpPost]
        [Authorize]
        public IActionResult Down(DTO_RMS dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new RMSService().Upload(
                        new RMS
                        {
                            Goods = dto,
                            Member = new Member
                            {
                                Id = dto.MemberId,
                                Name = dto.MemberName,
                            }
                        }
                    );
                    return new JsonResult(new DTO_Result
                    {
                        Result = true
                    });
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "传入参数为空。"
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = $"上传记录创建失败。错误信息：{ex.Message}。"
                });
            }
        }

        #endregion

        #region HttpEntities
        /// <summary>
        /// 
        /// </summary>
        public class DTO_RMS : Goods
        {
            /// <summary>
            /// 会员Id
            /// </summary>
            [Description("会员Id")]
            [JsonProperty("memberId")]
            [DefaultValue(-1)]
            public int MemberId { get; set; } = -1;
            /// <summary>
            /// 会员姓名
            /// </summary>
            [StringLength(255)]
            [Description("会员姓名")]
            [JsonProperty("memberName")]
            [DefaultValue("")]
            public string MemberName { get; set; } = "";
        }

        #endregion
    }
}
