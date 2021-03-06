using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 流水
    /// </summary>
    [Table("CMS_Serial")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Serial : BaseCacheEntity<Serial>
    {
        #region Property
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("#")]
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        [StringLength(255)]
        [Description("流水号")]
        [JsonProperty("serialNo")]
        public string SerialNo { get; set; } = "";
        /// <summary>
        /// 付款人Id
        /// </summary>
        [Description("付款人Id")]
        [JsonProperty("payerId")]
        public int PayerId { get; set; } = -1;
        /// <summary>
        /// 付款人用户名
        /// </summary>
        [StringLength(255)]
        [Description("付款人用户名")]
        [JsonProperty("payerName")]
        public string PayerName { get; set; } = "";
        /// <summary>
        /// 付款人实名
        /// </summary>
        [StringLength(255)]
        [Description("付款人实名")]
        [JsonProperty("payerRealName")]
        public string PayerRealName { get; set; } = "";
        /// <summary>
        /// 付款人账号
        /// </summary>
        [StringLength(255)]
        [Description("付款人账号")]
        [JsonProperty("payerAccount")]
        public string PayerAccount { get; set; } = "";
        /// <summary>
        /// 收款人Id
        /// </summary>
        [Description("收款人Id")]
        [JsonProperty("receiverId")]
        public int ReceiverId { get; set; } = -1;
        /// <summary>
        /// 收款人用户名
        /// </summary>
        [StringLength(255)]
        [Description("收款人用户名")]
        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; } = "";
        /// <summary>
        /// 收款人实名
        /// </summary>
        [StringLength(255)]
        [Description("收款人实名")]
        [JsonProperty("receiverRealName")]
        public string ReceiverRealName { get; set; } = "";
        /// <summary>
        /// 收款人账号
        /// </summary>
        [StringLength(255)]
        [Description("收款人账号")]
        [JsonProperty("receiverAccount")]
        public string ReceiverAccount { get; set; } = "";
        /// <summary>
        /// 交易时间
        /// </summary>
        [Description("交易时间")]
        [JsonProperty("dealDateTime")]
        public DateTime DealDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 交易金额
        /// </summary>
        [Description("交易金额")]
        [JsonProperty("dealAmount")]
        public decimal DealAmount { get; set; } = 0;
        /// <summary>
        /// 交易类型
        /// </summary>
        [StringLength(1)]
        [Description("交易类型")]
        [JsonProperty("dealType")]
        public string DealType { get; set; } = "";
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
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 付款人
        /// </summary>
        [Description("付款人")]
        [JsonProperty("payer")]
        [NotMapped]
        public User Payer { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        [Description("收款人")]
        [JsonProperty("receiver")]
        [NotMapped]
        public User Receiver { get; set; }
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
