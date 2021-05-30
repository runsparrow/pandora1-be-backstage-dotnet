using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 收藏
    /// </summary>
    [Table("CMS_Collect")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Collect : BaseCacheEntity<Collect>
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
        public int MemberId { get; set; } = -1;
        /// <summary>
        /// 会员姓名
        /// </summary>
        [StringLength(255)]
        [Description("会员姓名")]
        [JsonProperty("memberName")]
        [DefaultValue("")]
        public string MemberName { get; set; } = "";
        /// <summary>
        /// 商品Id
        /// </summary>
        [Description("商品Id")]
        [JsonProperty("goodsId")]
        [DefaultValue(-1)]
        public int GoodsId { get; set; } = -1;
        /// <summary>
        /// 商品名称
        /// </summary>
        [StringLength(255)]
        [Description("商品名称")]
        [JsonProperty("goodsName")]
        [DefaultValue("")]
        public string GoodsName { get; set; } = "";
        /// <summary>
        /// 商品路径
        /// </summary>
        [StringLength(500)]
        [Description("商品路径")]
        [JsonProperty("goodsUrl")]
        [DefaultValue("")]
        public string GoodsUrl { get; set; } = "";
        /// <summary>
        /// 收藏时间
        /// </summary>
        [Description("收藏时间")]
        [JsonProperty("collectDateTime")]
        public DateTime CollectDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
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
        public DateTime EditDateTime { get; set; } = DateTime.Now;
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
        /// 会员
        /// </summary>
        [Description("会员")]
        [JsonProperty("member")]
        [NotMapped]
        public Member Member { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [JsonProperty("goods")]
        [NotMapped]
        public Goods Goods { get; set; }
        #endregion
    }
}
