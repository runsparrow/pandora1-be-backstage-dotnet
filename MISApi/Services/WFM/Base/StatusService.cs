﻿using MISApi.Dal.EF;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MISApi.Entities.WFM;

namespace MISApi.Services.WFM.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusService : BaseService.EF<Status, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : StatusService
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
            public Status Execute(Status entity)
            {
                try
                {
                    // 定义
                    Status result = new Status();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Status> Execute(List<Status> entityList)
            {
                try
                {
                    // 定义
                    List<Status> resultList = new List<Status>();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : StatusService
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
            public Status Execute(Status entity)
            {
                try
                {
                    // 定义
                    Status result = new Status();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Status> Execute(List<Status> entityList)
            {
                try
                {
                    // 定义
                    List<Status> resultList = new List<Status>();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : StatusService
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
            public Status Execute(Status entity)
            {
                try
                {
                    // 定义
                    Status result = new Status();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Status> Execute(List<Status> entitys)
            {
                try
                {
                    // 定义
                    List<Status> resultList = new List<Status>();
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
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : StatusService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Status Single()
            {
                try
                {
                    return new Status();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : StatusService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Status ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Status.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowService.ById", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 键值 查询
            /// </summary>
            /// <param name="key">键值</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Status ByKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Status.Key == key)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowService.ByKey", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : StatusService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Status> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 根据父节点Id查询
            /// </summary>
            /// <param name="pid">父节点Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Status> ByPid(int pid, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, joins).Where(row => row.Status.Pid == pid).ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.ByPid", ex);
                    }
                }
            }
            /// <summary>
            /// 根据父节点键名查询
            /// </summary>
            /// <param name="key">父节点键名</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Status> ByParentKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        Status status = new RowService().ByKey(key);
                        return new RowsService().ByPid(status == null ? 0 : status.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.ByParentKey", ex);
                    }
                }
            }
            /// <summary>
            /// 根据Key查询所有子节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Status> SubsetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Status> list = new RowService().ByKey(key) == null ? new List<Status>() : new List<Status> { new RowService().ByKey(key) };
                    return SubsetByIdRecursion(list, list[0].Id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.StatusService.RowsService.SubsetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Key查询所有父节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Status> SupersetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    Status currentStatus = new RowService().ByKey(key) ?? new Status();
                    List<Status> result = SupersetByIdRecursion(new List<Status>(), currentStatus.Pid??-1, joins);
                    result.Add(currentStatus);
                    string path = "^";
                    // 生成path
                    result.ForEach(status =>
                    {
                        path = status.Path = $"{path}{status.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.StatusService.RowsService.SupersetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有子节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Status> SubsetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Status> list = new RowService().ById(id) == null ? new List<Status>() : new List<Status> { new RowService().ById(id) };
                    return SubsetByIdRecursion(list, id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.SubsetById", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有父节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Status> SupersetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    Status currentStatus = new RowService().ById(id);
                    List<Status> result = SupersetByIdRecursion(new List<Status>(), currentStatus.Pid??-1, joins);
                    result.Add(currentStatus);
                    string path = "^";
                    // 生成path
                    result.ForEach(status =>
                    {
                        path = status.Path = $"{path}{status.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.StatusService.RowsService.SupersetById", ex);
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
            public List<Status> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.WFM.Base.StatusService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods
        /// <summary>
        /// 根据Id递归获取Status
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Status> SubsetByIdRecursion(List<Status> list, int id, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Status.Pid == id).ToList().ForEach(sqlEntity => {
                        list.Add(sqlEntity.Status);
                        SubsetByIdRecursion(list, sqlEntity.Status.Id, joins);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.WFM.Base.StatusService.SubsetByIdRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Id递归获取Status
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pid"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Status> SupersetByIdRecursion(List<Status> list, int pid, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Status.Id == pid).ToList().ForEach(sqlEntity => {
                        SupersetByIdRecursion(list, sqlEntity.Status.Pid??-1, joins);
                        list.Add(sqlEntity.Status);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.StatusService.SupersetByIdRecursion", ex);
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
                var left = context.WFM_Status.Select(Main => new SQLEntity
                {
                    Status = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.ParentStatus
                    if (join.Name.ToLower().Equals("parentstatus"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Status.Pid, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Status = Main.Status,
                            ParentStatus = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Status = Main.Status,
                    ParentStatus = Main.ParentStatus
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
                throw new Exception("MISApi.Services.WFM.Base.StatusService.SQLQueryable", ex);
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
                                row.Status.Name.Contains(andKeyWord) ||
                                row.Status.Desc.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Status.Name) ||
                            ors.Contains(row.Status.Desc)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Status.Name.Contains(keyWord) ||
                            row.Status.Desc.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.WFM.Base.StatusService.KeyWordQueryable", ex);
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
                        if (splits[i].ToLower().Contains("parentstatus"))
                        {
                            int pid = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Status.Pid == pid);
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
                throw new Exception("MISApi.Services.WFM.Base.StatusService.KeyWordExtQueryable", ex);
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
                                    row.Status.CreateDateTime >= date.MinDate && row.Status.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Status.EditDateTime >= date.MinDate && row.Status.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.WFM.Base.StatusService.DateQueryable", ex);
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

                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.WFM.Base.StatusService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.WFM.Base.StatusService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.WFM.Base.StatusService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Status SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Status statusEntity = entity.Status;
                // 上级状态
                statusEntity.ParentStatus = entity.ParentStatus ?? null;
                // 返回
                return statusEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.WFM.Base.StatusService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Status> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.WFM.Base.StatusService.SQLEntityToList", ex);
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
            public Status Status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Status ParentStatus { get; set; }
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