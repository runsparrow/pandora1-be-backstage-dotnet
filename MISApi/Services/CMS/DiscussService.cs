using MISApi.CacheServices.WFM;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using System;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class DiscussService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.DiscussService.CreateService
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
            /// 在用
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Discuss ToOpen(Discuss entity)
            {
                try
                {
                    // 定义
                    Discuss result = new Discuss();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.discuss.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = new DiscussService.CreateService().Execute(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.DiscussService.CreateService.ToOpen", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.DiscussService.UpdateService
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
            /// 在用
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Discuss ToOpen(Discuss entity)
            {
                try
                {
                    // 定义
                    Discuss result = new Discuss();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.discuss.open");
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
                    throw new Exception("MISApi.Services.CMS.DiscussService.UpdateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 关闭
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Discuss ToClose(Discuss entity)
            {
                try
                {
                    // 定义
                    Discuss result = new Discuss();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.discuss.close");
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
                    throw new Exception("MISApi.Services.CMS.DiscussService.UpdateService.ToClose", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.DiscussService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.DiscussService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.DiscussService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.DiscussService.RowsService
        {

        }

        #endregion
    }
}