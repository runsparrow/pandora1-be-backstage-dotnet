using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISApi.Entities.CMS
{
    /// <summary>
    /// 文件系统
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public partial class File
    {
        #region Not Mapped Property
        /// <summary>
        /// 上传记录
        /// </summary>
        [Description("上传记录")]
        [JsonProperty("upload")]
        [NotMapped]
        public Upload Upload { get; set; }
        /// <summary>
        /// 下载记录
        /// </summary>
        [Description("下载记录")]
        [JsonProperty("down")]
        [NotMapped]
        public Down Down { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        [JsonProperty("goods")]
        [NotMapped]
        public Goods Goods { get; set; }
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        [JsonProperty("member")]
        [NotMapped]
        public Member Member { get; set; }
        #endregion
    }
}
