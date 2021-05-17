using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.ASM
{
    /// <summary>
    /// 医院
    /// </summary>
    [Table("ASM_Hospital")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Hospital : BaseCacheEntity<Hospital>
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
        [StringLength(255)]
        [Description("键值")]
        [JsonProperty("value")]
        [DefaultValue("")]
        public string Value { get; set; } = "";
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(255)]
        [Description("描述")]
        [JsonProperty("desc")]
        [DefaultValue("")]
        public string Desc { get; set; } = "";
        /// <summary>
        /// 国家代码
        /// </summary>
        [StringLength(50)]
        [Description("国家代码")]
        [JsonProperty("nationCode")]
        [DefaultValue("")]
        public string NationCode { get; set; } = "";
        /// <summary>
        /// 国家名称
        /// </summary>
        [StringLength(50)]
        [Description("国家名称")]
        [JsonProperty("nationName")]
        [DefaultValue("")]
        public string NationName { get; set; } = "";
        /// <summary>
        /// 省代码
        /// </summary>
        [StringLength(50)]
        [Description("省代码")]
        [JsonProperty("provinceCode")]
        [DefaultValue("")]
        public string ProvinceCode { get; set; } = "";
        /// <summary>
        /// 省名称
        /// </summary>
        [StringLength(50)]
        [Description("省名称")]
        [JsonProperty("provinceName")]
        [DefaultValue("")]
        public string ProvinceName { get; set; } = "";
        /// <summary>
        /// 城市代码
        /// </summary>
        [StringLength(50)]
        [Description("城市代码")]
        [JsonProperty("cityCode")]
        [DefaultValue("")]
        public string CityCode { get; set; } = "";
        /// <summary>
        /// 城市名称
        /// </summary>
        [StringLength(50)]
        [Description("城市名称")]
        [JsonProperty("cityName")]
        [DefaultValue("")]
        public string CityName { get; set; } = "";
        /// <summary>
        /// 区县代码
        /// </summary>
        [StringLength(50)]
        [Description("区县代码")]
        [JsonProperty("divisionCode")]
        [DefaultValue("")]
        public string DivisionCode { get; set; } = "";
        /// <summary>
        /// 区县名称
        /// </summary>
        [StringLength(50)]
        [Description("区县名称")]
        [JsonProperty("divisionName")]
        [DefaultValue("")]
        public string DivisionName { get; set; } = "";
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
        /// 级别Id
        /// </summary>
        [Description("级别Id")]
        [JsonProperty("levelId")]
        [DefaultValue(-1)]
        public int LevelId { get; set; } = -1;
        /// <summary>
        /// 级别名称
        /// </summary>
        [StringLength(255)]
        [Description("级别名称")]
        [JsonProperty("levelName")]
        [DefaultValue("")]
        public string LevelName { get; set; } = "";
        /// <summary>
        /// 是否公立
        /// </summary>
        [Description("是否公立")]
        [JsonProperty("isGeneral")]
        [DefaultValue(false)]
        public bool IsGeneral { get; set; } = false;
        /// <summary>
        /// 是否专科
        /// </summary>
        [Description("是否专科")]
        [JsonProperty("isSpecial")]
        [DefaultValue(false)]
        public bool IsSpecial { get; set; } = false;
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(255)]
        [Description("地址")]
        [JsonProperty("address")]
        [DefaultValue("")]
        public string Address { get; set; } = "";
        /// <summary>
        /// 总计
        /// </summary>
        [StringLength(50)]
        [Description("总计")]
        [JsonProperty("phone")]
        [DefaultValue("")]
        public string Phone { get; set; } = "";
        /// <summary>
        /// 床位数量
        /// </summary>
        [Description("床位数量")]
        [JsonProperty("bedQuantity")]
        [DefaultValue(0)]
        public int BedQuantity { get; set; } = 0;
        /// <summary>
        /// 医生数量
        /// </summary>
        [Description("医生数量")]
        [JsonProperty("doctorQuantity")]
        [DefaultValue(0)]
        public int DoctorQuantity { get; set; } = 0;
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
        /// 路径
        /// </summary>
        [StringLength(2000)]
        [Description("路径")]
        [JsonProperty("path")]
        [DefaultValue("")]
        [NotMapped]
        public string Path { get; set; } = "";
        /// <summary>
        /// 上级医院
        /// </summary>
        [Description("上级医院")]
        [JsonProperty("parentHospital")]
        [NotMapped]
        public Hospital ParentHospital { get; set; }
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
