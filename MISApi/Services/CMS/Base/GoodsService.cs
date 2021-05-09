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
    public class GoodsService : BaseService.EF<Goods, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : GoodsService
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
            public Goods Execute(Goods entity)
            {
                try
                {
                    // 定义
                    Goods result = new Goods();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Goods> Execute(List<Goods> entityList)
            {
                try
                {
                    // 定义
                    List<Goods> resultList = new List<Goods>();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : GoodsService
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
            public Goods Execute(Goods entity)
            {
                try
                {
                    // 定义
                    Goods result = new Goods();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Goods> Execute(List<Goods> entityList)
            {
                try
                {
                    // 定义
                    List<Goods> resultList = new List<Goods>();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : GoodsService
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
            public Goods Execute(Goods entity)
            {
                try
                {
                    // 定义
                    Goods result = new Goods();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Goods> Execute(List<Goods> entitys)
            {
                try
                {
                    // 定义
                    List<Goods> resultList = new List<Goods>();
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
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : GoodsService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Goods Single()
            {
                try
                {
                    return new Goods();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : GoodsService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Goods ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Goods.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowService.ById", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : GoodsService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Goods> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ownerId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Goods> ByOwnerId(int ownerId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Goods.OwnerId == ownerId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowService.ByOwnerId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="classifyId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Goods> ByClassifyId(int classifyId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Goods.ClassifyId == classifyId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowService.ByClassifyId", ex);
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
            public List<Goods> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.GoodsService.RowsService.PageSummary", ex);
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
                var left = context.CMS_Goods.Select(Main => new SQLEntity
                {
                    Goods = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Goods.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Goods = Main.Goods,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Goods = Main.Goods,
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
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.SQLQueryable", ex);
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
                            row.Goods.Name.Contains(andKeyWord) ||
                            row.Goods.Desc.Contains(andKeyWord) ||
                            row.Goods.AuthDesc.Contains(andKeyWord) ||
                            row.Goods.Ext.Contains(andKeyWord) ||
                            row.Goods.DPI.Contains(andKeyWord) ||
                            row.Goods.Ratio.Contains(andKeyWord) ||
                            row.Goods.RGB.Contains(andKeyWord) ||
                            row.Goods.Size.Contains(andKeyWord) ||
                            row.Goods.ClassifyName.Contains(andKeyWord) ||
                            row.Goods.Remark.Contains(andKeyWord) ||
                            row.Goods.StatusName.Contains(andKeyWord)
                        );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Goods.Name) ||
                            ors.Contains(row.Goods.Desc) ||
                            ors.Contains(row.Goods.AuthDesc) ||
                            ors.Contains(row.Goods.Ext) ||
                            ors.Contains(row.Goods.DPI) ||
                            ors.Contains(row.Goods.Ratio) ||
                            ors.Contains(row.Goods.RGB) ||
                            ors.Contains(row.Goods.Size) ||
                            ors.Contains(row.Goods.ClassifyName) ||
                            ors.Contains(row.Goods.Remark) ||
                            ors.Contains(row.Goods.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Goods.Name.Contains(keyWord) ||
                            row.Goods.Desc.Contains(keyWord) ||
                            row.Goods.AuthDesc.Contains(keyWord) ||
                            row.Goods.Ext.Contains(keyWord) ||
                            row.Goods.DPI.Contains(keyWord) ||
                            row.Goods.Ratio.Contains(keyWord) ||
                            row.Goods.RGB.Contains(keyWord) ||
                            row.Goods.Size.Contains(keyWord) ||
                            row.Goods.ClassifyName.Contains(keyWord) ||
                            row.Goods.Remark.Contains(keyWord) ||
                            row.Goods.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.KeyWordQueryable", ex);
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
                        queryable = queryable.Where(row => row.Goods.StatusId == statusId);
                    }
                    if (splits[i].ToLower().Contains("classifyid"))
                    {
                        int classifyId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Goods.ClassifyId == classifyId);
                    }
                    if (splits[i].ToLower().Contains("ownerid"))
                    {
                        int ownerId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Goods.OwnerId == ownerId);
                    }
                    if (splits[i].ToLower().Contains("tags"))
                    {
                        string tags = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                        queryable = queryable.Where(row => row.Goods.Tags.Contains($",{tags},"));
                    }
                    if (splits[i].ToLower().Contains("isimage"))
                    {
                        bool isImage = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Goods.IsImage == isImage);
                    }
                    if (splits[i].ToLower().Contains("isoriginal"))
                    {
                        bool isOriginal = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Goods.IsOriginal == isOriginal);
                    }
                    if (splits[i].ToLower().Contains("level"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.Level >= min && row.Goods.Level <= max);
                    }
                    if (splits[i].ToLower().Contains("price"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.Price >= min && row.Goods.Price <= max);
                    }
                    if (splits[i].ToLower().Contains("quantity"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.Quantity >= min && row.Goods.Quantity <= max);
                    }
                    if (splits[i].ToLower().Contains("downcount"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.DownCount >= min && row.Goods.DownCount <= max);
                    }
                    if (splits[i].ToLower().Contains("collectcount"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.CollectCount >= min && row.Goods.CollectCount <= max);
                    }
                    if (splits[i].ToLower().Contains("buycount"))
                    {
                        decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                        decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                        queryable = queryable.Where(row => row.Goods.BuyCount >= min && row.Goods.BuyCount <= max);
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.KeyWordExtQueryable", ex);
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
                        if (date.Name.ToLower().Equals("publicdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Goods.PublicDateTime >= date.MinDate && row.Goods.PublicDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("finaldatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Goods.FinalDateTime >= date.MinDate && row.Goods.FinalDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("createdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Goods.CreateDateTime >= date.MinDate && row.Goods.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Goods.EditDateTime >= date.MinDate && row.Goods.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.DateQueryable", ex);
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
                    return queryable.Where(row => status.Values.Contains(row.Goods.StatusValue));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Goods SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Goods goodsEntity = entity.Goods;
                // 状态
                goodsEntity.Status = entity.Status ?? null;
                // 返回
                return goodsEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Goods> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.GoodsService.SQLEntityToList", ex);
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
            public Goods Goods { get; set; }
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