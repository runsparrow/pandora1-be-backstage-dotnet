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
        [DefaultValue(-1)]
        public int Pid { get; set; } = -1;
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(255)]
        [Description("名称")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 键名
        /// </summary>
        [StringLength(255)]
        [Description("键名")]
        [JsonProperty("key")]
        [DefaultValue("")]
        public string Key { get; set; } = "";
        /// <summary>
        /// 键值
        /// </summary>
        [StringLength(255)]
        [Description("键值")]
        [JsonProperty("value")]
        [DefaultValue("")]
        public string Value { get; set; } = "";
        /// <summary>
        /// 排序
        /// </summary>
        [StringLength(255)]
        [Description("排序")]
        [JsonProperty("sort")]
        [DefaultValue("")]
        public string Sort { get; set; } = "";
        /// <summary>
        /// 分组
        /// </summary>
        [StringLength(255)]
        [Description("分组")]
        [JsonProperty("group")]
        [DefaultValue("")]
        public string Group { get; set; } = "";
        /// <summary>
        /// 路径
        /// </summary>
        [StringLength(4000)]
        [Description("路径")]
        [JsonProperty("url")]
        [DefaultValue("")]
        public string Url { get; set; } = "";
        /// <summary>
        /// 路径类型
        /// </summary>
        [Description("路径类型")]
        [JsonProperty("urlType")]
        [DefaultValue(0)]
        public int UrlType { get; set; } = 0;
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")]
        [JsonProperty("isDisplay")]
        [DefaultValue(false)]
        public bool IsDisplay { get; set; } = false;
        /// <summary>
        /// 是否作为链接
        /// </summary>
        [Description("是否作为链接")]
        [JsonProperty("isLink")]
        [DefaultValue(false)]
        public bool IsLink { get; set; } = false;
        /// <summary>
        /// 是否弹出
        /// </summary>
        [Description("是否弹出")]
        [JsonProperty("isTarget")]
        [DefaultValue(false)]
        public bool IsTarget { get; set; } = false;
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(int.MaxValue)]
        [Description("图标")]
        [JsonProperty("Icon")]
        [DefaultValue("")]
        public string Icon { get; set; } = "";
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
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 路径
        /// </summary>
        [StringLength(2000)]
        [Description("路径")]
        [JsonProperty("path")]
        [DefaultValue("")]
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
