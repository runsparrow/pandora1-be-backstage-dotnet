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
using MISApi.HttpClients.HttpModes.TreeMode.AntdTree;

namespace MISApi.Controllers.ASM
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class DictionaryController : BaseController<Dictionary>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Create/Single", Name = "MIS_ASM_Dictionary_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Dictionary entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.CreateDateTime = DateTime.Now;
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new DictionaryService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建数据字典
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Create/Multiple", Name = "MIS_ASM_Dictionary_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Dictionary> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity => {
                        entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.CreateDateTime = DateTime.Now;
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new DictionaryService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Create/ToOpen", Name = "MIS_ASM_Dictionary_Create_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToOpen(Dictionary entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.CreateDateTime = DateTime.Now;
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new DictionaryService.CreateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Create_ToOpen", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Update/Single", Name = "MIS_ASM_Dictionary_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Dictionary entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new DictionaryService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条数据字典
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Update/Multiple", Name = "MIS_ASM_Dictionary_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Dictionary> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity =>
                    {
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new DictionaryService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑一条数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Update/ToOpen", Name = "MIS_ASM_Dictionary_Update_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToOpen(Dictionary entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new DictionaryService.UpdateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Update_ToOpen", ex);
            }
        }
        /// <summary>
        /// 编辑一条数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Update/ToClose", Name = "MIS_ASM_Dictionary_Update_ToClose")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToClose(Dictionary entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new DictionaryService.UpdateService().ToClose(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Update_ToClose", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条数据字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Delete/Single", Name = "MIS_ASM_Dictionary_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Dictionary entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DictionaryService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条数据字典
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Delete/Multiple", Name = "MIS_ASM_Dictionary_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Dictionary> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new DictionaryService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询数据字典的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Columns/Single", Name = "MIS_ASM_Dictionary_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new DictionaryService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Row/ById", Name = "MIS_ASM_Dictionary_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DictionaryService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Row/ById/{id}", Name = "MIS_ASM_Dictionary_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new DictionaryService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/ByKeyWord", Name = "MIS_ASM_Dictionary_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询数据字典
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/ByKeyWord/{keyWord}", Name = "MIS_ASM_Dictionary_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询数据字典子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/SubsetById/{id}", Name = "MIS_ASM_Dictionary_Rows_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().SubsetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Rows_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询数据字典父集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/SupersetById/{id}", Name = "MIS_ASM_Dictionary_Rows_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SupersetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().SupersetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Rows_SupersetById", ex);
            }
        }
        /// <summary>
        /// 根据Key查询数据字典子集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/SubsetByKey/{key}", Name = "MIS_ASM_Dictionary_Rows_SubsetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetByKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().SubsetByKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Rows_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Key查询数据字典父集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Rows/SupersetByKey/{key}", Name = "MIS_ASM_Dictionary_Rows_SupersetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SupersetByKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new DictionaryService.RowsService().SupersetByKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Rows_SupersetByKey", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Single/ById", Name = "MIS_ASM_Dictionary_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new DictionaryService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Query/Page", Name = "MIS_ASM_Dictionary_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new DictionaryService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DictionaryService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new DictionaryService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/ByKeyWord", Name = "MIS_ASM_Dictionary_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Dictionary> dto)
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
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/ById", Name = "MIS_ASM_Dictionary_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Dictionary> dto)
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
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/SubsetById/{id}", Name = "MIS_ASM_Dictionary_Tree_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Dictionary>("DictionaryKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/SupersetById/{id}", Name = "MIS_ASM_Dictionary_Tree_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Dictionary>("DictionaryKey", "Name", "Id", "Pid", "true", "false"),
                        Function = new BaseMode.Function
                        {
                            Name = "SupersetById",
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
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_SupersetById", ex);
            }
        }
        /// <summary>
        /// 根据Key查询获得树型结构的数据字典
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/SubsetByKey/{key}", Name = "MIS_ASM_Dictionary_Tree_SubsetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Dictionary>("DictionaryKey", "Name", "Id", "Pid", "true", "false"),
                        Function = new BaseMode.Function
                        {
                            Name = "SubsetByKey",
                            Args = new BaseMode.Arg[] {
                                new BaseMode.Arg(key),
                                new BaseMode.Arg(new BaseMode.Join [] {})
                            }
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Key查询获得树型结构的数据字典
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree/SupersetByKey/{key}", Name = "MIS_ASM_Dictionary_Tree_SupersetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Dictionary>("DictionaryKey", "Name", "Id", "Pid", "true", "false"),
                        Function = new BaseMode.Function
                        {
                            Name = "SupersetByKey",
                            Args = new BaseMode.Arg[] {
                                new BaseMode.Arg(key),
                                new BaseMode.Arg(new BaseMode.Join [] {})
                            }
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree_SupersetByKey", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Dictionary/Tree", Name = "MIS_ASM_Dictionary_Tree")]
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
                throw new Exception("MISApi.Controllers.ASM.DictionaryController.Tree", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Dictionary> ToResponse(Dictionary entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Dictionary>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Dictionary>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Dictionary> ToResponse(List<Dictionary> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Dictionary>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}