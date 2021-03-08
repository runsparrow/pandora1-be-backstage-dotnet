﻿using MISApi.Entities.WFM;
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
        /// 键名
        /// </summary>
        [StringLength(255)]
        [Description("键名")]
        [JsonProperty("key")]
        public string Key { get; set; } = "";
        /// <summary>
        /// 键值
        /// </summary>
        [StringLength(255)]
        [Description("键值")]
        [JsonProperty("value")]
        public string Value { get; set; } = "";
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(255)]
        [Description("描述")]
        [JsonProperty("desc")]
        public string Desc { get; set; } = "";
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
