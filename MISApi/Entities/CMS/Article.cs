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
        public int Id { get; set; }
        /// <summary>
        /// 导航Id
        /// </summary>
        [Description("导航Id")]
        [JsonProperty("navigationid")]
        public int Navigationid { get; set; } = -1;
        /// <summary>
        /// 导航名称
        /// </summary>
        [StringLength(255)]
        [Description("导航名称")]
        [JsonProperty("navigationName")]
        public string NavigationName { get; set; } = "";
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(255)]
        [Description("标题")]
        [JsonProperty("title")]
        public string Title { get; set; } = "";
        /// <summary>
        /// 发表人
        /// </summary>
        [StringLength(255)]
        [Description("发表人")]
        [JsonProperty("publisher")]
        public string Publisher { get; set; } = "";
        /// <summary>
        /// 发表时间
        /// </summary>
        [Description("发表时间")]
        [JsonProperty("publishDateTime")]
        public DateTime PublishDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 文章来源
        /// </summary>
        [StringLength(255)]
        [Description("文章来源")]
        [JsonProperty("source")]
        public string Source { get; set; } = "";
        /// <summary>
        /// 文章来源路径
        /// </summary>
        [StringLength(4000)]
        [Description("文章来源路径")]
        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; } = "";
        /// <summary>
        /// 简介
        /// </summary>
        [StringLength(255)]
        [Description("简介")]
        [JsonProperty("summary")]
        public string Summary { get; set; } = "";
        /// <summary>
        /// 内容
        /// </summary>
        [StringLength(int.MaxValue)]
        [Description("简介")]
        [JsonProperty("content")]
        public string Content { get; set; } = "";
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(255)]
        [Description("标签")]
        [JsonProperty("tags")]
        public string Tags { get; set; } = "";
        /// <summary>
        /// 路径
        /// </summary>
        [StringLength(4000)]
        [Description("路径")]
        [JsonProperty("url")]
        public string Url { get; set; } = "";
        /// <summary>
        /// 路径类型
        /// </summary>
        [StringLength(255)]
        [Description("路径类型")]
        [JsonProperty("urlType")]
        public string UrlType { get; set; } = "";
        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")]
        [JsonProperty("isDisplay")]
        public bool IsDisplay { get; set; } = false;
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Description("是否置顶")]
        [JsonProperty("isTop")]
        public bool IsTop { get; set; } = false;
        /// <summary>
        /// 是否弹出
        /// </summary>
        [Description("是否弹出")]
        [JsonProperty("isTarget")]
        public bool IsTarget { get; set; } = false;
        /// <summary>
        /// 点击量
        /// </summary>
        [Description("点击量")]
        [JsonProperty("hits")]
        public int Hits { get; set; } = 0;
        /// <summary>
        /// 点赞量
        /// </summary>
        [Description("点赞量")]
        [JsonProperty("likes")]
        public int Likes { get; set; } = 0;
        /// <summary>
        /// 收藏量
        /// </summary>
        [Description("收藏量")]
        [JsonProperty("collects")]
        public int Collects { get; set; } = 0;
        /// <summary>
        /// 转发量
        /// </summary>
        [Description("转发量")]
        [JsonProperty("forwards")]
        public int Forwards { get; set; } = 0;
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
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status { get; set; }
        #endregion
    }
}