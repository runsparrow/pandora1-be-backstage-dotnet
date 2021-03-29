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
    /// 评论
    /// </summary>
    [Table("CMS_Discuss")]
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class Discuss : BaseCacheEntity<Discuss>
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
        /// 文章Id
        /// </summary>
        [Description("文章Id")]
        [JsonProperty("articleId")]
        [DefaultValue(-1)]
        public int ArticleId { get; set; } = -1;
        /// <summary>
        /// 文章标题
        /// </summary>
        [StringLength(255)]
        [Description("文章标题")]
        [JsonProperty("articleTitle")]
        [DefaultValue("")]
        public string ArticleTitle { get; set; } = "";
        /// <summary>
        /// 评论人Id
        /// </summary>
        [Description("评论人Id")]
        [JsonProperty("discussId")]
        [DefaultValue(-1)]
        public int DiscussId { get; set; } = -1;
        /// <summary>
        /// 评论人姓名
        /// </summary>
        [StringLength(255)]
        [Description("评论人姓名")]
        [JsonProperty("discussName")]
        [DefaultValue("")]
        public string DiscussName { get; set; } = "";
        /// <summary>
        /// 评论时间
        /// </summary>
        [Description("评论时间")]
        [JsonProperty("discussDateTime")]
        public DateTime DiscussDateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 审批人Id
        /// </summary>
        [Description("审批人Id")]
        [JsonProperty("approverId")]
        [DefaultValue(-1)]
        public int ApproverId { get; set; } = -1;
        /// <summary>
        /// 审批人姓名
        /// </summary>
        [StringLength(255)]
        [Description("审批人姓名")]
        [JsonProperty("approverName")]
        [DefaultValue("")]
        public string ApproverName { get; set; } = "";
        /// <summary>
        /// 审批时间
        /// </summary>
        [Description("审批时间")]
        [JsonProperty("approverDate")]
        public DateTime ApproverDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 审批意见
        /// </summary>
        [StringLength(255)]
        [Description("审批意见")]
        [JsonProperty("approverDesc")]
        [DefaultValue("")]
        public string ApproverDesc { get; set; } = "";
        /// <summary>
        /// 内容
        /// </summary>
        [StringLength(int.MaxValue)]
        [Description("内容")]
        [JsonProperty("content")]
        [DefaultValue("")]
        public string Content { get; set; } = "";
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
        /// 文章
        /// </summary>
        [Description("文章")]
        [JsonProperty("article")]
        [NotMapped]
        public Article Article { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [Description("评论人")]
        [JsonProperty("discussant")]
        [NotMapped]
        public Member Discussant { get; set; }
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
