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
    /// 下载
    /// </summary>
    public class DownController : BaseController<Down>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建下载
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Create/Single", Name = "MIS_CMS_Down_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Down entity)
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
                        new DownService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建下载
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Create/Multiple", Name = "MIS_CMS_Down_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Down> entities)
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
                        new DownService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条下载
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Update/Single", Name = "MIS_CMS_Down_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Down entity)
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
                        new DownService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条下载
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Update/Multiple", Name = "MIS_CMS_Down_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Down> entities)
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
                        new DownService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Update_Multiple", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条下载
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Delete/Single", Name = "MIS_CMS_Down_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Down entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DownService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条下载
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Delete/Multiple", Name = "MIS_CMS_Down_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Down> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DownService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询下载的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Columns/Single", Name = "MIS_CMS_Down_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new DownService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Row/ById", Name = "MIS_CMS_Down_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DownService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Row/ById/{id}", Name = "MIS_CMS_Down_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DownService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Rows/ByKeyWord", Name = "MIS_CMS_Down_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DownService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询下载
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Down_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DownService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据MemberId查询下载记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Rows/ByMemberId/{memberId}", Name = "MIS_CMS_Down_Rows_ByMemberId_MemberId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByMemberId_MemberId(int memberId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DownService.RowsService().ByMemberId(memberId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Rows_ByMemberId_MemberId", ex);
            }
        }
        /// <summary>
        /// 根据GoodsId查询下载记录
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Rows/ByGoodsId/{goodsId}", Name = "MIS_CMS_Down_Rows_ByGoodsId_GoodsId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByGoodsId_GoodsId(int goodsId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DownService.RowsService().ByGoodsId(goodsId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Rows_ByGoodsId_GoodsId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Single/ById", Name = "MIS_CMS_Down_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new DownService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Query/Page", Name = "MIS_CMS_Down_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new DownService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DownService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DownService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Tree/ByKeyWord", Name = "MIS_CMS_Down_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Down> dto)
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
                throw new Exception("MISApi.Controllers.CMS.DownController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Tree/ById", Name = "MIS_CMS_Down_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Down> dto)
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
                throw new Exception("MISApi.Controllers.CMS.DownController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Down/Tree", Name = "MIS_CMS_Down_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.DownController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询下载的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Columns/Single", Name = "Unauthorized_MIS_CMS_Down_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Row/ById", Name = "Unauthorized_MIS_CMS_Down_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Down_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Down_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询下载
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Down_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据MemberId查询下载记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Rows/ByMemberId/{memberId}", Name = "Unauthorized_MIS_CMS_Down_Rows_ByMemberId_MemberId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByMemberId_MemberId(int memberId)
        {
            try
            {
                return Rows_ByMemberId_MemberId(memberId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Rows_ByMemberId_MemberId", ex);
            }
        }
        /// <summary>
        /// 根据GoodsId查询下载记录
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Rows/ByGoodsId/{goodsId}", Name = "Unauthorized_MIS_CMS_Down_Rows_ByGoodsId_GoodsId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByGoodsId_GoodsId(int goodsId)
        {
            try
            {
                return Rows_ByGoodsId_GoodsId(goodsId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Rows_ByGoodsId_GoodsId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Single/ById", Name = "Unauthorized_MIS_CMS_Down_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询指定会员的下载记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Query/ByMemberId/{memberId}/{pageIndex}/{pageSize}", Name = "Unauthorized_MISApi_CMS_Down_Query_ByMemberId")]
        [HttpGet]
        public IActionResult Unauthorized_Query_ByMemberId(int memberId, int pageIndex, int pageSize)
        {
            try
            {
                return Query_Page(
                    new DTO_Page
                    {
                        KeyWord = $"^MemberId={memberId}",
                        Page = $"{pageIndex}^{pageSize}",
                        Status = new int[] { 1 }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Query_ByMemberId", ex);
            }
        }
        /// <summary>
        /// 分页查询下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Down/Query/Page", Name = "Unauthorized_MIS_CMS_Down_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.DownController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Down> ToResponse(Down entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Down>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Down>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Down> ToResponse(List<Down> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Down>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}