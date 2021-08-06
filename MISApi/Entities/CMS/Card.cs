using MISApi.Entities.ASM;
using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 发卡
    /// </summary>
    [Table("CMS_Card")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Card : BaseCacheEntity<Card>
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
        /// 卡号
        /// </summary>
        [StringLength(50)]
        [Description("卡号")]
        [JsonProperty("cardNo")]
        [DefaultValue("")]
        public string CardNo { get; set; }
        /// <summary>
        /// 卡前缀
        /// </summary>
        [StringLength(50)]
        [Description("卡前缀")]
        [JsonProperty("cardPrefix")]
        [DefaultValue("")]
        public string CardPrefix { get; set; }
        /// <summary>
        /// 卡密
        /// </summary>
        [StringLength(50)]
        [Description("卡密")]
        [JsonProperty("cardPassword")]
        [DefaultValue("")]
        public string CardPassword { get; set; }
        /// <summary>
        /// 发卡日期
        /// </summary>
        [Description("发卡日期")]
        [JsonProperty("cardDate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? CardDate { get; set; }
        /// <summary>
        /// 有效期天数限制
        /// </summary>
        [Description("有效期天数限制")]
        [JsonProperty("daysLimit")]
        [DefaultValue(-1)]
        public int? DaysLimit { get; set; }
        /// <summary>
        /// 是否可下载
        /// </summary>
        [Description("是否可下载")]
        [JsonProperty("isDown")]
        [DefaultValue(false)]
        public bool? IsDown { get; set; }
        /// <summary>
        /// 下载限制
        /// </summary>
        [Description("下载限制")]
        [JsonProperty("downLimit")]
        [DefaultValue(-1)]
        public int? DownLimit { get; set; }
        /// <summary>
        /// 是否可上传
        /// </summary>
        [Description("是否可上传")]
        [JsonProperty("isUpload")]
        [DefaultValue(false)]
        public bool? IsUpload { get; set; }
        /// <summary>
        /// 上传限制
        /// </summary>
        [Description("上传限制")]
        [JsonProperty("uploadLimit")]
        [DefaultValue(-1)]
        public int? UploadLimit { get; set; }
        /// <summary>
        /// 是否可购买
        /// </summary>
        [Description("是否可购买")]
        [JsonProperty("isBuy")]
        [DefaultValue(false)]
        public bool? IsBuy { get; set; }
        /// <summary>
        /// 购买限制
        /// </summary>
        [Description("购买限制")]
        [JsonProperty("buyLimit")]
        [DefaultValue(-1)]
        public int? BuyLimit { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [Description("是否激活")]
        [JsonProperty("isActivate")]
        [DefaultValue(false)]
        public bool? IsActivate { get; set; }
        /// <summary>
        /// 激活会员Id
        /// </summary>
        [Description("激活会员Id")]
        [JsonProperty("activateMemberId")]
        [DefaultValue(-1)]
        public int? ActivateMemberId { get; set; }
        /// <summary>
        /// 激活会员名
        /// </summary>
        [StringLength(50)]
        [Description("激活会员名")]
        [JsonProperty("activateMemberName")]
        [DefaultValue("")]
        public string ActivateMemberName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; }
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
        [StringLength(50)]
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
