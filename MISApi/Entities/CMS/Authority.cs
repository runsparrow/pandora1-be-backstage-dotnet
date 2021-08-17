using MISApi.Entities.AVM;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        [Description("会员Id")]
        [JsonProperty("memberId")]
        [DefaultValue(-1)]
        public int? MemberId { get; set; }
        /// <summary>
        /// 会员名
        /// </summary>
        [StringLength(255)]
        [Description("会员名")]
        [JsonProperty("memberName")]
        [DefaultValue("")]
        public string MemberName { get; set; }
        /// <summary>
        /// 实名
        /// </summary>
        [StringLength(255)]
        [Description("实名")]
        [JsonProperty("realName")]
        [DefaultValue("")]
        public string RealName { get; set; }
        /// <summary>
        /// 身份Id
        /// </summary>
        [Description("身份Id")]
        [JsonProperty("identityId")]
        [DefaultValue(-1)]
        public int? IdentityId { get; set; }
        /// <summary>
        /// 认证序号
        /// </summary>
        [Description("认证序号")]
        [JsonProperty("authorityIndex")]
        [DefaultValue(-1)]
        public int? AuthorityIndex { get; set; }
        /// <summary>
        /// 身份名称
        /// </summary>
        [StringLength(50)]
        [Description("身份名称")]
        [JsonProperty("identityName")]
        [DefaultValue("")]
        public string IdentityName { get; set; }
        /// <summary>
        /// 国家代码
        /// </summary>
        [StringLength(50)]
        [Description("国家代码")]
        [JsonProperty("nationCode")]
        [DefaultValue("")]
        public string NationCode { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        [StringLength(50)]
        [Description("国家名称")]
        [JsonProperty("nationName")]
        [DefaultValue("")]
        public string NationName { get; set; }
        /// <summary>
        /// 省代码
        /// </summary>
        [StringLength(50)]
        [Description("省代码")]
        [JsonProperty("provinceCode")]
        [DefaultValue("")]
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        [StringLength(50)]
        [Description("省名称")]
        [JsonProperty("provinceName")]
        [DefaultValue("")]
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市代码
        /// </summary>
        [StringLength(50)]
        [Description("城市代码")]
        [JsonProperty("cityCode")]
        [DefaultValue("")]
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        [StringLength(50)]
        [Description("城市名称")]
        [JsonProperty("cityName")]
        [DefaultValue("")]
        public string CityName { get; set; }
        /// <summary>
        /// 区县代码
        /// </summary>
        [StringLength(50)]
        [Description("区县代码")]
        [JsonProperty("divisionCode")]
        [DefaultValue("")]
        public string DivisionCode { get; set; }
        /// <summary>
        /// 区县名称
        /// </summary>
        [StringLength(50)]
        [Description("区县名称")]
        [JsonProperty("divisionName")]
        [DefaultValue("")]
        public string DivisionName { get; set; }
        /// <summary>
        /// 单位Id
        /// </summary>
        [Description("单位Id")]
        [JsonProperty("unitId")]
        [DefaultValue(-1)]
        public int? UnitId { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [StringLength(50)]
        [Description("单位名称")]
        [JsonProperty("unitName")]
        [DefaultValue("")]
        public string UnitName { get; set; }
        /// <summary>
        /// 科室Id
        /// </summary>
        [Description("科室Id")]
        [JsonProperty("officeId")]
        [DefaultValue(-1)]
        public int? OfficeId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [StringLength(50)]
        [Description("科室名称")]
        [JsonProperty("officeName")]
        [DefaultValue("")]
        public string OfficeName { get; set; }
        /// <summary>
        /// 职务Id
        /// </summary>
        [Description("职务Id")]
        [JsonProperty("dutyId")]
        [DefaultValue(-1)]
        public int? DutyId { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        [StringLength(50)]
        [Description("职务名称")]
        [JsonProperty("dutyName")]
        [DefaultValue("")]
        public string DutyName { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [StringLength(50)]
        [Description("工号")]
        [JsonProperty("jobNo")]
        [DefaultValue("")]
        public string JobNo { get; set; }
        /// <summary>
        /// 工号文件路径
        /// </summary>
        [StringLength(500)]
        [Description("工号文件路径")]
        [JsonProperty("jobUrl")]
        [DefaultValue("")]
        public string JobUrl { get; set; }
        /// <summary>
        /// 证书
        /// </summary>
        [StringLength(50)]
        [Description("证书")]
        [JsonProperty("certificateNo")]
        [DefaultValue("")]
        public string CertificateNo { get; set; }
        /// <summary>
        /// 证书文件路径
        /// </summary>
        [StringLength(500)]
        [Description("证书文件路径")]
        [JsonProperty("certificateUrl")]
        [DefaultValue("")]
        public string CertificateUrl { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(50)]
        [Description("身份证")]
        [JsonProperty("idCard")]
        [DefaultValue("")]
        public string IdCard { get; set; }
        /// <summary>
        /// 身份证正面
        /// </summary>
        [StringLength(500)]
        [Description("身份证正面")]
        [JsonProperty("idCardFUrl")]
        [DefaultValue("")]
        public string IdCardFUrl { get; set; }
        /// <summary>
        /// 身份证背面
        /// </summary>
        [StringLength(500)]
        [Description("身份证背面")]
        [JsonProperty("idCardBUrl")]
        [DefaultValue("")]
        public string IdCardBUrl { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(50)]
        [Description("手机")]
        [JsonProperty("mobile")]
        [DefaultValue("")]
        public string Mobile { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        [StringLength(50)]
        [Description("邮件")]
        [JsonProperty("email")]
        [DefaultValue("")]
        public string Email { get; set; }
        /// <summary>
        /// 支付宝
        /// </summary>
        [StringLength(255)]
        [Description("支付宝")]
        [JsonProperty("alipay")]
        [DefaultValue("")]
        public string Alipay { get; set; }
        /// <summary>
        /// 微信支付
        /// </summary>
        [StringLength(255)]
        [Description("微信支付")]
        [JsonProperty("wechatPay")]
        [DefaultValue("")]
        public string WechatPay { get; set; }
        /// <summary>
        /// 申请人Id
        /// </summary>
        [Description("申请人Id")]
        [JsonProperty("applierId")]
        [DefaultValue(-1)]
        public int? ApplierId { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        [StringLength(255)]
        [Description("申请人姓名")]
        [JsonProperty("applierName")]
        [DefaultValue("")]
        public string ApplierName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        [Description("申请时间")]
        [JsonProperty("applierDate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? ApplierDate { get; set; }
        /// <summary>
        /// 审批人Id
        /// </summary>
        [Description("审批人Id")]
        [JsonProperty("approverId")]
        [DefaultValue(-1)]
        public int? ApproverId { get; set; }
        /// <summary>
        /// 审批人姓名
        /// </summary>
        [StringLength(255)]
        [Description("审批人姓名")]
        [JsonProperty("approverName")]
        [DefaultValue("")]
        public string ApproverName { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        [Description("审批时间")]
        [JsonProperty("approverDate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? ApproverDate { get; set; }
        /// <summary>
        /// 审批意见
        /// </summary>
        [StringLength(255)]
        [Description("审批意见")]
        [JsonProperty("approverDesc")]
        [DefaultValue("")]
        public string ApproverDesc { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; }
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
        /// 申请人
        /// </summary>
        [Description("申请人")]
        [JsonProperty("applier")]
        [NotMapped]
        public Member Applier { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        [Description("审批人")]
        [JsonProperty("approver")]
        [NotMapped]
        public User Approver { get; set; }
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
