﻿using MISApi.Entities.ASM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 会员权限
    /// </summary>
    [Table("CMS_MemberPower")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class MemberPower : BaseCacheEntity<MemberPower>
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
        /// 名称
        /// </summary>
        [StringLength(255)]
        [Description("名称")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; }
        /// <summary>
        /// 归类Id
        /// </summary>
        [Description("归类Id")]
        [JsonProperty("classifyId")]
        [DefaultValue(-1)]
        public int? ClassifyId { get; set; }
        /// <summary>
        /// 归类名称
        /// </summary>
        [StringLength(255)]
        [Description("归类名称")]
        [JsonProperty("classifyName")]
        [DefaultValue("")]
        public string ClassifyName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Description("价格")]
        [JsonProperty("price")]
        [DefaultValue(typeof(decimal), "0")]
        public decimal? Price { get; set; }
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
        /// 类别
        /// </summary>
        [Description("类别")]
        [JsonProperty("classify")]
        [NotMapped]
        public Dictionary Classify { get; set; }
        #endregion
    }
}
