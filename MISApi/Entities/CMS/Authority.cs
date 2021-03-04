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
        /// 身份Id
        /// </summary>
        [Description("身份Id")]
        [JsonProperty("identityId")]
        public int IdentityId { get; set; } = -1;
        /// <summary>
        /// 身份名称
        /// </summary>
        [StringLength(50)]
        [Description("身份名称")]
        [JsonProperty("identityName")]
        public string IdentityName { get; set; } = "";
        /// <summary>
        /// 国家代码
        /// </summary>
        [StringLength(50)]
        [Description("国家代码")]
        [JsonProperty("nationCode")]
        public string NationCode { get; set; } = "";
        /// <summary>
        /// 国家名称
        /// </summary>
        [StringLength(50)]
        [Description("国家名称")]
        [JsonProperty("nationName")]
        public string NationName { get; set; } = "";
        /// <summary>
        /// 省代码
        /// </summary>
        [StringLength(50)]
        [Description("省代码")]
        [JsonProperty("provinceCode")]
        public string ProvinceCode { get; set; } = "";
        /// <summary>
        /// 省名称
        /// </summary>
        [StringLength(50)]
        [Description("省名称")]
        [JsonProperty("provinceName")]
        public string ProvinceName { get; set; } = "";
        /// <summary>
        /// 城市代码
        /// </summary>
        [StringLength(50)]
        [Description("城市代码")]
        [JsonProperty("cityCode")]
        public string CityCode { get; set; } = "";
        /// <summary>
        /// 城市名称
        /// </summary>
        [StringLength(50)]
        [Description("城市名称")]
        [JsonProperty("cityName")]
        public string CityName { get; set; } = "";
        /// <summary>
        /// 区县代码
        /// </summary>
        [StringLength(50)]
        [Description("区县代码")]
        [JsonProperty("divisionCode")]
        public string DivisionCode { get; set; } = "";
        /// <summary>
        /// 区县名称
        /// </summary>
        [StringLength(50)]
        [Description("区县名称")]
        [JsonProperty("divisionName")]
        public string DivisionName { get; set; } = "";
        /// <summary>
        /// 单位Id
        /// </summary>
        [Description("单位Id")]
        [JsonProperty("unitId")]
        public int UnitId { get; set; } = -1;
        /// <summary>
        /// 单位名称
        /// </summary>
        [StringLength(50)]
        [Description("单位名称")]
        [JsonProperty("unitName")]
        public string UnitName { get; set; } = "";
        /// <summary>
        /// 科室Id
        /// </summary>
        [Description("科室Id")]
        [JsonProperty("officeId")]
        public int OfficeId { get; set; } = -1;
        /// <summary>
        /// 科室名称
        /// </summary>
        [StringLength(50)]
        [Description("科室名称")]
        [JsonProperty("officeName")]
        public string OfficeName { get; set; } = "";
        /// <summary>
        /// 职务Id
        /// </summary>
        [Description("职务Id")]
        [JsonProperty("dutyId")]
        public int DutyId { get; set; } = -1;
        /// <summary>
        /// 职务名称
        /// </summary>
        [StringLength(50)]
        [Description("职务名称")]
        [JsonProperty("dutyName")]
        public string DutyName { get; set; } = "";
        /// <summary>
        /// 工号
        /// </summary>
        [StringLength(50)]
        [Description("工号")]
        [JsonProperty("jobNo")]
        public string JobNo { get; set; } = "";
        /// <summary>
        /// 工号文件路径
        /// </summary>
        [StringLength(500)]
        [Description("工号文件路径")]
        [JsonProperty("jobUrl")]
        public string JobUrl { get; set; } = "";
        /// <summary>
        /// 证书
        /// </summary>
        [StringLength(50)]
        [Description("证书")]
        [JsonProperty("certificateNo")]
        public string CertificateNo { get; set; } = "";
        /// <summary>
        /// 证书文件路径
        /// </summary>
        [StringLength(500)]
        [Description("证书文件路径")]
        [JsonProperty("certificateUrl")]
        public string CertificateUrl { get; set; } = "";
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(50)]
        [Description("身份证")]
        [JsonProperty("idCard")]
        public string IdCard { get; set; } = "";
        /// <summary>
        /// 身份证正面
        /// </summary>
        [StringLength(500)]
        [Description("身份证正面")]
        [JsonProperty("idCardFUrl")]
        public string IdCardFUrl { get; set; } = "";
        /// <summary>
        /// 身份证背面
        /// </summary>
        [StringLength(500)]
        [Description("身份证背面")]
        [JsonProperty("idCardBUrl")]
        public string IdCardBUrl { get; set; } = "";
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(50)]
        [Description("手机")]
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = "";
        /// <summary>
        /// 邮件
        /// </summary>
        [StringLength(50)]
        [Description("邮件")]
        [JsonProperty("email")]
        public string Email { get; set; } = "";
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
