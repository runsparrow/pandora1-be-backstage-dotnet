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
    /// 会员
    /// </summary>
    public class MemberController : BaseController<Member>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建会员
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Create/Single", Name = "MIS_CMS_Member_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Member entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.Password = EncryptHelper.GetBase64String(entity.Password);
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new MemberService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建会员
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Create/Multiple", Name = "MIS_CMS_Member_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Member> entities)
        {
            try
            {
                // Entities
                if (entities != null)
                {
                    entities.ForEach(entity => {
                        entity.Password = EncryptHelper.GetBase64String(entity.Password);
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new MemberService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Create_Multiple", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条会员
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Update/Single", Name = "MIS_CMS_Member_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Member entity)
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
                        new MemberService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条会员
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Update/Multiple", Name = "MIS_CMS_Member_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Member> entities)
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
                        new MemberService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Update/Password", Name = "MIS_CMS_Member_Update_Password")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Password(Member entity)
        {
            try
            {
                // Entity
                if (entity != null)
                {
                    entity.Password = EncryptHelper.GetBase64String(entity.Password);
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new MemberService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Update_Password", ex);
            }
        }
        /// <summary>
        /// 编辑一条会员
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Update/ToOpen", Name = "MIS_CMS_Member_Update_ToOpen")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToOpen(Member entity)
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
                        new MemberService.UpdateService().ToOpen(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Update_ToOpen", ex);
            }
        }
        /// <summary>
        /// 编辑一条会员
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Update/ToClose", Name = "MIS_CMS_Member_Update_ToClose")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToClose(Member entity)
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
                        new MemberService.UpdateService().ToClose(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Update_ToClose", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条会员
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Delete/Single", Name = "MIS_CMS_Member_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Member entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new MemberService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条会员
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Delete/Multiple", Name = "MIS_CMS_Member_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Member> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new MemberService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询会员的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Columns/Single", Name = "MIS_CMS_Member_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new MemberService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Row/ById", Name = "MIS_CMS_Member_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new MemberService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Row/ById/{id}", Name = "MIS_CMS_Member_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new MemberService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Rows/ByKeyWord", Name = "MIS_CMS_Member_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new MemberService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询会员
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Member_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new MemberService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Single/ById", Name = "MIS_CMS_Member_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new MemberService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Query/Page", Name = "MIS_CMS_Member_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new MemberService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new MemberService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new MemberService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Tree/ByKeyWord", Name = "MIS_CMS_Member_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Member> dto)
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
                throw new Exception("MISApi.Controllers.CMS.MemberController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Tree/ById", Name = "MIS_CMS_Member_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Member> dto)
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
                throw new Exception("MISApi.Controllers.CMS.MemberController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Member/Tree", Name = "MIS_CMS_Member_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.MemberController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        //#region CreateMode
        ///// <summary>
        ///// 注册会员
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[Route("Unauthorized/MIS/CMS/Member/Create/Regist", Name = "Unauthorized_MIS_CMS_Member_Create_Regist")]
        //[HttpPost]
        //public IActionResult Unauthorized_Create_Regist(Member entity)
        //{
        //    try
        //    {
        //        // Entity
        //        if (entity != null)
        //        {
        //            entity.Password = EncryptHelper.GetBase64String(entity.Password);
        //            entity.RegistDateTime = DateTime.Now;
        //            if (string.IsNullOrEmpty(entity.Name))
        //            {
        //                entity.Name = RandHelper.GenerateRandomAlphabet(12);
        //            }
        //        }
        //        var existMember = new MemberService.RowService().ByMobile(entity.Mobile);
        //        if (existMember == null)
        //        {
        //            var member = new MemberService.CreateService().Regist(entity);
        //            // 返回
        //            return new JsonResult(new DTO_Result
        //            {
        //                Result = true,
        //                UserInfo = null,
        //                MemberInfo = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName }
        //            });
        //        }
        //        else
        //        {
        //            return new JsonResult(new DTO_Result
        //            {
        //                Result = false,
        //                UserInfo = null,
        //                MemberInfo = new DTO_Member { MemberId = existMember.Id, MemberName = existMember.Name, RealName = existMember.RealName },
        //                ErrorInfo = "手机号已被注册。"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new DTO_Result
        //        {
        //            Result = false,
        //            UserInfo = null,
        //            MemberInfo = null,
        //            ErrorInfo = ex.InnerException.Message
        //        });
        //    }
        //}

        //#endregion

        //#region UpdateMode
        ///// <summary>
        ///// 忘记密码
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[Route("Unauthorized/MIS/CMS/Member/Update/Forget", Name = "Unauthorized_MIS_CMS_Member_Update_Forget")]
        //[HttpPost]
        //public IActionResult Unauthorized_Update_Forget(Member entity)
        //{
        //    try
        //    {
        //        var member = new Member();
        //        // Entity
        //        if (entity != null)
        //        {
        //            member = new MemberService.RowService().ByMobile(entity.Mobile);
        //            member.Password = EncryptHelper.GetBase64String(entity.Password);
        //        }
        //        // 提交
        //        member = new MemberService.UpdateService().Execute(member);
        //        // 返回
        //        return new JsonResult(new DTO_Result
        //        {
        //            Result = true,
        //            UserInfo = null,
        //            MemberInfo = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new DTO_Result
        //        {
        //            Result = false,
        //            UserInfo = null,
        //            MemberInfo = null,
        //            ErrorInfo = ex.InnerException.Message
        //        });
        //    }
        //}
        //#endregion

        #region ColumnsMode
        /// <summary>
        /// 查询会员的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Columns/Single", Name = "Unauthorized_MIS_CMS_Member_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Row/ById", Name = "Unauthorized_MIS_CMS_Member_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Member_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Row_ById_Id", ex);
            }
        }
        /// <summary>
        /// 验证会员名是否被注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Row/ByName/{name}/{id}", Name = "Unauthorized_MIS_CMS_Member_Row_ByName_Name_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ByName_Name_Id(string name, int id)
        {
            try
            {
                var member = new MemberService.RowService().ByName(name, id);
                if (member == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        UserInfo = null,
                        MemberInfo = null,
                        SuccessInfo = "未发现重复会员名。"
                    });
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = true,
                        UserInfo = null,
                        MemberInfo = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName },
                        SuccessInfo = "发现重复会员名。"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Row_ByName_Name_Id", ex);
            }
        }
        /// <summary>
        /// 验证手机是否被注册
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Row/ByMobile/{mobile}", Name = "Unauthorized_MIS_CMS_Member_Row_ByMobile_Mobile")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ByMobile_Mobile(string mobile)
        {
            try
            {
                var member = new MemberService.RowService().ByMobile(mobile);
                if (member == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        UserInfo = null,
                        MemberInfo = null,
                        SuccessInfo = "未发现重复手机号。"
                    });
                }
                else
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = true,
                        UserInfo = null,
                        MemberInfo = new DTO_Member { MemberId = member.Id, MemberName = member.Name, RealName = member.RealName },
                        SuccessInfo = "发现重复手机号。"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Row_ByMobile_Mobile", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Member_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询会员
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Member_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Single/ById", Name = "Unauthorized_MIS_CMS_Member_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询会员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Member/Query/Page", Name = "Unauthorized_MIS_CMS_Member_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.MemberController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Member> ToResponse(Member entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Member>
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
            public class Request : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Member>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.BootstrapTreeViewResponse<Member> ToResponse(List<Member> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<Member>
            {

            }
        }
        #endregion

        #endregion
    }
}