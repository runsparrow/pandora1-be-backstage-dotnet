using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 支付
    /// </summary>
    [ApiController]
    public class PaymentController: ControllerBase
    {
        #region RPC
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Payment/Pay", Name = "MIS_CMS_Payment_Pay")]
        [HttpPost]
        [Authorize]
        public IActionResult Pay(DTO_Payment dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new PaymentService().PayMemberPower(dto, dto.MemberPowerId);

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
        /// 退款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Payment/Refund", Name = "MIS_CMS_Payment_Refund")]
        [HttpPost]
        [Authorize]
        public IActionResult Refund(DTO_Payment dto)
        {
            try
            {
                // DTO
                if (dto != null)
                {
                    new PaymentService().RefundMemberPower(dto, dto.MemberPowerId);

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
        #endregion

        #region HttpEntities
        /// <summary>
        /// 
        /// </summary>
        [JsonObject(MemberSerialization.OptOut)]
        [Serializable]
        public class DTO_Payment: Serial
        {
            /// <summary>
            /// 会员套餐Id
            /// </summary>
            [Description("会员套餐Id")]
            [JsonProperty("memberPowerId")]
            public int MemberPowerId { get; set; } = -1;
        }
        #endregion
    }
}
