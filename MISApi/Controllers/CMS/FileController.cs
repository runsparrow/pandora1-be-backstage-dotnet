﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 文件处理
    /// </summary>
    [ApiController]
    public class FileController : ControllerBase
    {
        #region RPC
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/File/Upload", Name = "MIS_CMS_File_Upload")]
        [HttpPost]
        [Authorize]
        public IActionResult Upload(DTO_File dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new FileService().Upload(
                        new File
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
        /// 上传文件
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        [Route("MIS/CMS/File/Uploads", Name = "MIS_CMS_File_Uploads")]
        [HttpPost]
        //[Authorize]
        public IActionResult Uploads(List<DTO_File> dtos)
        {
            try
            {
                // DTO
                if (dtos != null)
                {
                    List<File> files = new List<File>();

                    dtos.ForEach(dto =>
                    {
                        files.Add(new File
                        {
                            Goods = dto,
                            Member = new Member
                            {
                                Id = dto.MemberId,
                                Name = dto.MemberName,
                            }
                        });
                    });

                    new FileService().Upload(files);

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
        [Route("MIS/CMS/File/Down", Name = "MIS_CMS_File_Down")]
        [HttpPost]
        [Authorize]
        public IActionResult Down(DTO_File dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new FileService().Down(
                        new File
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
        /// <param name="dtos"></param>
        /// <returns></returns>
        [Route("MIS/CMS/File/Downs", Name = "MIS_CMS_File_Downs")]
        [HttpPost]
        [Authorize]
        public IActionResult Downs(List<DTO_File> dtos)
        {
            try
            {
                // DTO
                if (dtos != null)
                {
                    List<File> files = new List<File>();

                    dtos.ForEach(dto =>
                    {
                        files.Add(new File
                        {
                            Goods = dto,
                            Member = new Member
                            {
                                Id = dto.MemberId,
                                Name = dto.MemberName,
                            }
                        });
                    });

                    new FileService().Down(files);

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
                    Message = $"下载记录创建失败。错误信息：{ex.Message}。"
                });
            }
        }

        #endregion

        #region HttpEntities
        /// <summary>
        /// 
        /// </summary>
        [JsonObject(MemberSerialization.OptOut)]
        [Serializable]
        public class DTO_File : Goods
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
