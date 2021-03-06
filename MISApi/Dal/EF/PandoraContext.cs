using MISApi.Tools;
using Microsoft.EntityFrameworkCore;
using System;

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
        /// 用户
        /// </summary>
        public virtual DbSet<Entities.CMS.User> CMS_User { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public virtual DbSet<Entities.CMS.Account> CMS_Account { get; set; }
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

        #endregion
    }

}
