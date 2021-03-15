using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 导航
    /// </summary>
    [Table("CMS_Navigation")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Navigation : BaseCacheEntity<Navigation>
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
        /// 父节点Id
        /// </summary>
        [Description("#")]
        [JsonProperty("pid")]
        public int Pid { get; set; } = -1;
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(255)]
        [Description("名称")]
        [JsonProperty("name")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 排序
        /// </summary>
        [StringLength(255)]
        [Description("排序")]
        [JsonProperty("sort")]
        public string Sort { get; set; } = "";
        /// <summary>
        /// 分组
        /// </summary>
        [StringLength(255)]
        [Description("分组")]
        [JsonProperty("group")]
        public string Group { get; set; } = "";
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
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")]
        [JsonProperty("isDisplay")]
        public bool IsDisplay { get; set; } = false;
        /// <summary>
        /// 是否作为链接
        /// </summary>
        [Description("是否作为链接")]
        [JsonProperty("isLink")]
        public bool IsLink { get; set; } = false;
        /// <summary>
        /// 是否弹出
        /// </summary>
        [Description("是否弹出")]
        [JsonProperty("isTarget")]
        public bool IsTarget { get; set; } = false;
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(255)]
        [Description("图标")]
        [JsonProperty("Icon")]
        public string Icon { get; set; } = "";
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
        /// 路径
        /// </summary>
        [StringLength(2000)]
        [Description("路径")]
        [JsonProperty("path")]
        [NotMapped]
        public string Path { get; set; } = "";
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
