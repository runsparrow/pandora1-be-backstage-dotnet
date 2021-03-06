﻿using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 订单
    /// </summary>
    [Table("CMS_Order")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Order : BaseCacheEntity<Order>
    {
        #region Property
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("#")]
        [JsonProperty("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [StringLength(255)]
        [Description("订单编号")]
        [JsonProperty("orderNo")]
        [DefaultValue("")]
        public string OrderNo { get; set; } = "";
        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        [JsonProperty("orderDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime OrderDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 折扣
        /// </summary>
        [Description("折扣")]
        [JsonProperty("discount")]
        [DefaultValue(0)]
        public int Discount { get; set; } = 0;
        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        [JsonProperty("totalPrice")]
        [DefaultValue(0)]
        public decimal TotalPrice { get; set; } = 0;
        /// <summary>
        /// 买家
        /// </summary>
        [Description("买家")]
        [JsonProperty("buyerId")]
        [DefaultValue(-1)]
        public int BuyerId { get; set; } = -1;
        /// <summary>
        /// 买家名称
        /// </summary>
        [StringLength(255)]
        [Description("买家名称")]
        [JsonProperty("buyerName")]
        [DefaultValue("")]
        public string BuyerName { get; set; } = "";
        /// <summary>
        /// 支付方式
        /// </summary>
        [StringLength(1)]
        [Description("支付方式")]
        [JsonProperty("payMode")]
        [DefaultValue("")]
        public string PayMode { get; set; } = "";
        /// <summary>
        /// 支付流水号
        /// </summary>
        [StringLength(255)]
        [Description("支付流水号")]
        [JsonProperty("serialNo")]
        [DefaultValue("")]
        public string SerialNo { get; set; } = "";
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 状态Id
        /// </summary>
        [Description("状态Id")]
        [JsonProperty("statusId")]
        [DefaultValue(-1)]
        public int StatusId { get; set; } = -1;
        /// <summary>
        /// 状态名
        /// </summary>
        [StringLength(255)]
        [Description("状态名")]
        [JsonProperty("statusName")]
        [DefaultValue("")]
        public string StatusName { get; set; } = "";
        /// <summary>
        /// 状态数值
        /// </summary>
        [Description("状态数值")]
        [JsonProperty("statusValue")]
        [DefaultValue(0)]
        public int StatusValue { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime CreateDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Description("创建用户Id")]
        [JsonProperty("createUserId")]
        [DefaultValue(-1)]
        public int CreateUserId { get; set; } = -1;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Description("最后修改时间")]
        [JsonProperty("editDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime EditDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后修改用户Id
        /// </summary>
        [Description("最后修改用户Id")]
        [JsonProperty("editUserId")]
        [DefaultValue(-1)]
        public int EditUserId { get; set; } = -1;
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 订单明细
        /// </summary>
        [Description("订单明细")]
        [JsonProperty("orderDetails")]
        [NotMapped]
        public List<OrderDetail> OrderDetails { get; set; }
        /// <summary>
        /// 买家
        /// </summary>
        [Description("买家")]
        [JsonProperty("buyer")]
        [NotMapped]
        public Member Buyer { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status { get; set; }
        #endregion
    }
}
