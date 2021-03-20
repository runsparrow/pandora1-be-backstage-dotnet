using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("CMS_Member")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Member : BaseCacheEntity<Member>
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
        /// 用户名
        /// </summary>
        [StringLength(255)]
        [Description("用户名")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(255)]
        [Description("密码")]
        [JsonProperty("password")]
        [DefaultValue("")]
        public string Password { get; set; } = "";
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(255)]
        [Description("邮箱")]
        [JsonProperty("email")]
        [DefaultValue("")]
        public string Email { get; set; } = "";
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(255)]
        [Description("手机")]
        [JsonProperty("mobile")]
        [DefaultValue("")]
        public string Mobile { get; set; } = "";
        /// <summary>
        /// 实名
        /// </summary>
        [StringLength(255)]
        [Description("实名")]
        [JsonProperty("realName")]
        [DefaultValue("")]
        public string RealName { get; set; } = "";
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(255)]
        [Description("身份证")]
        [JsonProperty("idCard")]
        [DefaultValue("")]
        public string IdCard { get; set; } = "";
        /// <summary>
        /// 生日
        /// </summary>
        [Description("生日")]
        [JsonProperty("birthdate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime Birthdate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 性别
        /// </summary>
        [StringLength(1)]
        [Description("性别")]
        [JsonProperty("gender")]
        [DefaultValue("")]
        public string Gender { get; set; } = "";
        /// <summary>
        /// 归类Id
        /// </summary>
        [Description("归类Id")]
        [JsonProperty("classifyId")]
        [DefaultValue(-1)]
        public int ClassifyId { get; set; } = -1;
        /// <summary>
        /// 归类名称
        /// </summary>
        [StringLength(255)]
        [Description("归类名称")]
        [JsonProperty("classifyName")]
        [DefaultValue("")]
        public string ClassifyName { get; set; } = "";
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        [JsonProperty("level")]
        [DefaultValue(0)]
        public int Level { get; set; } = 0;
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; } = "";
        /// <summary>
        /// 注册时间
        /// </summary>
        [Description("注册时间")]
        [JsonProperty("registDateTime")]
        public DateTime RegistDateTime { get; set; } = DateTime.MinValue;
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
        [DefaultValue("")]
        public string LoginIPAddress { get; set; } = "";
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
