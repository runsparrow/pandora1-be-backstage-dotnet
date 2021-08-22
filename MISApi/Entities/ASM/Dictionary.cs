using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.ASM
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Table("ASM_Dictionary")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Dictionary : BaseCacheEntity<Dictionary>
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
        /// 键名
        /// </summary>
        [StringLength(255)]
        [Description("键名")]
        [JsonProperty("key")]
        [DefaultValue("")]
        public string Key { get; set; }
        /// <summary>
        /// 键值
        /// </summary>
        [StringLength(255)]
        [Description("键值")]
        [JsonProperty("value")]
        [DefaultValue("")]
        public string Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(255)]
        [Description("描述")]
        [JsonProperty("desc")]
        [DefaultValue("")]
        public string Desc { get; set; }
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
        /// 路径
        /// </summary>
        [StringLength(2000)]
        [Description("路径")]
        [JsonProperty("path")]
        [DefaultValue("")]
        [NotMapped]
        public string Path { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Description("是否展开")]
        [JsonProperty("isLeaf")]
        [DefaultValue(false)]
        [NotMapped]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 上级字典
        /// </summary>
        [Description("上级字典")]
        [JsonProperty("parentDictionary")]
        [NotMapped]
        public Dictionary ParentDictionary { get; set; }
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
