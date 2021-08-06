using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.CMS;
using MISApi.Services.CMS;
using MISApi.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.CMS
{
    /// <summary>
    /// 发卡
    /// </summary>
    public class CardController : BaseController<Card>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建发卡
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Create/Single", Name = "MIS_CMS_Card_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Card entity)
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
                        new CardService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建发卡
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Create/Multiple", Name = "MIS_CMS_Card_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Card> entities)
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
                        new CardService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建发卡并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Create/ToStatus", Name = "MIS_CMS_Card_Create_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToStatus(DTO_EntityToStatus<Card> dto)
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
                        new CardService.CreateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Create_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量创建发卡并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Create/BatchToStatus", Name = "MIS_CMS_Card_Create_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_BatchToStatus(DTO_EntitiesToStatus<Card> dto)
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
                        new CardService.CreateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Create_BatchToStatus", ex);
            }
        }
        /// <summary>
        /// 批量发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Create/Batch", Name = "MIS_CMS_Card_Create_Batch")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Batch(DTO_Batch dto)
        {
            try
            {
                List<Card> entities = new List<Card>();
                // Entity
                if (dto.Entity != null)
                {
                    for(var i=0; i<dto.CardQuantity; i++)
                    {
                        entities.Add(new Card
                        {
                            CardPrefix = dto.Entity.CardPrefix,
                            DaysLimit = dto.Entity.DaysLimit,
                            IsBuy = dto.Entity.IsBuy,
                            IsDown = dto.Entity.IsDown,
                            IsUpload = dto.Entity.IsUpload,
                            BuyLimit = dto.Entity.BuyLimit,
                            DownLimit = dto.Entity.DownLimit,
                            UploadLimit = dto.Entity.UploadLimit,
                            CardNo = $"{dto.Entity.CardPrefix}{ConvertHelper.DateTimeToInt(DateTime.Now)}{RandHelper.GenerateRandomNumber(3)}",
                            CardPassword = $"{RandHelper.GenerateRandomNumber(12)}",
                            CardDate = DateTime.Now,
                            CreateUserId = AuthHelper.GetClaimFromToken(Token).Id,
                            CreateDateTime = DateTime.Now,
                            EditUserId = AuthHelper.GetClaimFromToken(Token).Id,
                            EditDateTime = DateTime.Now,
                            IsActivate = false
                        });
                    }
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new CardService.CreateService().BatchToStatus(entities, "cms.card.open")
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Create_BatchToStatus", ex);
            }
        }

        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条发卡
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Update/Single", Name = "MIS_CMS_Card_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Card entity)
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
                        new CardService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条发卡
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Update/Multiple", Name = "MIS_CMS_Card_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Card> entities)
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
                        new CardService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Update/ToStatus", Name = "MIS_CMS_Card_Update_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToStatus(DTO_EntityToStatus<Card> dto)
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
                        new CardService.UpdateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Update_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Update/BatchToStatus", Name = "MIS_CMS_Card_Update_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_BatchToStatus(DTO_EntitiesToStatus<Card> dto)
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
                        new CardService.UpdateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Update_BatchToStatus", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条发卡
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Delete/Single", Name = "MIS_CMS_Card_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Card entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new CardService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条发卡
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Delete/Multiple", Name = "MIS_CMS_Card_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Card> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new CardService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询发卡的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Columns/Single", Name = "MIS_CMS_Card_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new CardService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Row/ById", Name = "MIS_CMS_Card_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new CardService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Row/ById/{id}", Name = "MIS_CMS_Card_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new CardService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Rows/ByKeyWord", Name = "MIS_CMS_Card_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CardService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询发卡
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Card_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CardService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Single/ById", Name = "MIS_CMS_Card_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new CardService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Query/Page", Name = "MIS_CMS_Card_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new CardService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new CardService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new CardService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Tree/ByKeyWord", Name = "MIS_CMS_Card_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Card> dto)
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
                throw new Exception("MISApi.Controllers.CMS.CardController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Tree/ById", Name = "MIS_CMS_Card_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Card> dto)
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
                throw new Exception("MISApi.Controllers.CMS.CardController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Card/Tree", Name = "MIS_CMS_Card_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.CardController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询发卡的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Columns/Single", Name = "Unauthorized_MISApi_CMS_Card_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Row/ById", Name = "Unauthorized_MISApi_CMS_Card_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Row/ById/{id}", Name = "Unauthorized_MISApi_CMS_Card_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Rows/ByKeyWord", Name = "Unauthorized_MISApi_CMS_Card_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询发卡
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MISApi_CMS_Card_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Single/ById", Name = "Unauthorized_MISApi_CMS_Card_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询指定导航下的发卡
        /// </summary>
        /// <param name="navigationId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Query/ByNavigationId/{navigationId}/{pageIndex}/{pageSize}", Name = "Unauthorized_MISApi_CMS_Card_Query_ByNavigationId")]
        [HttpGet]
        public IActionResult Unauthorized_Query_ByNavigationId(int navigationId, int pageIndex, int pageSize)
        {
            try
            {
                return Query_Page(
                    new DTO_Page
                    {
                        KeyWord = $"^NavigationId={navigationId}",
                        Page = $"{pageIndex}^{pageSize}",
                        Status = new int[] { 1 }
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Query_ByNavigationId", ex);
            }
        }
        /// <summary>
        /// 分页查询发卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Card/Query/Page", Name = "Unauthorized_MISApi_CMS_Card_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CardController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Card> ToResponse(Card entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Card>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Card>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Card> ToResponse(List<Card> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Card>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        /// <summary>
        /// 
        /// </summary>
        public class DTO_Batch
        {
            /// <summary>
            /// 发卡信息
            /// </summary>
            [Description("发卡信息")]
            [JsonProperty("entity")]
            public Card Entity { get; set; } = new Card();
            /// <summary>
            /// 发卡数量
            /// </summary>
            [Description("发卡数量")]
            [JsonProperty("cardQuantity")]
            public int CardQuantity { get; set; } = 0;
        }

        #endregion
    }
}