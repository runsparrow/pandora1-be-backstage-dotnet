using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 充值
    /// </summary>
    [Table("CMS_Recharge")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Recharge : BaseCacheEntity<Recharge>
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
        /// 会员Id
        /// </summary>
        [Description("会员Id")]
        [JsonProperty("memberId")]
        [DefaultValue(-1)]
        public int? MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        [StringLength(255)]
        [Description("会员姓名")]
        [JsonProperty("memberName")]
        [DefaultValue("")]
        public string MemberName { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        [Description("流水号")]
        [JsonProperty("serialNo")]
        [DefaultValue("")]
        public string SerialNo { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        [Description("交易金额")]
        [JsonProperty("dealAmount")]
        [DefaultValue(0)]
        public decimal? DealAmount { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        [Description("交易时间")]
        [JsonProperty("dealDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? DealDateTime { get; set; }
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
        /// 会员
        /// </summary>
        [Description("会员")]
        [JsonProperty("member")]
        [NotMapped]
        public Member Member { get; set; }
        #endregion
    }
}
