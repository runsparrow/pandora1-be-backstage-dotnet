﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISApi.Controllers.HttpEntities;
using MISApi.Entities.AVM;
using MISApi.Services.AVM;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;

namespace MISApi.Controllers.AVM
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserController : BaseController<User>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Create/Single", Name = "MIS_AVM_User_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(User entity)
        {
            try
            {
                // Entity空值
                if (entity == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entity为空。"
                    });
                }
                // 重复用户名
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    List<User> existUser = new UserService.RowsService().ByName(entity.Name);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复用户名的数据。"
                        });
                    }
                }
                // 重复手机号
                if (!string.IsNullOrEmpty(entity.Mobile))
                {
                    List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复手机号的数据。"
                        });
                    }
                }
                // 默认值
                if (entity != null)
                {
                    entity.Password = EncryptHelper.GetBase64String(entity.Password);
                    entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.CreateDateTime = DateTime.Now;
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new UserService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Create/Multiple", Name = "MIS_AVM_User_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<User> entities)
        {
            try
            {
                // Entities空值
                if (entities == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entities为空。"
                    });
                }
                // 重复数据
                foreach (User entity in entities)
                {
                    // 用户名
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        List<User> existUser = new UserService.RowsService().ByName(entity.Name);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复用户名的数据。"
                            });
                        }
                    }
                    // 手机号
                    if (!string.IsNullOrEmpty(entity.Mobile))
                    {
                        List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复手机号的数据。"
                            });
                        }
                    }
                }
                // 默认值
                if (entities != null)
                {
                    entities.ForEach(entity => {
                        entity.Password = EncryptHelper.GetBase64String(entity.Password);
                        entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.CreateDateTime = DateTime.Now;
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new UserService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Create_Multiple", ex);
            }
        }
        /// <summary>
        /// 创建用户并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Create/ToStatus", Name = "MIS_AVM_User_Create_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToStatus(DTO_EntityToStatus<User> dto)
        {
            try
            {
                // Entity空值
                if (dto.Entity == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.DTO.Entity为空。"
                    });
                }
                // 重复用户名
                if (!string.IsNullOrEmpty(dto.Entity.Name))
                {
                    List<User> existUser = new UserService.RowsService().ByName(dto.Entity.Name);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复用户名的数据。"
                        });
                    }
                }
                // 重复手机号
                if (!string.IsNullOrEmpty(dto.Entity.Mobile))
                {
                    List<User> existUser = new UserService.RowsService().ByMobile(dto.Entity.Mobile);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复手机号的数据。"
                        });
                    }
                }
                // 默认值
                if (dto.Entity != null)
                {
                    dto.Entity.Password = EncryptHelper.GetBase64String(dto.Entity.Password);
                    dto.Entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.CreateDateTime = DateTime.Now;
                    dto.Entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new UserService.CreateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Create_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量创建用户并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Create/BatchToStatus", Name = "MIS_AVM_User_Create_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_BatchToStatus(DTO_EntitiesToStatus<User> dto)
        {
            try
            {
                // Entities空值
                if (dto.Entities == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.DTO.Entities为空。"
                    });
                }
                // 重复数据
                foreach (User entity in dto.Entities)
                {
                    // 用户名
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        List<User> existUser = new UserService.RowsService().ByName(entity.Name);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复用户名的数据。"
                            });
                        }
                    }
                    // 手机号
                    if (!string.IsNullOrEmpty(entity.Mobile))
                    {
                        List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复手机号的数据。"
                            });
                        }
                    }
                }
                // 默认值
                if (dto.Entities != null)
                {
                    dto.Entities.ForEach(entity => {
                        entity.Password = EncryptHelper.GetBase64String(entity.Password);
                        entity.CreateUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.CreateDateTime = DateTime.Now;
                        entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                        entity.EditDateTime = DateTime.Now;
                    });
                }
                // 返回
                return ResponseOk(
                    new CreateMode.Request().ToResponse(
                        new UserService.CreateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Create_BatchToStatus", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Update/Single", Name = "MIS_AVM_User_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(User entity)
        {
            try
            {
                // Entity空值
                if (entity == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entity为空。"
                    });
                }
                // 重复用户名
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    List<User> existUser = new UserService.RowsService().ByName(entity.Name, entity.Id);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复用户名的数据。"
                        });
                    }
                }
                // 重复手机号
                if (!string.IsNullOrEmpty(entity.Mobile))
                {
                    List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile, entity.Id);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复手机号的数据。"
                        });
                    }
                }
                // 默认值
                if (entity != null)
                {
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new UserService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条用户
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Update/Multiple", Name = "MIS_AVM_User_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<User> entities)
        {
            try
            {
                // Entities空值
                if (entities == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entities为空。"
                    });
                }
                // 重复数据
                foreach (User entity in entities)
                {
                    // 用户名
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        List<User> existUser = new UserService.RowsService().ByName(entity.Name, entity.Id);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复用户名的数据。"
                            });
                        }
                    }
                    // 手机号
                    if (!string.IsNullOrEmpty(entity.Mobile))
                    {
                        List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile, entity.Id);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复手机号的数据。"
                            });
                        }
                    }
                }
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
                        new UserService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Update/ToStatus", Name = "MIS_AVM_User_Update_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToStatus(DTO_EntityToStatus<User> dto)
        {
            try
            {
                // Entity空值
                if (dto.Entity == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entity为空。"
                    });
                }
                // 重复用户名
                if (!string.IsNullOrEmpty(dto.Entity.Name))
                {
                    List<User> existUser = new UserService.RowsService().ByName(dto.Entity.Name, dto.Entity.Id);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复用户名的数据。"
                        });
                    }
                }
                // 重复手机号
                if (!string.IsNullOrEmpty(dto.Entity.Mobile))
                {
                    List<User> existUser = new UserService.RowsService().ByMobile(dto.Entity.Mobile, dto.Entity.Id);
                    if (existUser.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复手机号的数据。"
                        });
                    }
                }
                // 默认值
                if (dto.Entity != null)
                {
                    dto.Entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new UserService.UpdateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Update_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Update/BatchToStatus", Name = "MIS_AVM_User_Update_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_BatchToStatus(DTO_EntitiesToStatus<User> dto)
        {
            try
            {
                // Entities空值
                if (dto.Entities == null)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "Request.Entities为空。"
                    });
                }
                // 重复数据
                foreach (User entity in dto.Entities)
                {
                    // 用户名
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        List<User> existUser = new UserService.RowsService().ByName(entity.Name, entity.Id);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复用户名的数据。"
                            });
                        }
                    }
                    // 手机号
                    if (!string.IsNullOrEmpty(entity.Mobile))
                    {
                        List<User> existUser = new UserService.RowsService().ByMobile(entity.Mobile, entity.Id);
                        if (existUser.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复手机号的数据。"
                            });
                        }
                    }
                }
                // 默认值
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
                        new UserService.UpdateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Update_BatchToStatus", ex);
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Update/Password", Name = "MIS_AVM_User_Update_Password")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Password(User entity)
        {
            try
            {
                // 默认值
                if (entity != null)
                {
                    entity.Password = EncryptHelper.GetBase64String(entity.Password);
                    entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new UserService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Update_Password", ex);
            }
        }

        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Delete/Single", Name = "MIS_AVM_User_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(User entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new UserService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条用户
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Delete/Multiple", Name = "MIS_AVM_User_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<User> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new UserService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询用户的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/AVM/User/Columns/Single", Name = "MIS_AVM_User_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new UserService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Row/ById", Name = "MIS_AVM_User_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new UserService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Row/ById/{id}", Name = "MIS_AVM_User_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new UserService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Rows/ByKeyWord", Name = "MIS_AVM_User_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new UserService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询用户
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Rows/ByKeyWord/{keyWord}", Name = "MIS_AVM_User_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new UserService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Single/ById", Name = "MIS_AVM_User_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new UserService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Query/Page", Name = "MIS_AVM_User_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new UserService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new UserService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new UserService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.AVM.UserController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Tree/ByKeyWord", Name = "MIS_AVM_User_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<User> dto)
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
                throw new Exception("MISApi.Controllers.AVM.UserController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Tree/ById", Name = "MIS_AVM_User_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<User> dto)
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
                throw new Exception("MISApi.Controllers.AVM.UserController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/AVM/User/Tree", Name = "MIS_AVM_User_Tree")]
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
                throw new Exception("MISApi.Controllers.AVM.UserController.Tree", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<User>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<User>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<User>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<User>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<User>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<User>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<User> ToResponse(User entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<User>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<User>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<User>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<User> ToResponse(List<User> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<User>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}