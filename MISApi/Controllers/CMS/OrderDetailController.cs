using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderDetailController : BaseController<OrderDetail>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建订单明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Create/Single", Name = "MIS_CMS_OrderDetail_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(OrderDetail entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                    entity.CreateDateTime = DateTime.Now;
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new OrderDetailService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建订单明细
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Create/Multiple", Name = "MIS_CMS_OrderDetail_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<OrderDetail> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity => {
                        entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                        entity.CreateDateTime = DateTime.Now;
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new OrderDetailService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条订单明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Update/Single", Name = "MIS_CMS_OrderDetail_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(OrderDetail entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new OrderDetailService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条订单明细
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Update/Multiple", Name = "MIS_CMS_OrderDetail_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<OrderDetail> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity =>
                    {
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).UserId;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new OrderDetailService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Update_Multiple", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条订单明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Delete/Single", Name = "MIS_CMS_OrderDetail_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(OrderDetail entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new OrderDetailService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条订单明细
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Delete/Multiple", Name = "MIS_CMS_OrderDetail_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<OrderDetail> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new OrderDetailService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询订单明细的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Columns/Single", Name = "MIS_CMS_OrderDetail_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new OrderDetailService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Row/ById", Name = "MIS_CMS_OrderDetail_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new OrderDetailService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Row/ById/{id}", Name = "MIS_CMS_OrderDetail_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new OrderDetailService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByKeyWord", Name = "MIS_CMS_OrderDetail_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询订单明细
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_OrderDetail_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据OrderId查询订单明细
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByOrderId/{orderId}", Name = "MIS_CMS_OrderDetail_Rows_ByOrderId_OrderId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByOrderId_OrderId(int orderId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByOrderId(orderId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByOrderId_OrderId", ex);
            }
        }
        /// <summary>
        /// 根据OwnerId查询订单明细
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByOwnerId/{ownerId}", Name = "MIS_CMS_OrderDetail_Rows_ByOwnerId_OwnerId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByOwnerId_OwnerId(int ownerId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByOwnerId(ownerId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByOwnerId_OwnerId", ex);
            }
        }
        /// <summary>
        /// 根据GoodsId查询订单明细
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByGoodsId/{goodsId}", Name = "MIS_CMS_OrderDetail_Rows_ByGoodsId_GoodsId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByGoodsId_GoodsId(int goodsId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByGoodsId(goodsId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByGoodsId_GoodsId", ex);
            }
        }
        /// <summary>
        /// 根据BuyerId查询订单明细
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Rows/ByBuyerId/{buyerId}", Name = "MIS_CMS_OrderDetail_Rows_ByBuyerId_BuyerId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByBuyerId_BuyerId(int buyerId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new OrderDetailService.RowsService().ByBuyerId(buyerId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Rows_ByBuyerId_BuyerId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Single/ById", Name = "MIS_CMS_OrderDetail_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new OrderDetailService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Query/Page", Name = "MIS_CMS_OrderDetail_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new OrderDetailService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new OrderDetailService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new OrderDetailService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Tree/ByKeyWord", Name = "MIS_CMS_OrderDetail_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<OrderDetail> dto)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = dto.Config,
                        Function = new BaseMode.Function
                        {
                            Name = "ByKeyWord",
                            Args = new BaseMode.Arg[] {
                                new BaseMode.Arg(new BaseMode.KeyWord { Value = dto.KeyWord??""} ),
                                new BaseMode.Arg(new BaseMode.Join [] {})
                            }
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Tree/ById", Name = "MIS_CMS_OrderDetail_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<OrderDetail> dto)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = dto.Config,
                        Function = new BaseMode.Function
                        {
                            Name = "ById",
                            Args = new BaseMode.Arg[] {
                                new BaseMode.Arg(dto.Id),
                                new BaseMode.Arg(new BaseMode.Join [] {})
                            }
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/OrderDetail/Tree", Name = "MIS_CMS_OrderDetail_Tree")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree(TreeMode.Request request)
        {
            try
            {
                // Request验证
                if (request == null)
                {
                    throw new Exception("Request无效！");
                }
                // 返回
                return base.Post(request);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询订单明细的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Columns/Single", Name = "Unauthorized_MIS_CMS_OrderDetail_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Row/ById", Name = "Unauthorized_MIS_CMS_OrderDetail_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_OrderDetail_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询订单明细
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据OrderId查询订单明细
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByOrderId/{orderId}", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByOrderId_OrderId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByOrderId_OrderId(int orderId)
        {
            try
            {
                return Rows_ByOrderId_OrderId(orderId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByOrderId_OrderId", ex);
            }
        }
        /// <summary>
        /// 根据OwnerId查询订单明细
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByOwnerId/{ownerId}", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByOwnerId_OwnerId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByOwnerId_OwnerId(int ownerId)
        {
            try
            {
                return Rows_ByOrderId_OrderId(ownerId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByOwnerId_OwnerId", ex);
            }
        }
        /// <summary>
        /// 根据GoodsId查询订单明细
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByGoodsId/{goodsId}", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByGoodsId_GoodsId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByGoodsId_GoodsId(int goodsId)
        {
            try
            {
                return Rows_ByGoodsId_GoodsId(goodsId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByGoodsId_GoodsId", ex);
            }
        }
        /// <summary>
        /// 根据BuyerId查询订单明细
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Rows/ByBuyerId/{buyerId}", Name = "Unauthorized_MIS_CMS_OrderDetail_Rows_ByBuyerId_BuyerId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByBuyerId_BuyerId(int buyerId)
        {
            try
            {
                return Rows_ByBuyerId_BuyerId(buyerId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Rows_ByBuyerId_BuyerId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Single/ById", Name = "Unauthorized_MIS_CMS_OrderDetail_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询订单明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/OrderDetail/Query/Page", Name = "Unauthorized_MIS_CMS_OrderDetail_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.OrderDetailController.Unauthorized_Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode

        #endregion

        #endregion

        #region Mode

        #region Create
        /// <summary>
        /// 
        /// </summary>
        public class CreateMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.CreateMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        public class UpdateMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.UpdateMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        public class DeleteMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.DeleteMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Columns
        /// <summary>
        /// 
        /// </summary>
        public class ColumnsMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Row
        /// <summary>
        /// 
        /// </summary>
        public class RowMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.RowMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Rows
        /// <summary>
        /// 
        /// </summary>
        public class RowsMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.RowsMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Single
        /// <summary>
        /// 
        /// </summary>
        public class SingleMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.SingleMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<OrderDetail> ToResponse(OrderDetail entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Query
        /// <summary>
        /// 
        /// </summary>
        public class QueryMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.QueryMode.Request<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<OrderDetail>
            {

            }
        }
        #endregion

        #region Tree
        /// <summary>
        /// 
        /// </summary>
        public class TreeMode
        {
            /// <summary>
            /// 
            /// </summary>
            public class Request : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<OrderDetail>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.BootstrapTreeViewResponse<OrderDetail> ToResponse(List<OrderDetail> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<OrderDetail>
            {

            }
        }
        #endregion

        #endregion
    }
}