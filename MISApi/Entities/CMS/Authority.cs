using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 认证
    /// </summary>
    [Table("CMS_Authority")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Authority : BaseCacheEntity<Authority>
    {
        #region Property
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("#")]
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = -1;
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("userName")]
        public string UserName { get; set; } = "";
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
