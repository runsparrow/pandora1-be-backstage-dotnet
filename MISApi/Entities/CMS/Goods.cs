using MISApi.Entities.AVM;
using MISApi.Entities.WFM;
using MISApi.Tools;
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
        public string Name { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [StringLength(50)]
        [Description("商品编号")]
        [JsonProperty("goodsNo")]
        [DefaultValue("")]
        public string GoodsNo { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(255)]
        [Description("标签")]
        [JsonProperty("tags")]
        [DefaultValue("")]
        public string Tags { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(2000)]
        [Description("描述")]
        [JsonProperty("desc")]
        [DefaultValue("")]
        public string Desc { get; set; }
        /// <summary>
        /// 授权说明
        /// </summary>
        [StringLength(2000)]
        [Description("授权说明")]
        [JsonProperty("authDesc")]
        [DefaultValue("")]
        public string AuthDesc { get; set; }
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
        /// 路径
        /// </summary>
        [StringLength(255)]
        [Description("路径")]
        [JsonProperty("url")]
        [DefaultValue("")]
        public string Url { get; set; }
        /// <summary>
        /// 压缩包路径
        /// </summary>
        [StringLength(255)]
        [Description("压缩包路径")]
        [JsonProperty("zipUrl")]
        [DefaultValue("")]
        public string ZipUrl { get; set; }
        /// <summary>
        /// 封面路径
        /// </summary>
        [StringLength(255)]
        [Description("封面路径")]
        [JsonProperty("coverUrl")]
        [DefaultValue("")]
        public string CoverUrl { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        [StringLength(50)]
        [Description("扩展名")]
        [JsonProperty("ext")]
        [DefaultValue("")]
        public string Ext { get; set; }
        /// <summary>
        /// 分辨率
        /// </summary>
        [StringLength(50)]
        [Description("分辨率")]
        [JsonProperty("dpi")]
        [DefaultValue("")]
        public string DPI { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        [StringLength(50)]
        [Description("尺寸")]
        [JsonProperty("ratio")]
        [DefaultValue("")]
        public string Ratio { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        [StringLength(50)]
        [Description("颜色")]
        [JsonProperty("rgb")]
        [DefaultValue("")]
        public string RGB { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [StringLength(50)]
        [Description("大小")]
        [JsonProperty("size")]
        [DefaultValue("")]
        public string Size { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        [JsonProperty("level")]
        [DefaultValue(0)]
        public int? Level { get; set; }
        /// <summary>
        /// 是否图片
        /// </summary>
        [Description("是否图片")]
        [JsonProperty("isImage")]
        [DefaultValue(true)]
        public bool? IsImage { get; set; }
        /// <summary>
        /// 是否原创
        /// </summary>
        [Description("是否原创")]
        [JsonProperty("isOriginal")]
        [DefaultValue(true)]
        public bool? IsOriginal { get; set; }
        /// <summary>
        /// 导航Id
        /// </summary>
        [Description("导航Id")]
        [JsonProperty("navigationId")]
        [DefaultValue(-1)]
        public int? NavigationId { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        [StringLength(255)]
        [Description("导航名称")]
        [JsonProperty("navigationName")]
        [DefaultValue("")]
        public string NavigationName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Description("价格")]
        [JsonProperty("price")]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        [JsonProperty("quantity")]
        [DefaultValue(0)]
        public int? Quantity { get; set; }
        /// <summary>
        /// 库存上限
        /// </summary>
        [Description("库存上限")]
        [JsonProperty("maxStock")]
        [DefaultValue(0)]
        public int? MaxStock { get; set; }
        /// <summary>
        /// 库存下限
        /// </summary>
        [Description("库存下限")]
        [JsonProperty("minStock")]
        [DefaultValue(0)]
        public int? MinStock { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        [Description("下载次数")]
        [JsonProperty("downCount")]
        [DefaultValue(0)]
        public int? DownCount { get; set; }
        /// <summary>
        /// 收藏次数
        /// </summary>
        [Description("收藏次数")]
        [JsonProperty("collectCount")]
        [DefaultValue(0)]
        public int? CollectCount { get; set; }
        /// <summary>
        /// 购买次数
        /// </summary>
        [Description("购买次数")]
        [JsonProperty("buyCount")]
        [DefaultValue(0)]
        public int? BuyCount { get; set; }
        /// <summary>
        /// 所有权用户Id
        /// </summary>
        [Description("所有权用户Id")]
        [JsonProperty("ownerId")]
        [DefaultValue(-1)]
        public int? OwnerId { get; set; } 
        /// <summary>
        /// 所有权用户名
        /// </summary>
        [StringLength(255)]
        [Description("所有权用户名")]
        [JsonProperty("ownerName")]
        [DefaultValue("")]
        public string OwnerName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Description("发布时间")]
        [JsonProperty("publicDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? PublicDateTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        [JsonProperty("finalDateTime")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        public DateTime? FinalDateTime { get; set; }
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
        /// <summary>B
        /// 状态数值
        /// </summary>
        [Description("状态数值")]
        [JsonProperty("statusValue")]
        [DefaultValue(0)]
        public int? StatusValue { get; set; }
        #endregion

        #region Not Mapped Property
        /// <summary>
        /// 状态键名
        /// </summary>
        [StringLength(255)]
        [Description("状态键名")]
        [JsonProperty("statusKey")]
        [DefaultValue("")]
        [NotMapped]
        public string StatusKey { get; set; }
        /// <summary>
        /// 控件用Tags
        /// </summary>
        [Description("控件用Tags")]
        [JsonProperty("pluginTags")]
        [DefaultValue("")]
        [NotMapped]
        public string PluginTags
        {
            get
            {
                if(Tags != null && Tags.Length > 2)
                {
                    return Tags.Substring(1, Tags.Length-2);
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 图片完整路径
        /// </summary>
        [Description("图片完整路径")]
        [JsonProperty("fullUrl")]
        [NotMapped]
        public string FullUrl
        {
            get
            {
                return $@"{ConfigurationHelper.GetConnectionString("ImageHost")}{Url}";
            }
        }
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
