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
    /// 认证
    /// </summary>
    public class AuthController : BaseController<Auth>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Create/Single", Name = "MIS_CMS_Auth_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Auth entity)
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
                        new AuthService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Create/Multiple", Name = "MIS_CMS_Auth_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Auth> entities)
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
                        new AuthService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Update/Single", Name = "MIS_CMS_Auth_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Auth entity)
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
                        new AuthService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Update/Multiple", Name = "MIS_CMS_Auth_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Auth> entities)
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
                        new AuthService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Update_Multiple", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Delete/Single", Name = "MIS_CMS_Auth_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Auth entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new AuthService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Delete/Multiple", Name = "MIS_CMS_Auth_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Auth> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new AuthService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询认证的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Columns/Single", Name = "MIS_CMS_Auth_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new AuthService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Row/ById", Name = "MIS_CMS_Auth_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new AuthService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Row/ById/{id}", Name = "MIS_CMS_Auth_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new AuthService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Rows/ByKeyWord", Name = "MIS_CMS_Auth_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Auth_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Single/ById", Name = "MIS_CMS_Auth_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new AuthService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Query/Page", Name = "MIS_CMS_Auth_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new AuthService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new AuthService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new AuthService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Tree/ByKeyWord", Name = "MIS_CMS_Auth_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Auth> dto)
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
                throw new Exception("MISApi.Controllers.CMS.AuthController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Tree/ById", Name = "MIS_CMS_Auth_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Auth> dto)
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
                throw new Exception("MISApi.Controllers.CMS.AuthController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Auth/Tree", Name = "MIS_CMS_Auth_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.AuthController.Tree", ex);
            }
        }
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Auth> ToResponse(Auth entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Auth>
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
            public class Request : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Auth>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.BootstrapTreeViewResponse<Auth> ToResponse(List<Auth> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Auth>
            {

            }
        }
        #endregion

        #endregion
    }
}