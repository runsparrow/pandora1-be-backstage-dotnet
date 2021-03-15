using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderDetail
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
        public int OrderId { get; set; } = -1;
        /// <summary>
        /// 订单编号
        /// </summary>
        [StringLength(255)]
        [Description("订单编号")]
        [JsonProperty("orderNo")]
        public string OrderNo { get; set; } = "";
        /// <summary>
        /// 买家Id
        /// </summary>
        [Description("买家Id")]
        [JsonProperty("buyerId")]
        public int BuyerId { get; set; } = -1;
        /// <summary>
        /// 买家名称
        /// </summary>
        [StringLength(255)]
        [Description("买家名称")]
        [JsonProperty("buyerName")]
        public string BuyerName { get; set; } = "";
        /// <summary>
        /// 商品Id
        /// </summary>
        [Description("商品Id")]
        [JsonProperty("goodsId")]
        public int GoodsId { get; set; } = -1;
        /// <summary>
        /// 商品名称
        /// </summary>
        [StringLength(255)]
        [Description("商品名称")]
        [JsonProperty("goodsName")]
        public string GoodsName { get; set; } = "";
        /// <summary>
        /// 所有权用户Id
        /// </summary>
        [Description("所有权用户Id")]
        [JsonProperty("ownerId")]
        public int OwnerId { get; set; } = -1;
        /// <summary>
        /// 所有权用户名称
        /// </summary>
        [StringLength(255)]
        [Description("所有权用户名称")]
        [JsonProperty("ownerName")]
        public string OwnerName { get; set; } = "";
        /// <summary>
        /// 单价
        /// </summary>
        [Description("单价")]
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; } = 0;
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        [JsonProperty("quantity")]
        public int Quantity { get; set; } = 0;
        /// <summary>
        /// 折扣
        /// </summary>
        [Description("折扣")]
        [JsonProperty("discount")]
        public int Discount { get; set; } = 0;
        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; } = 0;
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 状态Id
        /// </summary>
        [Description("状态Id")]
        [JsonProperty("statusId")]
        public int StatusId { get; set; } = -1;
        /// <summary>
        /// 状态名
        /// </summary>
        [StringLength(255)]
        [Description("状态名")]
        [JsonProperty("statusName")]
        public string StatusName { get; set; } = "";
        /// <summary>
        /// 状态数值
        /// </summary>
        [Description("状态数值")]
        [JsonProperty("statusValue")]
        public int StatusValue { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Description("创建用户Id")]
        [JsonProperty("createUserId")]
        public int CreateUserId { get; set; } = -1;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Description("最后修改时间")]
        [JsonProperty("editDateTime")]
        public DateTime EditDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后修改用户Id
        /// </summary>
        [Description("最后修改用户Id")]
        [JsonProperty("editUserId")]
        public int EditUserId { get; set; } = -1;
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
        public User Buyer { get; set; }
        /// <summary>
        /// 所有人
        /// </summary>
        [Description("所有人")]
        [JsonProperty("owner")]
        [NotMapped]
        public User Owner { get; set; }
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
