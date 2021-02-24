using MISApi.CacheServices.WFM;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using System;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.ArticleService.CreateService
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
            public virtual Article ToOpen(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByCode("cms.article.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = new ArticleService.CreateService().Execute(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.ArticleService.CreateService.ToOpen", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.ArticleService.UpdateService
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
            public virtual Article ToOpen(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.article.open");
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
                    throw new Exception("MISApi.Services.CMS.ArticleService.UpdateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 关闭
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Article ToClose(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.article.close");
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
                    throw new Exception("MISApi.Services.CMS.ArticleService.UpdateService.ToClose", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.ArticleService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.ArticleService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.ArticleService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.ArticleService.RowsService
        {

        }

        #endregion
    }
}