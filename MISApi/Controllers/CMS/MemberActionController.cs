using Microsoft.AspNetCore.Authorization;
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
    /// 会员行为
    /// </summary>
    [ApiController]
    public class MemberActionController : ControllerBase
    {
        #region RPC
        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="memberId">会员Id</param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Collect/{goodsId}/{memberId}", Name = "MIS_CMS_MemberAction_Collect_GoodsId_MemberId")]
        [HttpGet]
        [Authorize]
        public IActionResult Collect(int goodsId, int memberId)
        {
            try
            {
                new MemberActionService().Collect(goodsId, memberId);
                // 返回结果
                return new JsonResult(new DTO_Result
                {
                    Result = true
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = $"收藏失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="memberId">会员Id</param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Uncollect/{goodsId}/{memberId}", Name = "MIS_CMS_MemberAction_Uncollect_GoodsId_MemberId")]
        [HttpGet]
        [Authorize]
        public IActionResult Uncollect(int goodsId, int memberId)
        {
            try
            {
                new MemberActionService().Uncollect(goodsId, memberId);
                // 返回结果
                return new JsonResult(new DTO_Result
                {
                    Result = true
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new DTO_Result
                {
                    Result = false,
                    Message = $"取消收藏失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 购买套餐
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/BuyMemberPower", Name = "MIS_CMS_MemberAction_BuyMemberPower")]
        [HttpPost]
        [Authorize]
        public IActionResult BuyMemberPower(DTO_MemberPower dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new MemberActionService().BuyMemberPower(dto, dto.MemberPowerId);

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
                    Message = $"付款信息保存失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 退套餐
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/RefundMemberPower", Name = "MIS_CMS_MemberAction_RefundMemberPower")]
        [HttpPost]
        [Authorize]
        public IActionResult RefundMemberPower(DTO_MemberPower dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new MemberActionService().RefundMemberPower(dto, dto.MemberPowerId);

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
                    Message = $"退款信息保存失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 购买素材
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/BuyGoods", Name = "MIS_CMS_MemberAction_BuyGoods")]
        [HttpPost]
        [Authorize]
        public IActionResult BuyGoods(DTO_Goods dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new MemberActionService().BuyGoods(dto, dto.GoodsId);

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
                    Message = $"付款信息保存失败。错误信息：{ex.Message}。"
                });
            }
        }
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Upload", Name = "MIS_CMS_MemberAction_Upload")]
        [HttpPost]
        [Authorize]
        public IActionResult Upload(DTO_File dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new MemberActionService().Upload(
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
        /// 上传
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Uploads", Name = "MIS_CMS_MemberAction_Uploads")]
        [HttpPost]
        [Authorize]
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

                    new MemberActionService().Upload(files);

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
        /// 下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Down", Name = "MIS_CMS_MemberAction_Down")]
        [HttpPost]
        [Authorize]
        public IActionResult Down(DTO_File dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new MemberActionService().Down(
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
        /// 下载
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        [Route("MIS/CMS/MemberAction/Downs", Name = "MIS_CMS_MemberAction_Downs")]
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

                    new MemberActionService().Down(files);

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
        public class DTO_Collect
        {
            /// <summary>
            /// 会员Id
            /// </summary>
            [Description("会员Id")]
            [JsonProperty("memberId")]
            public int MemberId { get; set; } = -1;
            /// <summary>
            /// 商品Id
            /// </summary>
            [Description("商品Id")]
            [JsonProperty("goodsId")]
            public int GoodsId { get; set; } = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonObject(MemberSerialization.OptOut)]
        [Serializable]
        public class DTO_MemberPower : Serial
        {
            /// <summary>
            /// 会员套餐Id
            /// </summary>
            [Description("会员套餐Id")]
            [JsonProperty("memberPowerId")]
            public int MemberPowerId { get; set; } = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonObject(MemberSerialization.OptOut)]
        [Serializable]
        public class DTO_Goods : Serial
        {
            /// <summary>
            /// 商品Id
            /// </summary>
            [Description("商品Id")]
            [JsonProperty("goodsId")]
            public int GoodsId { get; set; } = -1;
        }
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
