using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.ASM;
using MISApi.HttpClients.HttpModes.TreeMode.AntdTree;
using MISApi.Services.ASM;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.ASM
{
    /// <summary>
    /// 医院
    /// </summary>
    public class HospitalController : BaseController<Hospital>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建医院
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Create/Single", Name = "MIS_ASM_Hospital_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Hospital entity)
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
                        new HospitalService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建医院
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Create/Multiple", Name = "MIS_ASM_Hospital_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Hospital> entities)
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
                        new HospitalService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建医院并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Create/ToStatus", Name = "MIS_ASM_Hospital_Create_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToStatus(DTO_EntityToStatus<Hospital> dto)
        {
            try
            {
                // Entity
                if (dto.Entity != null)
                {
                    dto.Entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.CreateDateTime = DateTime.Now;
                    dto.Entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new HospitalService.CreateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Create_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量创建医院并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Create/BatchToStatus", Name = "MIS_ASM_Hospital_Create_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_BatchToStatus(DTO_EntitiesToStatus<Hospital> dto)
        {
            try
            {
                // Entity
                if (dto.Entities != null)
                {
                    dto.Entities.ForEach(entity => {
                        entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.CreateDateTime = DateTime.Now;
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new HospitalService.CreateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Create_BatchToStatus", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条医院
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Update/Single", Name = "MIS_ASM_Hospital_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Hospital entity)
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
                        new HospitalService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条医院
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Update/Multiple", Name = "MIS_ASM_Hospital_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Hospital> entities)
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
                        new HospitalService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Update/ToStatus", Name = "MIS_ASM_Hospital_Update_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToStatus(DTO_EntityToStatus<Hospital> dto)
        {
            try
            {
                // Entity
                if (dto.Entity != null)
                {
                    dto.Entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new HospitalService.UpdateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Update_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Update/BatchToStatus", Name = "MIS_ASM_Hospital_Update_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_BatchToStatus(DTO_EntitiesToStatus<Hospital> dto)
        {
            try
            {
                // Entity
                if (dto.Entities != null)
                {
                    dto.Entities.ForEach(entity =>
                    {
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new HospitalService.UpdateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Update_BatchToStatus", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条医院
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Delete/Single", Name = "MIS_ASM_Hospital_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Hospital entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new HospitalService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条医院
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Delete/Multiple", Name = "MIS_ASM_Hospital_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Hospital> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new HospitalService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询医院的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Columns/Single", Name = "MIS_ASM_Hospital_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new HospitalService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Row/ById", Name = "MIS_ASM_Hospital_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new HospitalService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询医院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Row/ById/{id}", Name = "MIS_ASM_Hospital_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new HospitalService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/ByKeyWord", Name = "MIS_ASM_Hospital_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询医院
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/ByKeyWord/{keyWord}", Name = "MIS_ASM_Hospital_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Pid查询医院子集
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/ByPid/{pid}", Name = "MIS_ASM_Hospital_Rows_ByPid_Pid")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByPid(int pid)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().ByPid(pid)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_ByPid", ex);
            }
        }
        /// <summary>
        /// 根据父节点键名查询医院子集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/ByParentKey/{key}", Name = "MIS_ASM_Hospital_Rows_ByParentKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByParentKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().ByParentKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_ByParentKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询医院子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/SubsetById/{id}", Name = "MIS_ASM_Hospital_Rows_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().SubsetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询医院父集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/SupersetById/{id}", Name = "MIS_ASM_Hospital_Rows_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SupersetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().SupersetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_SupersetById", ex);
            }
        }
        /// <summary>
        /// 根据Key查询医院子集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/SubsetByKey/{key}", Name = "MIS_ASM_Hospital_Rows_SubsetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetByKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().SubsetByKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Key查询医院父集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Rows/SupersetByKey/{key}", Name = "MIS_ASM_Hospital_Rows_SupersetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SupersetByKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new HospitalService.RowsService().SupersetByKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Rows_SupersetByKey", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Single/ById", Name = "MIS_ASM_Hospital_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new HospitalService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Query/Page", Name = "MIS_ASM_Hospital_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new HospitalService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new HospitalService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new HospitalService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/ByKeyWord", Name = "MIS_ASM_Hospital_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Hospital> dto)
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的医院
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/ById", Name = "MIS_ASM_Hospital_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Hospital> dto)
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 根据键名查询获得树型结构的医院
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/SubsetByKey/{key}", Name = "MIS_ASM_Hospital_Tree_SubsetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Hospital>("HospitalKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据键名查询获得树型结构的医院
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/SupersetByKey/{key}", Name = "MIS_ASM_Hospital_Tree_SupersetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Hospital>("HospitalKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_SupersetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的医院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/SubsetById/{id}", Name = "MIS_ASM_Hospital_Tree_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Hospital>("HospitalKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的医院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree/SupersetById/{id}", Name = "MIS_ASM_Hospital_Tree_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Hospital>("HospitalKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree_SupersetById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/ASM/Hospital/Tree", Name = "MIS_ASM_Hospital_Tree")]
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
                throw new Exception("MISApi.Controllers.ASM.HospitalController.Tree", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Hospital> ToResponse(Hospital entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Hospital>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Hospital>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Hospital> ToResponse(List<Hospital> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Hospital>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}