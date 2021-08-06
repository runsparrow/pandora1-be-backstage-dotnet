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
    public class NavigationService : BaseService.EF<Navigation, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : NavigationService
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
            public Navigation Execute(Navigation entity)
            {
                try
                {
                    // 定义
                    Navigation result = new Navigation();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Navigation> Execute(List<Navigation> entityList)
            {
                try
                {
                    // 定义
                    List<Navigation> resultList = new List<Navigation>();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : NavigationService
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
            public Navigation Execute(Navigation entity)
            {
                try
                {
                    // 定义
                    Navigation result = new Navigation();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Navigation> Execute(List<Navigation> entityList)
            {
                try
                {
                    // 定义
                    List<Navigation> resultList = new List<Navigation>();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : NavigationService
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
            public Navigation Execute(Navigation entity)
            {
                try
                {
                    // 定义
                    Navigation result = new Navigation();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Navigation> Execute(List<Navigation> entitys)
            {
                try
                {
                    // 定义
                    List<Navigation> resultList = new List<Navigation>();
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
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : NavigationService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Navigation Single()
            {
                try
                {
                    return new Navigation();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : NavigationService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Navigation ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Navigation.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowService.ById", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 键名 查询
            /// </summary>
            /// <param name="key">键名</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Navigation ByKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Navigation.Key == key)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowService.ByKey", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : NavigationService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Navigation> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 根据父节点Id查询
            /// </summary>
            /// <param name="pid">父节点Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Navigation> ByPid(int pid, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Navigation.Pid == pid)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.ByPid", ex);
                    }
                }
            }
            /// <summary>
            /// 根据父节点键名查询
            /// </summary>
            /// <param name="key">父节点键名</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Navigation> ByParentKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        Navigation navigation = new RowService().ByKey(key);
                        return new RowsService().ByPid(navigation == null ? 0 : navigation.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.ByParentKey", ex);
                    }
                }
            }
            /// <summary>
            /// 根据Key查询所有子节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Navigation> SubsetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Navigation> list = new RowService().ByKey(key) == null ? new List<Navigation>() : new List<Navigation> { new RowService().ByKey(key) };
                    return SubsetByIdRecursion(list, list[0].Id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.RowsService.SubsetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Key查询所有父节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Navigation> SupersetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    Navigation currentNavigation = new RowService().ByKey(key) ?? new Navigation();
                    List<Navigation> result = SupersetByIdRecursion(new List<Navigation>(), currentNavigation.Pid??-1, joins);
                    result.Add(currentNavigation);
                    string path = "^";
                    // 生成path
                    result.ForEach(navigation =>
                    {
                        path = navigation.Path = $"{path}{navigation.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.RowsService.SupersetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有子节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Navigation> SubsetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Navigation> list = new RowService().ById(id) == null ? new List<Navigation>() : new List<Navigation> { new RowService().ById(id) };
                    return SubsetByIdRecursion(list, id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.RowsService.SubsetById", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有父节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Navigation> SupersetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    Navigation currentNavigation = new RowService().ById(id);
                    List<Navigation> result = SupersetByIdRecursion(new List<Navigation>(), currentNavigation.Pid??-1, joins);
                    result.Add(currentNavigation);
                    string path = "^";
                    // 生成path
                    result.ForEach(navigation =>
                    {
                        path = navigation.Path = $"{path}{navigation.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.RowsService.SupersetById", ex);
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
            public List<Navigation> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.NavigationService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods
        /// <summary>
        /// 根据Id递归获取Dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Navigation> SubsetByIdRecursion(List<Navigation> list, int id, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Navigation.Pid == id).ToList().ForEach(sqlEntity => {
                        list.Add(sqlEntity.Navigation);
                        SubsetByIdRecursion(list, sqlEntity.Navigation.Id, joins);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.SubsetByIdRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Id递归获取Navigation
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pid"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Navigation> SupersetByIdRecursion(List<Navigation> list, int pid, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Navigation.Id == pid).ToList().ForEach(sqlEntity => {
                        SupersetByIdRecursion(list, sqlEntity.Navigation.Pid??-1, joins);
                        list.Add(sqlEntity.Navigation);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.NavigationService.SupersetByIdRecursion", ex);
                }
            }
        }
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
                var left = context.CMS_Navigation.Select(Main => new SQLEntity
                {
                    Navigation = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Navigation.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Navigation = Main.Navigation,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
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
            catch(Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.SQLQueryable", ex);
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
                                row.Navigation.Name.Contains(andKeyWord) ||
                                row.Navigation.Group.Contains(andKeyWord) ||
                                row.Navigation.Url.Contains(andKeyWord) ||
                                row.Navigation.Remark.Contains(andKeyWord) ||
                                row.Navigation.StatusName.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Navigation.Name) ||
                            ors.Contains(row.Navigation.Group) ||
                            ors.Contains(row.Navigation.Url) ||
                            ors.Contains(row.Navigation.Remark) ||
                            ors.Contains(row.Navigation.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Navigation.Name.Contains(keyWord) ||
                            row.Navigation.Group.Contains(keyWord) ||
                            row.Navigation.Url.Contains(keyWord) ||
                            row.Navigation.Remark.Contains(keyWord) ||
                            row.Navigation.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.KeyWordQueryable", ex);
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
                    try
                    {
                        if (splits[i].ToLower().Contains("statusid"))
                        {
                            int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Navigation.StatusId == statusId);
                        }
                        if (splits[i].ToLower().Contains("isdisplay"))
                        {
                            bool isDisplay = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Navigation.IsDisplay == isDisplay);
                        }
                        if (splits[i].ToLower().Contains("isdisplay"))
                        {
                            bool isDisplay = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Navigation.IsDisplay == isDisplay);
                        }
                        if (splits[i].ToLower().Contains("islink"))
                        {
                            bool isLink = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Navigation.IsLink == isLink);
                        }
                        if (splits[i].ToLower().Contains("istarget"))
                        {
                            bool isTarget = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Navigation.IsTarget == isTarget);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.KeyWordExtQueryable", ex);
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
                        if (date.Name.ToLower().Equals("createdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Navigation.CreateDateTime >= date.MinDate && row.Navigation.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Navigation.EditDateTime >= date.MinDate && row.Navigation.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.DateQueryable", ex);
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
                    return queryable.Where(row => status.Values.Contains(row.Navigation.StatusValue??0));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Navigation SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Navigation navigationEntity = entity.Navigation;
                // 状态
                navigationEntity.Status = entity.Status ?? null;
                // 返回
                return navigationEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Navigation> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.NavigationService.SQLEntityToList", ex);
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