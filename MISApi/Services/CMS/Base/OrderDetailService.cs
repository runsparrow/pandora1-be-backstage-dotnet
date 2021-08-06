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
    public class OrderDetailService : BaseService.EF<OrderDetail, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : OrderDetailService
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
            public OrderDetail Execute(OrderDetail entity)
            {
                try
                {
                    // 定义
                    OrderDetail result = new OrderDetail();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<OrderDetail> Execute(List<OrderDetail> entityList)
            {
                try
                {
                    // 定义
                    List<OrderDetail> resultList = new List<OrderDetail>();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : OrderDetailService
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
            public OrderDetail Execute(OrderDetail entity)
            {
                try
                {
                    // 定义
                    OrderDetail result = new OrderDetail();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<OrderDetail> Execute(List<OrderDetail> entityList)
            {
                try
                {
                    // 定义
                    List<OrderDetail> resultList = new List<OrderDetail>();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : OrderDetailService
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
            public OrderDetail Execute(OrderDetail entity)
            {
                try
                {
                    // 定义
                    OrderDetail result = new OrderDetail();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<OrderDetail> Execute(List<OrderDetail> entitys)
            {
                try
                {
                    // 定义
                    List<OrderDetail> resultList = new List<OrderDetail>();
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
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : OrderDetailService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public OrderDetail Single()
            {
                try
                {
                    return new OrderDetail();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : OrderDetailService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public OrderDetail ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.OrderDetail.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowService.ById", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : OrderDetailService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<OrderDetail> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="orderId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<OrderDetail> ByOrderId(int orderId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.OrderDetail.OrderId == orderId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.ByOrderId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ownerId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<OrderDetail> ByOwnerId(int ownerId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.OrderDetail.OwnerId == ownerId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.ByOwnerId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="goodsId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<OrderDetail> ByGoodsId(int goodsId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.OrderDetail.GoodsId == goodsId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.ByGoodsId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="buyerId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<OrderDetail> ByBuyerId(int buyerId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.OrderDetail.BuyerId == buyerId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.ByBuyerId", ex);
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
            public List<OrderDetail> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.RowsService.PageSummary", ex);
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
                var left = context.CMS_OrderDetail.Select(Main => new SQLEntity
                {
                    OrderDetail = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Order
                    if (join.Name.ToLower().Equals("order"))
                    {
                        left = left.LeftOuterJoin(context.CMS_Order, Main => Main.OrderDetail.OrderId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            OrderDetail = Main.OrderDetail,
                            Goods = Main.Goods,
                            Order = Left,
                            Buyer = Main.Buyer,
                            Owner = Main.Owner,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Goods
                    if (join.Name.ToLower().Equals("goods"))
                    {
                        left = left.LeftOuterJoin(context.CMS_Goods, Main => Main.OrderDetail.GoodsId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            OrderDetail = Main.OrderDetail,
                            Goods = Left,
                            Order = Main.Order,
                            Buyer = Main.Buyer,
                            Owner = Main.Owner,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Buyer
                    if (join.Name.ToLower().Equals("buyer"))
                    {
                        left = left.LeftOuterJoin(context.CMS_Member, Main => Main.OrderDetail.BuyerId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            OrderDetail = Main.OrderDetail,
                            Goods = Main.Goods,
                            Order = Main.Order,
                            Buyer = Left,
                            Owner = Main.Owner,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Owner
                    if (join.Name.ToLower().Equals("owner"))
                    {
                        left = left.LeftOuterJoin(context.CMS_Member, Main => Main.OrderDetail.OwnerId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            OrderDetail = Main.OrderDetail,
                            Goods = Main.Goods,
                            Order = Main.Order,
                            Buyer = Main.Buyer,
                            Owner = Left,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.OrderDetail.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            OrderDetail = Main.OrderDetail,
                            Goods = Main.Goods,
                            Order = Main.Order,
                            Buyer = Main.Buyer,
                            Owner = Main.Owner,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    OrderDetail = Main.OrderDetail,
                    Goods = Main.Goods,
                    Order = Main.Order,
                    Buyer = Main.Buyer,
                    Owner = Main.Owner,
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
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.SQLQueryable", ex);
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
                            row.OrderDetail.OrderNo.Contains(andKeyWord) ||
                            row.OrderDetail.GoodsName.Contains(andKeyWord) ||
                            row.OrderDetail.BuyerName.Contains(andKeyWord) ||
                            row.OrderDetail.OwnerName.Contains(andKeyWord) ||
                            row.OrderDetail.Remark.Contains(andKeyWord) ||
                            row.OrderDetail.StatusName.Contains(andKeyWord)
                        );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.OrderDetail.OrderNo) ||
                            ors.Contains(row.OrderDetail.GoodsName) ||
                            ors.Contains(row.OrderDetail.BuyerName) ||
                            ors.Contains(row.OrderDetail.OwnerName) ||
                            ors.Contains(row.OrderDetail.Remark) ||
                            ors.Contains(row.OrderDetail.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.OrderDetail.OrderNo.Contains(keyWord) ||
                            row.OrderDetail.GoodsName.Contains(keyWord) ||
                            row.OrderDetail.BuyerName.Contains(keyWord) ||
                            row.OrderDetail.OwnerName.Contains(keyWord) ||
                            row.OrderDetail.Remark.Contains(keyWord) ||
                            row.OrderDetail.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.KeyWordQueryable", ex);
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
                            queryable = queryable.Where(row => row.OrderDetail.StatusId == statusId);
                        }
                        if (splits[i].ToLower().Contains("orderid"))
                        {
                            int orderId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.OrderDetail.OrderId == orderId);
                        }
                        if (splits[i].ToLower().Contains("goodsid"))
                        {
                            int goodsId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.OrderDetail.GoodsId == goodsId);
                        }
                        if (splits[i].ToLower().Contains("ownerid"))
                        {
                            int ownerId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.OrderDetail.OwnerId == ownerId);
                        }
                        if (splits[i].ToLower().Contains("buyerid"))
                        {
                            int buyerId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.OrderDetail.BuyerId == buyerId);
                        }
                        if (splits[i].ToLower().Contains("unitprice"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.OrderDetail.UnitPrice >= min && row.OrderDetail.UnitPrice <= max);
                        }
                        if (splits[i].ToLower().Contains("totalprice"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.OrderDetail.TotalPrice >= min && row.OrderDetail.TotalPrice <= max);
                        }
                        if (splits[i].ToLower().Contains("quantity"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.OrderDetail.Quantity >= min && row.OrderDetail.Quantity <= max);
                        }
                        if (splits[i].ToLower().Contains("discount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.OrderDetail.Discount >= min && row.OrderDetail.Discount <= max);
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
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.KeyWordExtQueryable", ex);
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
                                    row.OrderDetail.CreateDateTime >= date.MinDate && row.OrderDetail.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.OrderDetail.EditDateTime >= date.MinDate && row.OrderDetail.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.DateQueryable", ex);
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
                    return queryable.Where(row => status.Values.Contains(row.OrderDetail.StatusValue??0));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected OrderDetail SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                OrderDetail orderDetailEntity = entity.OrderDetail;
                // 订单
                orderDetailEntity.Order = entity.Order ?? null;
                // 商品
                orderDetailEntity.Goods = entity.Goods ?? null;
                // 买家
                orderDetailEntity.Buyer = entity.Buyer ?? null;
                // 所有者
                orderDetailEntity.Owner = entity.Owner ?? null;
                // 状态
                orderDetailEntity.Status = entity.Status ?? null;
                // 返回
                return orderDetailEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<OrderDetail> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.OrderDetailService.SQLEntityToList", ex);
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
            public OrderDetail OrderDetail { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Order Order { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Goods Goods { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Member Buyer { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Member Owner { get; set; }
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