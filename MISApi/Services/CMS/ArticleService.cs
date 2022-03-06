using MISApi.CacheServices.WFM;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using System.IO;

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
            /// 创建指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Article ToStatus(Article entity, string statusKey)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.ArticleService.CreateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量创建指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Article> BatchToStatus(List<Article> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Article> results = new List<Article>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new ArticleService.CreateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.ArticleService.CreateService.BatchToStatus", ex);
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
            /// 编辑指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Article ToStatus(Article entity, string statusKey)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
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
                    throw new Exception("MISApi.Services.CMS.ArticleService.UpdateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量编辑指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Article> BatchToStatus(List<Article> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Article> results = new List<Article>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new ArticleService.UpdateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.ArticleService.UpdateService.BatchToStatus", ex);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string RMS()
            {
                Stream stream = NPOIHelper.CreateFileStreamFromTemplate($"{ConfigurationHelper.GetRMS("Template")}\\Article.xls");
                // 查询
                var articleList = new ArticleService.RowsService().Page(
                    new HttpClients.HttpModes.BaseMode.KeyWord(""), 
                    new HttpClients.HttpModes.BaseMode.Join [] { new HttpClients.HttpModes.BaseMode.Join("")}, 
                    new HttpClients.HttpModes.BaseMode.Page(1, 10000),
                    null,
                    null, 
                    new HttpClients.HttpModes.BaseMode.Status(1,2)
                );
                // 循环
                for(int index=0; index<articleList.Count; index++)
                {
                    stream = NPOIHelper.CreateRow(stream, 0, index + 1,
                            new NPOIHelper.Cell { Index = 0, Value = articleList[index].NavigationName },
                            new NPOIHelper.Cell { Index = 1, Value = articleList[index].Title },
                            new NPOIHelper.Cell { Index = 2, Value = articleList[index].Publisher },
                            new NPOIHelper.Cell { Index = 3, Value = articleList[index].PublishDateTime.ToString() },
                            new NPOIHelper.Cell { Index = 4, Value = articleList[index].Source },
                            new NPOIHelper.Cell { Index = 5, Value = articleList[index].SourceUrl }
                        );
                }
                // 文件路径
                string filePath = $"{ConfigurationHelper.GetRMS("Result")}\\{DateTime.Now.ToString("yyyyMMdd")}_Article.xls";
                // 创建文件
                NPOIHelper.WriteSteamToFile(filePath, (MemoryStream)stream);
                // 返回
                return filePath;
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