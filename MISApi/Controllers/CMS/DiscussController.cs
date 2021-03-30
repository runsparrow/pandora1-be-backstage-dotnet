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
    /// 评论
    /// </summary>
    public class DiscussController : BaseController<Discuss>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Create/Single", Name = "MIS_CMS_Discuss_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Discuss entity)
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
                        new DiscussService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Create/Multiple", Name = "MIS_CMS_Discuss_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Discuss> entities)
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
                        new DiscussService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Create/ToOpen", Name = "MIS_CMS_Discuss_Create_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToOpen(Discuss entity)
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
                        new DiscussService.CreateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Create_ToOpen", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Update/Single", Name = "MIS_CMS_Discuss_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Discuss entity)
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
                        new DiscussService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条评论
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Update/Multiple", Name = "MIS_CMS_Discuss_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Discuss> entities)
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
                        new DiscussService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑一条评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Update/ToOpen", Name = "MIS_CMS_Discuss_Update_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToOpen(Discuss entity)
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
                        new DiscussService.UpdateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Update_ToOpen", ex);
            }
        }
        /// <summary>
        /// 编辑一条评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Update/ToClose", Name = "MIS_CMS_Discuss_Update_ToClose")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToClose(Discuss entity)
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
                        new DiscussService.UpdateService().ToClose(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Update_ToClose", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条评论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Delete/Single", Name = "MIS_CMS_Discuss_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Discuss entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DiscussService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条评论
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Delete/Multiple", Name = "MIS_CMS_Discuss_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Discuss> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DiscussService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询评论的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Columns/Single", Name = "MIS_CMS_Discuss_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new DiscussService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Row/ById", Name = "MIS_CMS_Discuss_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DiscussService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Row/ById/{id}", Name = "MIS_CMS_Discuss_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DiscussService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Rows/ByKeyWord", Name = "MIS_CMS_Discuss_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DiscussService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询评论
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Discuss_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DiscussService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据ArticleId查询评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Article/Rows/ByArticleId/{articleId}", Name = "MIS_CMS_Article_Rows_ByArticleId_ArticleId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByArticleId_ArticleId(int articleId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DiscussService.RowsService().ByArticleId(articleId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Rows_ByArticleId_ArticleId", ex);
            }
        }
        /// <summary>
        /// 根据DiscussId查询评论
        /// </summary>
        /// <param name="discussId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Rows/ByDiscussId/{discussId}", Name = "MIS_CMS_Discuss_Rows_ByDiscussId_DiscussId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByDiscussId_DiscussId(int discussId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DiscussService.RowsService().ByDiscussId(discussId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Rows_ByDiscussId_DiscussId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询评论
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Rows/ByApproverId/{approverId}", Name = "MIS_CMS_Discuss_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DiscussService.RowsService().ByApproverId(approverId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Rows_ByApproverId_ApproverId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Single/ById", Name = "MIS_CMS_Discuss_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new DiscussService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Query/Page", Name = "MIS_CMS_Discuss_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new DiscussService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DiscussService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DiscussService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Tree/ByKeyWord", Name = "MIS_CMS_Discuss_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Discuss> dto)
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
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Tree/ById", Name = "MIS_CMS_Discuss_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Discuss> dto)
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
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Discuss/Tree", Name = "MIS_CMS_Discuss_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询评论的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Columns/Single", Name = "Unauthorized_MIS_CMS_Discuss_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Row/ById", Name = "Unauthorized_MIS_CMS_Discuss_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Discuss_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Discuss_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询评论
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Discuss_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据DiscussId查询评论
        /// </summary>
        /// <param name="discussId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Rows/ByDiscussId/{discussId}", Name = "Unauthorized_MIS_CMS_Discuss_Rows_ByDiscussId_DiscussId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByDiscussId_DiscussId(int discussId)
        {
            try
            {
                return Rows_ByDiscussId_DiscussId(discussId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Rows_ByDiscussId_DiscussId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询评论
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Rows/ByApproverId/{approverId}", Name = "Unauthorized_MIS_CMS_Discuss_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return Rows_ByApproverId_ApproverId(approverId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Rows_ByApproverId_ApproverId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Single/ById", Name = "Unauthorized_MIS_CMS_Discuss_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Discuss/Query/Page", Name = "Unauthorized_MIS_CMS_Discuss_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DiscussController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Discuss> ToResponse(Discuss entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Discuss>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Discuss>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Discuss> ToResponse(List<Discuss> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Discuss>
            {

            }
        }
        #endregion

        #endregion
    }
}