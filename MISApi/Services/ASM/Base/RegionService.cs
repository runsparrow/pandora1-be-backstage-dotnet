using MISApi.Dal.EF;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MISApi.Entities.ASM;
using MISApi.Entities.WFM;

namespace MISApi.Services.ASM.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionService : BaseService.EF<Region, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : RegionService
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
            public Region Execute(Region entity)
            {
                try
                {
                    // 定义
                    Region result = new Region();
                    // 事务
                    transService.TransRegist(delegate {
                        entity = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Region> Execute(List<Region> entityList)
            {
                try
                {
                    // 定义
                    List<Region> resultList = new List<Region>();
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
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : RegionService
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
            public Region Execute(Region entity)
            {
                try
                {
                    // 定义
                    Region result = new Region();
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
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Region> Execute(List<Region> entityList)
            {
                try
                {
                    // 定义
                    List<Region> resultList = new List<Region>();
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
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : RegionService
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
            public Region Execute(Region entity)
            {
                try
                {
                    // 定义
                    Region result = new Region();
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
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Region> Execute(List<Region> entitys)
            {
                try
                {
                    // 定义
                    List<Region> resultList = new List<Region>();
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
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : RegionService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Region Single()
            {
                try
                {
                    return new Region();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : RegionService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Region ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Region.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowService.ById", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="code">行政区划代码</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Region ByCode(string code, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Region.Code == code)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowService.ByCode", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : RegionService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Region> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 根据父节点Id查询
            /// </summary>
            /// <param name="pid">父节点Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Region> ByPid(int pid, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, joins).Where(row => row.Region.Pid == pid).ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.ByPid", ex);
                    }
                }
            }
            /// <summary>
            /// 根据父节点Code查询
            /// </summary>
            /// <param name="pcode">父节点Code</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Region> ByParentCode(string pcode, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        Region region = new RowService().ByCode(pcode);
                        return new RowsService().ByPid(region == null ? 0: region.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.ByParentCode", ex);
                    }
                }
            }
            /// <summary>
            /// 根据Code查询所有子节点（递归并包含Code自身）
            /// </summary>
            /// <param name="code"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Region> SubsetByCode(string code, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Region> list = new RowService().ByCode(code) == null ? new List<Region>() : new List<Region> { new RowService().ByCode(code) };
                    return SubsetByIdRecursion(list, list[0].Id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.SubsetByCode", ex);
                }
            }
            /// <summary>
            /// 根据Code查询所有父节点（递归并包含Code自身）
            /// </summary>
            /// <param name="code"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Region> SupersetByCode(string code, params BaseMode.Join[] joins)
            {
                try
                {
                    Region currentRegion = new RowService().ByCode(code) ?? new Region();
                    List<Region> result = SupersetByIdRecursion(new List<Region>(), currentRegion.Pid, joins);
                    result.Add(currentRegion);
                    string path = "^";
                    // 生成path
                    result.ForEach(region =>
                    {
                        path = region.Path = $"{path}{region.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.SupersetByCode", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有子节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Region> SubsetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Region> list = new RowService().ById(id) == null ? new List<Region>() : new List<Region> { new RowService().ById(id) };
                    return SubsetByIdRecursion(list, id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.SubsetById", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有父节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Region> SupersetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    Region currentRegion = new RowService().ById(id);
                    List<Region> result = SupersetByIdRecursion(new List<Region>(), currentRegion.Pid, joins);
                    result.Add(currentRegion);
                    string path = "^";
                    // 生成path
                    result.ForEach(region =>
                    {
                        path = region.Path = $"{path}{region.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.SupersetById", ex);
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
            public List<Region> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.ASM.Base.RegionService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods
        /// <summary>
        /// 根据Id递归获取Region
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Region> SubsetByIdRecursion(List<Region> list, int id, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Region.Pid == id).ToList().ForEach(sqlEntity => {
                        list.Add(sqlEntity.Region);
                        SubsetByIdRecursion(list, sqlEntity.Region.Id, joins);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.SubsetByIdRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Id递归获取Region
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pid"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Region> SupersetByIdRecursion(List<Region> list, int pid, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Region.Id == pid).ToList().ForEach(sqlEntity => {
                        SupersetByIdRecursion(list, sqlEntity.Region.Pid, joins);
                        list.Add(sqlEntity.Region);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.RegionService.SupersetByIdRecursion", ex);
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
                var left = context.ASM_Region.Select(Main => new SQLEntity
                {
                    Region = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.ParentRegion
                    if (join.Name.ToLower().Equals("parentregion"))
                    {
                        left = left.LeftOuterJoin(context.ASM_Region, Main => Main.Region.Pid, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Region = Main.Region,
                            ParentRegion = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Region = Main.Region,
                    ParentRegion = Main.ParentRegion
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
                throw new Exception("MISApi.Services.ASM.Base.RegionService.SQLQueryable", ex);
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
                                row.Region.Name.Contains(andKeyWord) ||
                                row.Region.Code.Contains(andKeyWord) ||
                                row.Region.ImportVersion.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Region.Name) ||
                            ors.Contains(row.Region.Code) ||
                            ors.Contains(row.Region.ImportVersion)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Region.Name.Contains(keyWord) ||
                            row.Region.Code.Contains(keyWord) ||
                            row.Region.ImportVersion.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.KeyWordQueryable", ex);
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
                    if (splits[i].ToLower().Contains("pid"))
                    {
                        int pid = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Region.Pid == pid);
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.KeyWordExtQueryable", ex);
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
                        if (date.Name.ToLower().Equals("importdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Region.ImportDateTime >= date.MinDate && row.Region.ImportDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.DateQueryable", ex);
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
                throw new Exception("MISApi.Services.ASM.Base.RegionService.StatusQueryable", ex);
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
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.ASM.Base.RegionService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Region SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Region regionEntity = entity.Region;
                // 上级字典
                regionEntity.ParentRegion = entity.ParentRegion ?? null;
                // 返回
                return regionEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Region> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.RegionService.SQLEntityToList", ex);
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
            public Region Region { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Region ParentRegion { get; set; }
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