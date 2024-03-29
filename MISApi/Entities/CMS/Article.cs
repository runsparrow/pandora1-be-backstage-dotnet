﻿using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 资讯
    /// </summary>
    [Table("CMS_Article")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Article : BaseCacheEntity<Article>
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
        /// 导航Id
        /// </summary>
        [Description("导航Id")]
        [JsonProperty("navigationId")]
        [DefaultValue(-1)]
        public int? NavigationId { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        [StringLength(255)]
        [Description("导航名称")]
        [JsonProperty("navigationName")]
        [DefaultValue("")]
        public string NavigationName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(255)]
        [Description("标题")]
        [JsonProperty("title")]
        [DefaultValue("")]
        public string Title { get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        [StringLength(255)]
        [Description("发表人")]
        [JsonProperty("publisher")]
        [DefaultValue("")]
        public string Publisher { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Description("发表时间")]
        [JsonProperty("publishDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? PublishDateTime { get; set; }
        /// <summary>
        /// 文章来源
        /// </summary>
        [StringLength(255)]
        [Description("文章来源")]
        [JsonProperty("source")]
        [DefaultValue("")]
        public string Source { get; set; }
        /// <summary>
        /// 文章来源路径
        /// </summary>
        [StringLength(4000)]
        [Description("文章来源路径")]
        [JsonProperty("sourceUrl")]
        [DefaultValue("")]
        public string SourceUrl { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        [StringLength(255)]
        [Description("简介")]
        [JsonProperty("summary")]
        [DefaultValue("")]
        public string Summary { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [StringLength(int.MaxValue)]
        [Description("简介")]
        [JsonProperty("content")]
        [DefaultValue("")]
        public string Content { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(255)]
        [Description("标签")]
        [JsonProperty("tags")]
        [DefaultValue("")]
        public string Tags { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [StringLength(4000)]
        [Description("路径")]
        [JsonProperty("url")]
        [DefaultValue("")]
        public string Url { get; set; }
        /// <summary>
        /// 路径类型
        /// </summary>
        [Description("路径类型")]
        [JsonProperty("urlType")]
        [DefaultValue("0")]
        public int? UrlType { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")]
        [JsonProperty("isDisplay")]
        [DefaultValue(false)]
        public bool? IsDisplay { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Description("是否置顶")]
        [JsonProperty("isTop")]
        [DefaultValue(false)]
        public bool? IsTop { get; set; }
        /// <summary>
        /// 是否弹出
        /// </summary>
        [Description("是否弹出")]
        [JsonProperty("isTarget")]
        [DefaultValue(false)]
        public bool? IsTarget { get; set; }
        /// <summary>
        /// 允许评论
        /// </summary>
        [Description("允许评论")]
        [JsonProperty("isDiscuss")]
        [DefaultValue(false)]
        public bool? IsDiscuss { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        [Description("点击量")]
        [JsonProperty("hits")]
        [DefaultValue(0)]
        public int? Hits { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        [Description("点赞量")]
        [JsonProperty("likes")]
        [DefaultValue(0)]
        public int? Likes { get; set; }
        /// <summary>
        /// 收藏量
        /// </summary>
        [Description("收藏量")]
        [JsonProperty("collects")]
        [DefaultValue(0)]
        public int? Collects { get; set; }
        /// <summary>
        /// 转发量
        /// </summary>
        [Description("转发量")]
        [JsonProperty("forwards")]
        [DefaultValue(0)]
        public int? Forwards { get; set; }
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
        /// 导航
        /// </summary>
        [Description("导航")]
        [JsonProperty("navigation")]
        [NotMapped]
        public Navigation Navigation { get; set; }
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
