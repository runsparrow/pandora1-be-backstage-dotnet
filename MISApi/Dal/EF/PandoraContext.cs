using Microsoft.EntityFrameworkCore;
using MISApi.Tools;

namespace MISApi.Dal.EF
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PandoraContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigurationHelper.GetConnectionString("PandoraContext"), ServerVersion.FromString("5..7.27"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region ASM
        /// <summary>
        /// 数据字典
        /// </summary>
        public virtual DbSet<Entities.ASM.Dictionary> ASM_Dictionary { get; set; }
        /// <summary>
        /// 行政区划
        /// </summary>
        public virtual DbSet<Entities.ASM.Region> ASM_Region { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        public virtual DbSet<Entities.ASM.Hospital> ASM_Hospital { get; set; }

        #endregion

        #region AVM
        /// <summary>
        /// 用户
        /// </summary>
        public virtual DbSet<Entities.AVM.User> AVM_User { get; set; }

        #endregion

        #region WFM
        /// <summary>
        /// 数据字典
        /// </summary>
        public virtual DbSet<Entities.WFM.Status> WFM_Status { get; set; }

        #endregion

        #region CMS
        /// <summary>
        /// 会员
        /// </summary>
        public virtual DbSet<Entities.CMS.Member> CMS_Member { get; set; }
        /// <summary>
        /// 会员权限
        /// </summary>
        public virtual DbSet<Entities.CMS.MemberPower> CMS_MemberPower { get; set; }
        /// <summary>
        /// 充值
        /// </summary>
        public virtual DbSet<Entities.CMS.Recharge> CMS_Recharge { get; set; }
        /// <summary>
        /// 收藏
        /// </summary>
        public virtual DbSet<Entities.CMS.Collect> CMS_Collect { get; set; }
        /// <summary>
        /// 下载
        /// </summary>
        public virtual DbSet<Entities.CMS.Down> CMS_Down { get; set; }
        /// <summary>
        /// 上传
        /// </summary>
        public virtual DbSet<Entities.CMS.Upload> CMS_Upload { get; set; }
        /// <summary>
        /// 认证
        /// </summary>
        public virtual DbSet<Entities.CMS.Authority> CMS_Authority { get; set; }
        /// <summary>
        /// 提现
        /// </summary>
        public virtual DbSet<Entities.CMS.CashOut> CMS_CashOut { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        public virtual DbSet<Entities.CMS.Goods> CMS_Goods { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual DbSet<Entities.CMS.Order> CMS_Order { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        public virtual DbSet<Entities.CMS.OrderDetail> CMS_OrderDetail { get; set; }
        /// <summary>
        /// 流水
        /// </summary>
        public virtual DbSet<Entities.CMS.Serial> CMS_Serial { get; set; }
        /// <summary>
        /// 导航
        /// </summary>
        public virtual DbSet<Entities.CMS.Navigation> CMS_Navigation { get; set; }
        /// <summary>
        /// 资讯
        /// </summary>
        public virtual DbSet<Entities.CMS.Article> CMS_Article { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public virtual DbSet<Entities.CMS.Discuss> CMS_Discuss { get; set; }

        #endregion
    }

}
