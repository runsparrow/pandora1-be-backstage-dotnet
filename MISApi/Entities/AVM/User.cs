using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.AVM
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("AVM_User")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class User : BaseCacheEntity<User>
    {
        #region Property
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("#")]
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("name")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(255)]
        [Description("密码")]
        [JsonProperty("password")]
        public string Password { get; set; } = "";
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(255)]
        [Description("邮箱")]
        [JsonProperty("email")]
        public string Email { get; set; } = "";
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(255)]
        [Description("手机")]
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = "";
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        [JsonProperty("loginDateTime")]
        public DateTime LoginDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [StringLength(255)]
        [Description("最后登录IP")]
        [JsonProperty("loginIPAddress")]
        public string LoginIPAddress { get; set; } = "";
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
