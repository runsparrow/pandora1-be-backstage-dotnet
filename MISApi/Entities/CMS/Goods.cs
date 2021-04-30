using MISApi.Entities.WFM;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 商品
    /// </summary>
    [Table("CMS_Goods")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Goods : BaseCacheEntity<Goods>
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
        /// 名称
        /// </summary>
        [StringLength(255)]
        [Description("名称")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 商品编号
        /// </summary>
        [StringLength(50)]
        [Description("商品编号")]
        [JsonProperty("goodsNo")]
        [DefaultValue("")]
        public string GoodsNo { get; set; } = "";
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(255)]
        [Description("标签")]
        [JsonProperty("tags")]
        [DefaultValue("")]
        public string Tags { get; set; } = "";
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(2000)]
        [Description("描述")]
        [JsonProperty("desc")]
        [DefaultValue("")]
        public string Desc { get; set; } = "";
        /// <summary>
        /// 授权说明
        /// </summary>
        [StringLength(2000)]
        [Description("授权说明")]
        [JsonProperty("authDesc")]
        [DefaultValue("")]
        public string AuthDesc { get; set; } = "";
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
        /// 路径
        /// </summary>
        [StringLength(500)]
        [Description("路径")]
        [JsonProperty("url")]
        [DefaultValue("")]
        public string Url { get; set; } = "";
        /// <summary>
        /// 扩展名
        /// </summary>
        [StringLength(50)]
        [Description("扩展名")]
        [JsonProperty("ext")]
        [DefaultValue("")]
        public string Ext { get; set; } = "";
        /// <summary>
        /// 分辨率
        /// </summary>
        [StringLength(50)]
        [Description("分辨率")]
        [JsonProperty("dpi")]
        [DefaultValue("")]
        public string DPI { get; set; } = "";
        /// <summary>
        /// 尺寸
        /// </summary>
        [StringLength(50)]
        [Description("尺寸")]
        [JsonProperty("ratio")]
        [DefaultValue("")]
        public string Ratio { get; set; } = "";
        /// <summary>
        /// 颜色
        /// </summary>
        [StringLength(50)]
        [Description("颜色")]
        [JsonProperty("rgb")]
        [DefaultValue("")]
        public string RGB { get; set; } = "";
        /// <summary>
        /// 大小
        /// </summary>
        [StringLength(50)]
        [Description("大小")]
        [JsonProperty("size")]
        [DefaultValue("")]
        public string Size { get; set; } = "";
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        [JsonProperty("level")]
        [DefaultValue(0)]
        public int Level { get; set; } = 0;
        /// <summary>
        /// 价格
        /// </summary>
        [Description("价格")]
        [JsonProperty("price")]
        [DefaultValue(0)]
        public decimal Price { get; set; } = 0;
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        [JsonProperty("quantity")]
        [DefaultValue(0)]
        public int Quantity { get; set; } = 0;
        /// <summary>
        /// 库存上限
        /// </summary>
        [Description("库存上限")]
        [JsonProperty("maxStock")]
        [DefaultValue(0)]
        public int MaxStock { get; set; } = 0;
        /// <summary>
        /// 库存下限
        /// </summary>
        [Description("库存下限")]
        [JsonProperty("minStock")]
        [DefaultValue(0)]
        public int MinStock { get; set; } = 0;
        /// <summary>
        /// 下载次数
        /// </summary>
        [Description("下载次数")]
        [JsonProperty("downCount")]
        [DefaultValue(0)]
        public int DownCount { get; set; } = 0;
        /// <summary>
        /// 收藏次数
        /// </summary>
        [Description("收藏次数")]
        [JsonProperty("collectCount")]
        [DefaultValue(0)]
        public int CollectCount { get; set; } = 0;
        /// <summary>
        /// 购买次数
        /// </summary>
        [Description("购买次数")]
        [JsonProperty("buyCount")]
        [DefaultValue(0)]
        public int BuyCount { get; set; } = 0;
        /// <summary>
        /// 所有权用户Id
        /// </summary>
        [Description("所有权用户Id")]
        [JsonProperty("ownerId")]
        [DefaultValue(-1)]
        public int OwnerId { get; set; } = -1;
        /// <summary>
        /// 发布时间
        /// </summary>
        [Description("发布时间")]
        [JsonProperty("publicDateTime")]
        public DateTime PublicDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        [JsonProperty("finalDateTime")]
        public DateTime FinalDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(255)]
        [Description("备注")]
        [JsonProperty("remark")]
        [DefaultValue("")]
        public string Remark { get; set; } = "";
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
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        [NotMapped]
        public Status Status { get; set; }
        #endregion
    }
}
