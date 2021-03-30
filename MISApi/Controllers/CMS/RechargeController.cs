using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 充值
    /// </summary>
    public class RechargeController : BaseController<Recharge>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建充值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Create/Single", Name = "MIS_CMS_Recharge_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Recharge entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {

                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new RechargeService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建充值
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Create/Multiple", Name = "MIS_CMS_Recharge_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Recharge> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity => {

                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new RechargeService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条充值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Update/Single", Name = "MIS_CMS_Recharge_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Recharge entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {

                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new RechargeService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条充值
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Update/Multiple", Name = "MIS_CMS_Recharge_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Recharge> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity =>
                    {

                    });
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new RechargeService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Update_Multiple", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条充值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Delete/Single", Name = "MIS_CMS_Recharge_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Recharge entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new RechargeService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条充值
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Delete/Multiple", Name = "MIS_CMS_Recharge_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Recharge> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new RechargeService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询充值的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Columns/Single", Name = "MIS_CMS_Recharge_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new RechargeService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Row/ById", Name = "MIS_CMS_Recharge_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new RechargeService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Row/ById/{id}", Name = "MIS_CMS_Recharge_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new RechargeService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Rows/ByKeyWord", Name = "MIS_CMS_Recharge_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RechargeService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询充值
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Recharge_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RechargeService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据MemberId查询充值记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Rows/ByMemberId/{memberId}", Name = "MIS_CMS_Recharge_Rows_ByMemberId_MemberId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByMemberId_MemberId(int memberId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RechargeService.RowsService().ByMemberId(memberId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Rows_ByMemberId_MemberId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Single/ById", Name = "MIS_CMS_Recharge_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new RechargeService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Query/Page", Name = "MIS_CMS_Recharge_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new RechargeService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new RechargeService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new RechargeService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Tree/ByKeyWord", Name = "MIS_CMS_Recharge_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Recharge> dto)
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
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Tree/ById", Name = "MIS_CMS_Recharge_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Recharge> dto)
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
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Recharge/Tree", Name = "MIS_CMS_Recharge_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询充值的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Columns/Single", Name = "Unauthorized_MIS_CMS_Recharge_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Row/ById", Name = "Unauthorized_MIS_CMS_Recharge_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Recharge_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Recharge_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询充值
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Recharge_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据MemberId查询充值记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Rows/ByMemberId/{memberId}", Name = "Unauthorized_MIS_CMS_Recharge_Rows_ByMemberId_MemberId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByMemberId_MemberId(int memberId)
        {
            try
            {
                return Rows_ByMemberId_MemberId(memberId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Rows_ByMemberId_MemberId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Single/ById", Name = "Unauthorized_MIS_CMS_Recharge_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询充值
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Recharge/Query/Page", Name = "Unauthorized_MIS_CMS_Recharge_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.RechargeController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Recharge> ToResponse(Recharge entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Recharge>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Recharge>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Recharge> ToResponse(List<Recharge> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Recharge>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}