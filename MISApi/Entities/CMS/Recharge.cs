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
        public int MemberId { get; set; } = -1;
        /// <summary>
        /// 会员姓名
        /// </summary>
        [StringLength(255)]
        [Description("会员姓名")]
        [JsonProperty("memberName")]
        [DefaultValue("")]
        public string MemberName { get; set; } = "";
        /// <summary>
        /// 流水号
        /// </summary>
        [Description("流水号")]
        [JsonProperty("serialNo")]
        [DefaultValue("")]
        public string SerialNo { get; set; } = "";
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
        public DateTime DealDateTime { get; set; } = DateTime.Now;
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
