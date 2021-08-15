using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.HttpClients.HttpModes.TreeMode.AntdTree;
using MISApi.Services.CMS;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 导航
    /// </summary>
    public class NavigationController : BaseController<Navigation>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建导航
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Create/Single", Name = "MIS_CMS_Navigation_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Navigation entity)
        {
            try
            {
                // 默认值
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
                        new NavigationService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建导航
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Create/Multiple", Name = "MIS_CMS_Navigation_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Navigation> entities)
        {
            try
            {
                // 默认值
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
                        new NavigationService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建栏目并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Create/ToStatus", Name = "MIS_CMS_Navigation_Create_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToStatus(DTO_EntityToStatus<Navigation> dto)
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
                        new NavigationService.CreateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Create_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量创建栏目并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Create/BatchToStatus", Name = "MIS_CMS_Navigation_Create_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_BatchToStatus(DTO_EntitiesToStatus<Navigation> dto)
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
                        new NavigationService.CreateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Create_BatchToStatus", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条导航
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Update/Single", Name = "MIS_CMS_Navigation_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Navigation entity)
        {
            try
            {
                // 默认值
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new NavigationService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条导航
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Update/Multiple", Name = "MIS_CMS_Navigation_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Navigation> entities)
        {
            try
            {
                // 默认值
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
                        new NavigationService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Update/ToStatus", Name = "MIS_CMS_Navigation_Update_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToStatus(DTO_EntityToStatus<Navigation> dto)
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
                        new NavigationService.UpdateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Update_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Update/BatchToStatus", Name = "MIS_CMS_Navigation_Update_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_BatchToStatus(DTO_EntitiesToStatus<Navigation> dto)
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
                        new NavigationService.UpdateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Update_BatchToStatus", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条导航
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Delete/Single", Name = "MIS_CMS_Navigation_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Navigation entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new NavigationService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条导航
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Delete/Multiple", Name = "MIS_CMS_Navigation_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Navigation> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new NavigationService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询导航的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Columns/Single", Name = "MIS_CMS_Navigation_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new NavigationService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Row/ById", Name = "MIS_CMS_Navigation_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new NavigationService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Row/ById/{id}", Name = "MIS_CMS_Navigation_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new NavigationService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/ByKeyWord", Name = "MIS_CMS_Navigation_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询导航
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Navigation_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Pid查询导航子集
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/ByPid/{pid}", Name = "MIS_CMS_Navigation_Rows_ByPid_Pid")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByPid(int pid)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().ByPid(pid)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_ByPid", ex);
            }
        }
        /// <summary>
        /// 根据父节点键名查询导航子集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/ByParentKey/{key}", Name = "MIS_CMS_Navigation_Rows_ByParentKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByParentKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().ByParentKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_ByParentKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/SubsetById/{id}", Name = "MIS_CMS_Navigation_Rows_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SubsetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().SubsetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航父集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Rows/SupersetById/{id}", Name = "MIS_CMS_Navigation_Rows_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_SupersetById(int id)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().SupersetById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Rows_SupersetById", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Single/ById", Name = "MIS_CMS_Navigation_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new NavigationService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Query/Page", Name = "MIS_CMS_Navigation_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new NavigationService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new NavigationService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new NavigationService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/ByKeyWord", Name = "MIS_CMS_Navigation_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Navigation> dto)
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/ById", Name = "MIS_CMS_Navigation_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Navigation> dto)
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 根据键名查询获得树型结构的导航
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/SubsetByKey/{key}", Name = "MIS_CMS_Navigation_Tree_SubsetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据键名查询获得树型结构的导航
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/SupersetByKey/{key}", Name = "MIS_CMS_Navigation_Tree_SupersetByKey_Key")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_SupersetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/SubsetById/{id}", Name = "MIS_CMS_Navigation_Tree_SubsetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SubsetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree/SupersetById/{id}", Name = "MIS_CMS_Navigation_Tree_SupersetById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Tree_SupersetById(int id)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree_SupersetById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Navigation/Tree", Name = "MIS_CMS_Navigation_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询导航的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Columns/Single", Name = "Unauthorized_MIS_CMS_Navigation_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Row/ById", Name = "Unauthorized_MIS_CMS_Navigation_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Navigation_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Navigation_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询导航
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Navigation_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据父节点键名查询导航子集
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Rows/ByParentKey/{key}", Name = "Unauthorized_MIS_CMS_Navigation_Rows_ByParentKey_Key")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByParentKey(string key)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new NavigationService.RowsService().ByParentKey(key)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Rows_ByParentKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Rows/SubsetById/{id}", Name = "Unauthorized_MIS_CMS_Navigation_Rows_SubsetById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_SubsetById(int id)
        {
            try
            {
                return Rows_SubsetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Rows_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询导航父集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Rows/SupersetById/{id}", Name = "Unauthorized_MIS_CMS_Navigation_Rows_SupersetById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_SupersetById(int id)
        {
            try
            {
                return Rows_SupersetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Rows_SupersetById", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Single/ById", Name = "Unauthorized_MIS_CMS_Navigation_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询导航
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Query/Page", Name = "Unauthorized_MIS_CMS_Navigation_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode

        /// <summary>
        /// 根据键名查询获得树型结构的导航
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Tree/SubsetByKey/{key}", Name = "Unauthorized_MIS_CMS_Navigation_Tree_SubsetByKey_Key")]
        [HttpGet]
        public IActionResult Unauthorized_Tree_SubsetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Tree_SubsetByKey", ex);
            }
        }
        /// <summary>
        /// 根据键名查询获得树型结构的导航
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Tree/SupersetByKey/{key}", Name = "Unauthorized_MIS_CMS_Navigation_Tree_SupersetByKey_Key")]
        [HttpGet]
        public IActionResult Unauthorized_Tree_SupersetByKey(string key)
        {
            try
            {
                return Tree(
                    new TreeMode.Request
                    {
                        Config = new Config<Navigation>("NavigationKey", "Name", "Id", "Pid", "true", "false"),
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
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Tree_SupersetByKey", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Tree/SubsetById/{id}", Name = "Unauthorized_MIS_CMS_Navigation_Tree_SubsetById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Tree_SubsetById(int id)
        {
            try
            {
                return Tree_SubsetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Tree_SubsetById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Navigation/Tree/SupersetById/{id}", Name = "Unauthorized_MIS_CMS_Navigation_Tree_SupersetById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Tree_SupersetById(int id)
        {
            try
            {
                return Tree_SupersetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.NavigationController.Unauthorized_Tree_SupersetById", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Navigation> ToResponse(Navigation entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Navigation>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Navigation>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Navigation> ToResponse(List<Navigation> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Navigation>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }


}