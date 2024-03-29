﻿using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 会员
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
        /// 会员名
        /// </summary>
        [StringLength(255)]
        [Description("会员名")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(255)]
        [Description("密码")]
        [JsonProperty("password")]
        [DefaultValue("")]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(255)]
        [Description("邮箱")]
        [JsonProperty("email")]
        [DefaultValue("")]
        public string Email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(255)]
        [Description("手机")]
        [JsonProperty("mobile")]
        [DefaultValue("")]
        public string Mobile { get; set; }
        /// <summary>
        /// 实名
        /// </summary>
        [StringLength(255)]
        [Description("实名")]
        [JsonProperty("realName")]
        [DefaultValue("")]
        public string RealName { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        [StringLength(500)]
        [Description("头像路径")]
        [JsonProperty("avatarUrl")]
        [DefaultValue("")]
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(255)]
        [Description("身份证")]
        [JsonProperty("idCard")]
        [DefaultValue("")]
        public string IdCard { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Description("生日")]
        [JsonProperty("birthdate")]
        //[DefaultValue(typeof(DateTime), "0001-01-01")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [StringLength(1)]
        [Description("性别")]
        [JsonProperty("gender")]
        [DefaultValue("")]
        public string Gender { get; set; }
        /// <summary>
        /// 归类Id
        /// </summary>
        [Description("归类Id")]
        [JsonProperty("classifyId")]
        [DefaultValue(-1)]
        public int? ClassifyId { get; set; }
        /// <summary>
        /// 归类名称
        /// </summary>
        [StringLength(255)]
        [Description("归类名称")]
        [JsonProperty("classifyName")]
        [DefaultValue("")]
        public string ClassifyName { get; set; }
        /// <summary>
        /// 等级有效期
        /// </summary>
        [Description("等级有效期")]
        [JsonProperty("levelDeadline")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? LevelDeadline { get; set; }
        /// <summary>
        /// 可下载次数
        /// </summary>
        [Description("可下载次数")]
        [JsonProperty("downCount")]
        [DefaultValue(0)]
        public int? DownCount { get; set; }
        /// <summary>
        /// 可购买次数
        /// </summary>
        [Description("可购买次数")]
        [JsonProperty("buyCount")]
        [DefaultValue(0)]
        public int? BuyCount { get; set; }
        /// <summary>
        /// 可上传次数
        /// </summary>
        [Description("可上传次数")]
        [JsonProperty("uploadCount")]
        [DefaultValue(0)]
        public int? UploadCount { get; set; }
        /// <summary>
        /// 剩余下载次数
        /// </summary>
        [Description("剩余下载次数")]
        [JsonProperty("reDownCount")]
        [DefaultValue(0)]
        public int? ReDownCount { get; set; }
        /// <summary>
        /// 剩余购买次数
        /// </summary>
        [Description("剩余购买次数")]
        [JsonProperty("reBuyCount")]
        [DefaultValue(0)]
        public int? ReBuyCount { get; set; }
        /// <summary>
        /// 剩余上传次数
        /// </summary>
        [Description("剩余上传次数")]
        [JsonProperty("reUploadCount")]
        [DefaultValue(0)]
        public int? ReUploadCount { get; set; }
        /// <summary>
        /// 是否认证
        /// </summary>
        [Description("是否认证")]
        [JsonProperty("isAuthority")]
        public bool? IsAuthority { get; set; }
        /// <summary>
        /// 是否自有用户
        /// </summary>
        [Description("是否自有用户")]
        [JsonProperty("isSelf")]
        public bool? IsSelf { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Description("注册时间")]
        [JsonProperty("registDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? RegistDateTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        [JsonProperty("loginDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? LoginDateTime { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [StringLength(255)]
        [Description("最后登录IP")]
        [JsonProperty("loginIPAddress")]
        [DefaultValue("")]
        public string LoginIPAddress { get; set; }
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
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        [JsonProperty("genderName")]
        [DefaultValue("")]
        [NotMapped]
        public string GenderName
        {
            get
            {
                if(Gender == null)
                {
                    return "";
                }
                switch (Gender.ToLower())
                {
                    case "f":
                        return "女";
                    case "m":
                        return "男";
                    case "s":
                        return "保密";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        [JsonProperty("level")]
        [DefaultValue(0)]
        [NotMapped]
        public int Level
        {
            get
            {
                if(LevelDeadline >= DateTime.Now)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 等级名称
        /// </summary>
        [Description("等级名称")]
        [JsonProperty("levelName")]
        [NotMapped]
        public string LevelName
        {
            get
            {
                switch (Level)
                {
                    case 1:
                        return "付费用户";
                    default:
                        return "普通用户";
                }
            }
        }
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
