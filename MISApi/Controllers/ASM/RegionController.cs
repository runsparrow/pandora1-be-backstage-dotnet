using MISApi.CacheServices.ASM;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.ASM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using MISApi.Services.ASM;
using MISApi.Tools;
using MISApi.HttpClients.HttpModes.TreeMode.BootstrapTreeView;

namespace MISApi.Controllers.ASM
{
    /// <summary>
    /// 行政区划
    /// </summary>
    public class RegionController : BaseController<Region>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建行政区划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Create/Single", Name = "MIS_ASM_Region_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Region entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.ImportDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new RegionService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建行政区划
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Create/Multiple", Name = "MIS_ASM_Region_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Region> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity => {
                        entity.ImportDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new RegionService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条行政区划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Update/Single", Name = "MIS_ASM_Region_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Region entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.ImportDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new RegionService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条行政区划
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Update/Multiple", Name = "MIS_ASM_Region_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Region> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity =>
                    {
                        entity.ImportDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new RegionService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Update_Multiple", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条行政区划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Delete/Single", Name = "MIS_ASM_Region_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Region entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new RegionService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条行政区划
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Delete/Multiple", Name = "MIS_ASM_Region_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Region> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new RegionService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询行政区划的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Columns/Single", Name = "MIS_ASM_Region_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new RegionService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Row/ById", Name = "MIS_ASM_Region_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new RegionService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询行政区划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Row/ById/{id}", Name = "MIS_ASM_Region_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new RegionService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Rows/ByKeyWord", Name = "MIS_ASM_Region_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RegionService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询行政区划
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Rows/ByKeyWord/{keyWord}", Name = "MIS_ASM_Region_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RegionService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询行政区划子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Rows/SubsetById/{id}", Name = "MIS_ASM_Region_Rows_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new RegionService.RowsService().SubsetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Rows_SubsetById", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Single/ById", Name = "MIS_ASM_Region_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new RegionService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Query/Page", Name = "MIS_ASM_Region_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new RegionService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new RegionService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new RegionService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Tree/ByKeyWord", Name = "MIS_ASM_Region_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Region> dto)
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
                throw new Exception("MISApi.Controllers.ASM.RegionController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Tree/ById", Name = "MIS_ASM_Region_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Region> dto)
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
                throw new Exception("MISApi.Controllers.ASM.RegionController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的行政区划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Tree/SubsetById/{id}", Name = "MIS_ASM_Region_Tree_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Region>("RegionKey", "Name", "Id", "Pid", "true"),
                        Function = new BaseMode.Function
                        {
                            Name = "SubsetById",
                            Args = new BaseMode.Arg[] {
                                new BaseMode.Arg(id),
                                new BaseMode.Arg(new BaseMode.Join [] {})
                            }
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.RegionController.Tree_SubsetById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Region/Tree", Name = "MIS_ASM_Region_Tree")]
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
                throw new Exception("MISApi.Controllers.ASM.RegionController.Tree", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Region> ToResponse(Region entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Region>
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
            public class Request : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Region>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.BootstrapTreeViewResponse<Region> ToResponse(List<Region> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Region>
            {

            }
        }
        #endregion

        #endregion
    }
}