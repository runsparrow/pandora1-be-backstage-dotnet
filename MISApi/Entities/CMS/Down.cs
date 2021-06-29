using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 下载
    /// </summary>
    [Table("CMS_Down")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Down : BaseCacheEntity<Down>
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
        /// 作者Id
        /// </summary>
        [Description("作者Id")]
        [JsonProperty("ownerId")]
        [DefaultValue(-1)]
        public int OwnerId { get; set; } = -1;
        /// <summary>
        /// 作者姓名
        /// </summary>
        [StringLength(255)]
        [Description("作者姓名")]
        [JsonProperty("ownerName")]
        [DefaultValue("")]
        public string OwnerName { get; set; } = "";
        /// <summary>
        /// 下载时间
        /// </summary>
        [Description("下载时间")]
        [JsonProperty("downDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
        public DateTime DownDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否下载成功
        /// </summary>
        [Description("是否下载成功")]
        [JsonProperty("downResult")]
        [DefaultValue(false)]
        public bool DownResult { get; set; } = false;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [JsonProperty("createDateTime")]
        [DefaultValue("0001/1/1 0:00:00")]
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
        [DefaultValue("0001/1/1 0:00:00")]
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
        /// <summary>
        /// 作者
        /// </summary>
        [Description("作者")]
        [JsonProperty("owner")]
        [NotMapped]
        public Member Owner { get; set; }
        #endregion
    }
}
