using MISApi.Dal.EF;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;

namespace MISApi.Services.CMS.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleService : BaseService.EF<Article, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : ArticleService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private readonly TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Article Execute(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Article> Execute(List<Article> entityList)
            {
                try
                {
                    // 定义
                    List<Article> resultList = new List<Article>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entityList.ForEach(entity =>
                        {
                            resultList.Add(
                                    new CreateService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : ArticleService
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
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Article Execute(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Article> Execute(List<Article> entityList)
            {
                try
                {
                    // 定义
                    List<Article> resultList = new List<Article>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        entityList.ForEach(entity =>
                        {
                            resultList.Add(
                                    new UpdateService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : ArticleService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public DeleteService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Article Execute(Article entity)
            {
                try
                {
                    // 定义
                    Article result = new Article();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Article> Execute(List<Article> entitys)
            {
                try
                {
                    // 定义
                    List<Article> resultList = new List<Article>();
                    // 事务
                    transService.TransRegist(delegate {
                        entitys.ForEach(entity =>
                        {
                            resultList.Add(
                                    new DeleteService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : ArticleService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Article Single()
            {
                try
                {
                    return new Article();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : ArticleService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Article ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Article.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowService.ById", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : ArticleService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Article> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 根据导航Id查询
            /// </summary>
            /// <param name="navigationId">导航Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Article> ByNavigationId(int navigationId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins).Where(row=>row.Article.NavigationId == navigationId).ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowsService.ByNavigationId", ex);
                    }
                }
            }
            /// <summary>
            /// 分页
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="page"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public List<Article> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, joins);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord.Value);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord.Ext);
                        // 日期
                        queryable = DateQueryable(queryable, dates);
                        // 状态
                        queryable = StatusQueryable(queryable, status);
                        // 排序
                        queryable = SortQueryable(queryable, sorts);
                        // 分页
                        queryable = PageQueryable(queryable, page);
                        // 返回
                        return SQLEntityToList(
                                queryable.ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowsService.Page", ex);
                    }
                }
            }
            /// <summary>
            /// 分页计数
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public int PageCount(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, joins);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord.Value);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord.Ext);
                        // 日期
                        queryable = DateQueryable(queryable, dates);
                        // 状态
                        queryable = StatusQueryable(queryable, status);
                        // 排序
                        queryable = SortQueryable(queryable, sorts);
                        // 返回
                        return queryable.Count();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowsService.PageCount", ex);
                    }
                }
            }
            /// <summary>
            /// 分页汇总
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 返回
                        return new SummaryEntity();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.ArticleService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods

        /// <summary>
        /// 默认查询
        /// </summary>
        /// <param name="context"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> SQLQueryable(PandoraContext context, params BaseMode.Join[] joins)
        {
            try
            {
                // 定义
                var left = context.CMS_Article.Select(Main => new SQLEntity
                {
                    Article = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Navigation
                    if (join.Name.ToLower().Equals("navigation"))
                    {
                        left = left.LeftOuterJoin(context.CMS_Navigation, Main => Main.Article.NavigationId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Article = Main.Article,
                            Navigation = Left,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Article.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Article = Main.Article,
                            Navigation = Main.Navigation,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Article = Main.Article,
                    Navigation = Main.Navigation,
                    Status = Main.Status
                });
                // 遍历
                foreach (var join in joins)
                {

                }
                // 返回
                return group;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.SQLQueryable", ex);
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> KeyWordQueryable(IQueryable<SQLEntity> queryable, string keyWord)
        {
            try
            {
                // #分割生成and数组
                string[] ands = keyWord.Split('#');
                // 空格分割生成or数组
                string[] ors = Regex.Split(keyWord, "\\s+", RegexOptions.IgnoreCase);
                // 多个条件精确查询，单个条件关键字查询
                if (ands.Length > 1)
                {
                    for (var i = 0; i < ands.Length; i++)
                    {
                        var andKeyWord = ands[i];
                        queryable = queryable.Where(row =>
                                row.Article.NavigationName.Contains(andKeyWord) ||
                                row.Article.Title.Contains(andKeyWord) ||
                                row.Article.Content.Contains(andKeyWord) ||
                                row.Article.Publisher.Contains(andKeyWord) ||
                                row.Article.Summary.Contains(andKeyWord) ||
                                row.Article.Tags.Contains(andKeyWord) ||
                                row.Article.Url.Contains(andKeyWord) ||
                                row.Article.Remark.Contains(andKeyWord) ||
                                row.Article.StatusName.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Article.NavigationName) ||
                            ors.Contains(row.Article.Title) ||
                            ors.Contains(row.Article.Content) ||
                            ors.Contains(row.Article.Publisher) ||
                            ors.Contains(row.Article.Summary) ||
                            ors.Contains(row.Article.Tags) ||
                            ors.Contains(row.Article.Url) ||
                            ors.Contains(row.Article.Remark) ||
                            ors.Contains(row.Article.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Article.NavigationName.Contains(keyWord) ||
                            row.Article.Title.Contains(keyWord) ||
                            row.Article.Content.Contains(keyWord) ||
                            row.Article.Publisher.Contains(keyWord) ||
                            row.Article.Summary.Contains(keyWord) ||
                            row.Article.Tags.Contains(keyWord) ||
                            row.Article.Url.Contains(keyWord) ||
                            row.Article.Remark.Contains(keyWord) ||
                            row.Article.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.KeyWordQueryable", ex);
            }
        }
        /// <summary>
        /// 关键字扩展
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWordExt"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> KeyWordExtQueryable(IQueryable<SQLEntity> queryable, string keyWordExt)
        {
            try
            {
                // 拆分查询条件
                var splits = keyWordExt.Split('^');
                // 遍历
                for (var i = 0; i < splits.Length; i++)
                {
                    if (splits[i].ToLower().Contains("statusid"))
                    {
                        int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.StatusId == statusId);
                    }
                    if (splits[i].ToLower().Contains("navigationid"))
                    {
                        int navigationId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.NavigationId == navigationId);
                    }
                    if (splits[i].ToLower().Contains("urltype"))
                    {
                        int urlType = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.UrlType == urlType);
                    }
                    if (splits[i].ToLower().Contains("isdisplay"))
                    {
                        bool isDisplay = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.IsDisplay == isDisplay);
                    }
                    if (splits[i].ToLower().Contains("istop"))
                    {
                        bool isTop = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.IsTop == isTop);
                    }
                    if (splits[i].ToLower().Contains("istarget"))
                    {
                        bool isTarget = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Article.IsTarget == isTarget);
                    }
                    if (splits[i].ToLower().Contains("hits"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Article.Hits >= min && row.Article.Hits <= max);
                    }
                    if (splits[i].ToLower().Contains("likes"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Article.Likes >= min && row.Article.Likes <= max);
                    }
                    if (splits[i].ToLower().Contains("collects"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Article.Collects >= min && row.Article.Collects <= max);
                    }
                    if (splits[i].ToLower().Contains("forwards"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Article.Forwards >= min && row.Article.Forwards <= max);
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.KeyWordExtQueryable", ex);
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> DateQueryable(IQueryable<SQLEntity> queryable, params BaseMode.Date[] dates)
        {
            try
            {
                if (dates != null)
                {
                    dates.ToList().ForEach(date =>
                    {
                        if (date.Name.ToLower().Equals("publishdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Article.PublishDateTime >= date.MinDate && row.Article.PublishDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("createdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Article.CreateDateTime >= date.MinDate && row.Article.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Article.EditDateTime >= date.MinDate && row.Article.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.DateQueryable", ex);
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> StatusQueryable(IQueryable<SQLEntity> queryable, BaseMode.Status status)
        {
            try
            {
                if (status != null && status.Values.Count() > 0)
                {
                    return queryable.Where(row => status.Values.Contains(row.Article.StatusValue));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.StatusQueryable", ex);
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="sorts"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> SortQueryable(IQueryable<SQLEntity> queryable, params BaseMode.Sort[] sorts)
        {
            try
            {
                if (sorts != null)
                {
                    if (sorts.Length == 1)
                    {
                        queryable = queryable.OrderBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.{sorts[0].Name}", sorts[0].Mode);
                    }
                    else
                    {
                        for (int i = 1; i < sorts.Length; i++)
                        {
                            queryable = queryable.ThenBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.{sorts[i].Name}", sorts[i].Mode);
                        }
                    }
                }
                else
                {
                    queryable = queryable.DefaultBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.id");
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.SortQueryable", ex);
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> PageQueryable(IQueryable<SQLEntity> queryable, BaseMode.Page page)
        {
            try
            {
                if (page != null)
                {
                    queryable = queryable
                       .Take(page.Index * page.Size)
                       .Skip(page.Size * (page.Index - 1));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Article SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Article articleEntity = entity.Article;
                // 导航
                articleEntity.Navigation = entity.Navigation ?? null;
                // 状态
                articleEntity.Status = entity.Status ?? null;
                // 返回
                return articleEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Article> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.ArticleService.SQLEntityToList", ex);
            }
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        protected class SQLEntity
        {
            /// <summary>
            /// 
            /// </summary>
            public Article Article { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Navigation Navigation { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Status Status { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class SummaryEntity
        {

        }
        #endregion
    }
}