﻿using MISApi.CacheServices.WFM;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using System;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class CashOutService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.CashOutService.CreateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 开启
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToOpen(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = new CashOutService.CreateService().Execute(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.CreateService.ToOpen", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.CashOutService.UpdateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public UpdateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 开启
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToOpen(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 关闭
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToClose(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.close");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToClose", ex);
                }
            }
            /// <summary>
            /// 提交
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToSubmit(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.submit");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToSubmit", ex);
                }
            }
            /// <summary>
            /// 审批通过
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToApproverPass(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.approver.pass");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToApproverPass", ex);
                }
            }
            /// <summary>
            /// 审批拒绝
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToApproverRefuse(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.approver.refuse");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToApproverRefuse", ex);
                }
            }
            /// <summary>
            /// 放款
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual CashOut ToLoan(CashOut entity)
            {
                try
                {
                    // 定义
                    CashOut result = new CashOut();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.cashout.loan");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CashOutService.UpdateService.ToLoan", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.CashOutService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.CashOutService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.CashOutService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.CashOutService.RowsService
        {

        }

        #endregion
    }
}