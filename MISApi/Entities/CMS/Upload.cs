﻿using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 上传
    /// </summary>
    [Table("CMS_Upload")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Upload : BaseCacheEntity<Upload>
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
        /// 商品Id
        /// </summary>
        [Description("商品Id")]
        [JsonProperty("goodsId")]
        [DefaultValue(-1)]
        public int GoodsId { get; set; } = -1;
        /// <summary>
        /// 商品名称
        /// </summary>
        [StringLength(255)]
        [Description("商品名称")]
        [JsonProperty("goodsName")]
        [DefaultValue("")]
        public string GoodsName { get; set; } = "";
        /// <summary>
        /// 上传时间
        /// </summary>
        [Description("上传时间")]
        [JsonProperty("uploadDateTime")]
        public DateTime UploadDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否上传成功
        /// </summary>
        [Description("是否上传成功")]
        [JsonProperty("uploadResult")]
        [DefaultValue(false)]
        public bool UploadResult { get; set; } = false;
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        [JsonProperty("member")]
        [NotMapped]
        public Member Member { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [JsonProperty("goods")]
        [NotMapped]
        public Goods Goods { get; set; }
        #endregion
    }
}
