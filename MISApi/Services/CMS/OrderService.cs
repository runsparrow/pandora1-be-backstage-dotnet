using MISApi.CacheServices.WFM;
using MISApi.Dal.EF;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.OrderService.CreateService
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
            public virtual Order ToOpen(Order entity)
            {
                try
                {
                    // 定义
                    Order result = new Order();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByCode("cms.order.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = new OrderService.CreateService().Execute(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.OrderService.CreateService.ToOpen", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.OrderService.UpdateService
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
            public virtual Order ToOpen(Order entity)
            {
                try
                {
                    // 定义
                    Order result = new Order();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.order.open");
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
                    throw new Exception("MISApi.Services.CMS.OrderService.UpdateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 关闭
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Order ToClose(Order entity)
            {
                try
                {
                    // 定义
                    Order result = new Order();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.order.close");
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
                    throw new Exception("MISApi.Services.CMS.OrderService.UpdateService.ToClose", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.OrderService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.OrderService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.OrderService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.OrderService.RowsService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ownerId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Order> ByOwnerId(int ownerId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Order.OwnerId == ownerId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.OrderService.RowService.ByOwnerId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="goodsId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Order> ByGoodsId(int goodsId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Order.GoodsId == goodsId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.OrderService.RowService.ByGoodsId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="buyerId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Order> ByBuyerId(int buyerId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Order.BuyerId == buyerId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.OrderService.RowService.ByBuyerId", ex);
                    }
                }
            }
        }

        #endregion
    }
}