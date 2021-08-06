using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 订单明细
    /// </summary>
    [Table("CMS_OrderDetail")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class OrderDetail : BaseCacheEntity<OrderDetail>
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
        /// 订单Id
        /// </summary>
        [Description("订单Id")]
        [JsonProperty("orderId")]
        [DefaultValue(-1)]
        public int? OrderId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [StringLength(255)]
        [Description("订单编号")]
        [JsonProperty("orderNo")]
        [DefaultValue("")]
        public string OrderNo { get; set; }
        /// <summary>
        /// 买家Id
        /// </summary>
        [Description("买家Id")]
        [JsonProperty("buyerId")]
        [DefaultValue(-1)]
        public int? BuyerId { get; set; }
        /// <summary>
        /// 买家名称
        /// </summary>
        [StringLength(255)]
        [Description("买家名称")]
        [JsonProperty("buyerName")]
        [DefaultValue("")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [Description("商品Id")]
        [JsonProperty("goodsId")]
        [DefaultValue(-1)]
        public int? GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [StringLength(255)]
        [Description("商品名称")]
        [JsonProperty("goodsName")]
        [DefaultValue("")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 所有权用户Id
        /// </summary>
        [Description("所有权用户Id")]
        [JsonProperty("ownerId")]
        [DefaultValue(-1)]
        public int? OwnerId { get; set; }
        /// <summary>
        /// 所有权用户名称
        /// </summary>
        [StringLength(255)]
        [Description("所有权用户名称")]
        [JsonProperty("ownerName")]
        [DefaultValue("")]
        public string OwnerName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Description("单价")]
        [JsonProperty("unitPrice")]
        [DefaultValue(0)]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        [JsonProperty("quantity")]
        [DefaultValue(0)]
        public int? Quantity { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        [Description("折扣")]
        [JsonProperty("discount")]
        [DefaultValue(0)]
        public int? Discount { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        [JsonProperty("totalPrice")]
        [DefaultValue(0)]
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; }
        /// <summary>
        /// 状态Id
        /// </summary>
        [Description("状态Id")]
        [JsonProperty("statusId")]
        [DefaultValue(-1)]
        public int? StatusId { get; set; }
        /// <summary>
        /// 状态名
        /// </summary>
        [StringLength(255)]
        [Description("状态名")]
        [JsonProperty("statusName")]
        [DefaultValue("")]
        public string StatusName { get; set; }
        /// <summary>
        /// 状态数值
        /// </summary>
        [Description("状态数值")]
        [JsonProperty("statusValue")]
        [DefaultValue(0)]
        public int? StatusValue { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? CreateDateTime { get; set; } 
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Description("创建用户Id")]
        [JsonProperty("createUserId")]
        [DefaultValue(-1)]
        public int? CreateUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Description("最后修改时间")]
        [JsonProperty("editDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? EditDateTime { get; set; }
        /// <summary>
        /// 最后修改用户Id
        /// </summary>
        [Description("最后修改用户Id")]
        [JsonProperty("editUserId")]
        [DefaultValue(-1)]
        public int? EditUserId { get; set; }
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 订单
        /// </summary>
        [Description("订单")]
        [JsonProperty("order")]
        [NotMapped]
        public Order Order { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [JsonProperty("goods")]
        [NotMapped]
        public Goods Goods { get; set; }
        /// <summary>
        /// 买家
        /// </summary>
        [Description("买家")]
        [JsonProperty("buyer")]
        [NotMapped]
        public Member Buyer { get; set; }
        /// <summary>
        /// 所有人
        /// </summary>
        [Description("所有人")]
        [JsonProperty("owner")]
        [NotMapped]
        public Member Owner { get; set; }
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
