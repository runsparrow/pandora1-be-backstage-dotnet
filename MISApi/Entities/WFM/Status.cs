using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.WFM
{
    /// <summary>
    /// 状态
    /// </summary>
    [Table("WFM_Status")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Status : BaseCacheEntity<Status>
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
        [Description("父节点Id")]
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
        [Description("键值")]
        [JsonProperty("value")]
        [DefaultValue(0)]
        public int Value { get; set; } = 0;
        /// <summary>
        /// 4000
        /// </summary>
        [StringLength(4000)]
        [Description("描述")]
        [JsonProperty("desc")]
        [DefaultValue("")]
        public string Desc { get; set; } = "";
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
        [DefaultValue(-1)]
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
        [DefaultValue(-1)]
        public int EditUserId { get; set; } = -1;
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 节点路径
        /// </summary>
        [StringLength(255)]
        [Description("节点路径")]
        [JsonProperty("path")]
        [DefaultValue("")]
        [NotMapped]
        public string Path { get; set; } = "";
        /// <summary>
        /// 上级状态
        /// </summary>
        [Description("上级状态")]
        [JsonProperty("parentStatus")]
        [NotMapped]
        public Status ParentStatus { get; set; }
        #endregion
    }
}
