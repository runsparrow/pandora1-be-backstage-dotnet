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
    /// 提现
    /// </summary>
    public class CashOutController : BaseController<CashOut>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建提现
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Create/Single", Name = "MIS_CMS_CashOut_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(CashOut entity)
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
                        new CashOutService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建提现
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Create/Multiple", Name = "MIS_CMS_CashOut_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<CashOut> entities)
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
                        new CashOutService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建提现
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Create/ToOpen", Name = "MIS_CMS_CashOut_Create_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToOpen(CashOut entity)
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
                        new CashOutService.CreateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Create_ToOpen", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条提现信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/Single", Name = "MIS_CMS_CashOut_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(CashOut entity)
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
                        new CashOutService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条提现信息
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/Multiple", Name = "MIS_CMS_CashOut_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<CashOut> entities)
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
                        new CashOutService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 开启提现申请
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToOpen", Name = "MIS_CMS_CashOut_Update_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToOpen(CashOut entity)
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
                        new CashOutService.UpdateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToOpen", ex);
            }
        }
        /// <summary>
        /// 关闭提现申请
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToClose", Name = "MIS_CMS_CashOut_Update_ToClose")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToClose(CashOut entity)
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
                        new CashOutService.UpdateService().ToClose(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToClose", ex);
            }
        }
        /// <summary>
        /// 提交提现申请
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToSubmit", Name = "MIS_CMS_CashOut_Update_ToSubmit")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToSubmit(CashOut entity)
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
                        new CashOutService.UpdateService().ToSubmit(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToSubmit", ex);
            }
        }
        /// <summary>
        /// 通过提现申请
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToApproverPass", Name = "MIS_CMS_CashOut_Update_ToApproverPass")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToApproverPass(CashOut entity)
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
                        new CashOutService.UpdateService().ToApproverPass(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToApproverPass", ex);
            }
        }
        /// <summary>
        /// 拒绝提现申请
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToApproverRefuse", Name = "MIS_CMS_CashOut_Update_ToApproverRefuse")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToApproverRefuse(CashOut entity)
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
                        new CashOutService.UpdateService().ToApproverRefuse(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToApproverRefuse", ex);
            }
        }
        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Update/ToLoan", Name = "MIS_CMS_CashOut_Update_ToLoan")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToLoan(CashOut entity)
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
                        new CashOutService.UpdateService().ToLoan(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Update_ToLoan", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条提现信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Delete/Single", Name = "MIS_CMS_CashOut_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(CashOut entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new CashOutService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条提现信息
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Delete/Multiple", Name = "MIS_CMS_CashOut_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<CashOut> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new CashOutService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询提现的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Columns/Single", Name = "MIS_CMS_CashOut_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new CashOutService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Row/ById", Name = "MIS_CMS_CashOut_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new CashOutService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Row/ById/{id}", Name = "MIS_CMS_CashOut_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new CashOutService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Rows/ByKeyWord", Name = "MIS_CMS_CashOut_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CashOutService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询提现
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_CashOut_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CashOutService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据ApplierId查询提现记录
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Rows/ByApplierId/{applierId}", Name = "MIS_CMS_CashOut_Rows_ByApplierId_ApplierId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByApplierId_ApplierId(int applierId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CashOutService.RowsService().ByApplierId(applierId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Rows_ByApplierId_ApplierId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询提现记录
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Rows/ByApproverId/{approverId}", Name = "MIS_CMS_CashOut_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CashOutService.RowsService().ByApproverId(approverId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Rows_ByApproverId_ApproverId", ex);
            }
        }
        /// <summary>
        /// 根据LoanerId查询提现记录
        /// </summary>
        /// <param name="loanerId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Rows/ByLoanerId/{loanerId}", Name = "MIS_CMS_CashOut_Rows_ByLoanerId_LoanerId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByLoanerId_LoanerId(int loanerId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new CashOutService.RowsService().ByLoanerId(loanerId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Rows_ByLoanerId_LoanerId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Single/ById", Name = "MIS_CMS_CashOut_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new CashOutService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Query/Page", Name = "MIS_CMS_CashOut_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new CashOutService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new CashOutService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new CashOutService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Tree/ByKeyWord", Name = "MIS_CMS_CashOut_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<CashOut> dto)
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
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Tree/ById", Name = "MIS_CMS_CashOut_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<CashOut> dto)
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
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/CashOut/Tree", Name = "MIS_CMS_CashOut_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询提现的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Columns/Single", Name = "Unauthorized_MIS_CMS_CashOut_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Row/ById", Name = "Unauthorized_MIS_CMS_CashOut_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_CashOut_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_CashOut_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询提现
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_CashOut_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据ApplierId查询提现记录
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Rows/ByApplierId/{applierId}", Name = "Unauthorized_MIS_CMS_CashOut_Rows_ByApplierId_ApplierId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByApplierId_ApplierId(int applierId)
        {
            try
            {
                return Rows_ByApplierId_ApplierId(applierId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Rows_ByApplierId_ApplierId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询提现记录
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Rows/ByApproverId/{approverId}", Name = "Unauthorized_MIS_CMS_CashOut_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return Rows_ByApproverId_ApproverId(approverId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Rows_ByApproverId_ApproverId", ex);
            }
        }
        /// <summary>
        /// 根据LoanerId查询提现记录
        /// </summary>
        /// <param name="loanerId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Rows/ByLoanerId/{loanerId}", Name = "Unauthorized_MIS_CMS_CashOut_Rows_ByLoanerId_LoanerId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByLoanerId_LoanerId(int loanerId)
        {
            try
            {
                return Rows_ByLoanerId_LoanerId(loanerId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Rows_ByLoanerId_LoanerId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Single/ById", Name = "Unauthorized_MIS_CMS_CashOut_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询提现
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/CashOut/Query/Page", Name = "Unauthorized_MIS_CMS_CashOut_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.CashOutController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<CashOut> ToResponse(CashOut entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<CashOut>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<CashOut>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<CashOut> ToResponse(List<CashOut> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<CashOut>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}