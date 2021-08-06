using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.ASM
{
    /// <summary>
    /// 行政区划
    /// </summary>
    [Table("ASM_Region")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Region : BaseCacheEntity<Region>
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
        public int? Pid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(255)]
        [Description("名称")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        [StringLength(4000)]
        [Description("代码")]
        [JsonProperty("code")]
        [DefaultValue("")]
        public string Code { get; set; }
        /// <summary>
        /// 导入版本
        /// </summary>
        [StringLength(255)]
        [Description("导入版本")]
        [JsonProperty("importVersion")]
        [DefaultValue("")]
        public string ImportVersion { get; set; }
        /// <summary>
        /// 导入时间
        /// </summary>
        [Description("导入时间")]
        [JsonProperty("importDateTime")]
        public DateTime? ImportDateTime { get; set; }
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
        /// 路径
        /// </summary>
        [StringLength(2000)]
        [Description("路径")]
        [JsonProperty("path")]
        [DefaultValue("")]
        [NotMapped]
        public string Path { get; set; }
        /// <summary>
        /// 上级字典
        /// </summary>
        [Description("上级字典")]
        [JsonProperty("parentRegion")]
        [NotMapped]
        public Region ParentRegion { get; set; }
        #endregion
    }
}
