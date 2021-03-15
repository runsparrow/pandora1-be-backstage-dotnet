using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 账户
    /// </summary>
    [Table("CMS_Account")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Account : BaseCacheEntity<Account>
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
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = -1;
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("userName")]
        public string UserName { get; set; } = "";
        /// <summary>
        /// 账号
        /// </summary>
        [StringLength(255)]
        [Description("账号")]
        [JsonProperty("accountNo")]
        public string AccountNo { get; set; } = "";
        /// <summary>
        /// 开户银行
        /// </summary>
        [StringLength(255)]
        [Description("开户银行")]
        [JsonProperty("depositBank")]
        public string DepositBank { get; set; } = "";
        /// <summary>
        /// 实名
        /// </summary>
        [StringLength(255)]
        [Description("实名")]
        [JsonProperty("realName")]
        public string RealName { get; set; } = "";
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(255)]
        [Description("身份证")]
        [JsonProperty("idCard")]
        public string IdCard { get; set; } = "";
        /// <summary>
        /// 归类Id
        /// </summary>
        [Description("归类Id")]
        [JsonProperty("classifyId")]
        public int ClassifyId { get; set; } = -1;
        /// <summary>
        /// 归类名称
        /// </summary>
        [StringLength(255)]
        [Description("归类名称")]
        [JsonProperty("classifyName")]
        public string ClassifyName { get; set; } = "";
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
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status { get; set; }
        #endregion
    }
}
