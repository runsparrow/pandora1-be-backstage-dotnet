using MISApi.Entities.AVM;
using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 提现
    /// </summary>
    [Table("CMS_CashOut")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class CashOut : BaseCacheEntity<CashOut>
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
        /// 序列号
        /// </summary>
        [StringLength(255)]
        [Description("序列号")]
        [JsonProperty("serialNo")]
        [DefaultValue("")]
        public string SerialNo { get; set; } = "";
        /// <summary>
        /// 申请人Id
        /// </summary>
        [Description("申请人Id")]
        [JsonProperty("applierId")]
        [DefaultValue(-1)]
        public int ApplierId { get; set; } = -1;
        /// <summary>
        /// 申请人姓名
        /// </summary>
        [StringLength(255)]
        [Description("申请人姓名")]
        [JsonProperty("applierName")]
        [DefaultValue("")]
        public string ApplierName { get; set; } = "";
        /// <summary>
        /// 申请时间
        /// </summary>
        [Description("申请时间")]
        [JsonProperty("applierDate")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime ApplierDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 提现账号Id
        /// </summary>
        [Description("提现账号Id")]
        [JsonProperty("accountId")]
        [DefaultValue(-1)]
        public int AccountId { get; set; } = -1;
        /// <summary>
        /// 账号
        /// </summary>
        [StringLength(255)]
        [Description("账号")]
        [JsonProperty("accountNo")]
        [DefaultValue("")]
        public string AccountNo { get; set; } = "";
        /// <summary>
        /// 交易金额
        /// </summary>
        [Description("交易金额")]
        [JsonProperty("dealAmount")]
        [DefaultValue(0)]
        public decimal DealAmount { get; set; } = 0;
        /// <summary>
        /// 交易时间
        /// </summary>
        [Description("交易时间")]
        [JsonProperty("dealDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime DealDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 审批人Id
        /// </summary>
        [Description("审批人Id")]
        [JsonProperty("approverId")]
        [DefaultValue(-1)]
        public int ApproverId { get; set; } = -1;
        /// <summary>
        /// 审批人姓名
        /// </summary>
        [StringLength(255)]
        [Description("审批人姓名")]
        [JsonProperty("approverName")]
        [DefaultValue("")]
        public string ApproverName { get; set; } = "";
        /// <summary>
        /// 审批时间
        /// </summary>
        [Description("审批时间")]
        [JsonProperty("approverDate")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime ApproverDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 放款人Id
        /// </summary>
        [Description("放款人Id")]
        [JsonProperty("loanerId")]
        [DefaultValue(-1)]
        public int LoanerId { get; set; } = -1;
        /// <summary>
        /// 放款人姓名
        /// </summary>
        [StringLength(255)]
        [Description("放款人姓名")]
        [JsonProperty("loanerName")]
        [DefaultValue("")]
        public string LoanerName { get; set; } = "";
        /// <summary>
        /// 放款时间
        /// </summary>
        [Description("放款时间")]
        [JsonProperty("loanerDate")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime LoanerDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; } = "";
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
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 申请人
        /// </summary>
        [Description("申请人")]
        [JsonProperty("applier")]
        [NotMapped]
        public Member Applier { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        [Description("审批人")]
        [JsonProperty("approver")]
        [NotMapped]
        public User Approver { get; set; }
        /// <summary>
        /// 放款人
        /// </summary>
        [Description("放款人")]
        [JsonProperty("loaner")]
        [NotMapped]
        public User Loaner { get; set; }
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
