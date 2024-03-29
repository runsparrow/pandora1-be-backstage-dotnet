﻿using Microsoft.AspNetCore.Authorization;
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
    /// 认证
    /// </summary>
    public class AuthorityController : BaseController<Authority>
    {
        #region RPC

        #region CreateMode
        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Create/Single", Name = "MIS_CMS_Authority_Create_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Single(Authority entity)
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
                // 重复身份证
                if (!string.IsNullOrEmpty(entity.IdCard))
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复身份证的数据。"
                        });
                    }
                }
                // 重复认证
                if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId??-1, entity.AuthorityIndex??-1);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复认证的数据。"
                        });
                    }
                }
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
                        new AuthorityService.CreateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Create_Single", ex);
            }
        }
        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Create/Multiple", Name = "MIS_CMS_Authority_Create_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_Multiple(List<Authority> entities)
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
                foreach (Authority entity in entities)
                {
                    // 身份证
                    if (!string.IsNullOrEmpty(entity.IdCard))
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复身份证的数据。"
                            });
                        }
                    }
                    // 认证
                    if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复认证的数据。"
                            });
                        }
                    }
                }
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
                        new AuthorityService.CreateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Create_Multiple", ex);
            }
        }
        ///// <summary>
        ///// 创建认证并更新会员信息
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[Route("MIS/CMS/Authority/Create/Pass", Name = "MIS_CMS_Authority_Create_Pass")]
        //[HttpPost]
        //[Authorize]
        //public IActionResult Create_Pass(Authority entity)
        //{
        //    try
        //    {
        //        // Entity空值
        //        if (entity == null)
        //        {
        //            return new JsonResult(new DTO_Result
        //            {
        //                Result = false,
        //                Message = "Request.Entity为空。"
        //            });
        //        }
        //        // 重复身份证
        //        if (!string.IsNullOrEmpty(entity.IdCard))
        //        {
        //            List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1);
        //            if (existAuthority.Count > 0)
        //            {
        //                return new JsonResult(new DTO_Result
        //                {
        //                    Result = false,
        //                    Message = "存在重复身份证的数据。"
        //                });
        //            }
        //        }
        //        // 重复认证
        //        if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
        //        {
        //            List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1);
        //            if (existAuthority.Count > 0)
        //            {
        //                return new JsonResult(new DTO_Result
        //                {
        //                    Result = false,
        //                    Message = "存在重复认证的数据。"
        //                });
        //            }
        //        }
        //        // 默认值
        //        if (entity != null)
        //        {

        //        }
        //        // 返回
        //        return ResponseOk(
        //            new CreateMode.Request().ToResponse(
        //                new AuthorityService.CreateService().Pass(entity)
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("MISApi.Controllers.CMS.AuthorityController.Create_Pass", ex);
        //    }
        //}
        /// <summary>
        /// 创建认证并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Create/ToStatus", Name = "MIS_CMS_Authority_Create_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_ToStatus(DTO_EntityToStatus<Authority> dto)
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
                // 重复身份证
                if (!string.IsNullOrEmpty(dto.Entity.IdCard))
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(dto.Entity.IdCard, dto.Entity.AuthorityIndex ?? -1);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复身份证的数据。"
                        });
                    }
                }
                // 重复认证
                if (dto.Entity.MemberId != null && dto.Entity.MemberId != -1 || dto.Entity.AuthorityIndex != null && dto.Entity.AuthorityIndex != -1)
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(dto.Entity.MemberId ?? -1, dto.Entity.AuthorityIndex ?? -1);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复认证的数据。"
                        });
                    }
                }
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
                        new AuthorityService.CreateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Create_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量创建认证并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Create/BatchToStatus", Name = "MIS_CMS_Authority_Create_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Create_BatchToStatus(DTO_EntitiesToStatus<Authority> dto)
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
                foreach (Authority entity in dto.Entities)
                {
                    // 身份证
                    if (!string.IsNullOrEmpty(entity.IdCard))
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复身份证的数据。"
                            });
                        }
                    }
                    // 认证
                    if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复认证的数据。"
                            });
                        }
                    }
                }
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
                        new AuthorityService.CreateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Create_BatchToStatus", ex);
            }
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 编辑一条认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/Single", Name = "MIS_CMS_Authority_Update_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Single(Authority entity)
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
                // 重复身份证
                if (!string.IsNullOrEmpty(entity.IdCard))
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1, entity.Id);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复身份证的数据。"
                        });
                    }
                }
                // 重复认证
                if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1, entity.Id);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复认证的数据。"
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
                        new AuthorityService.UpdateService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_Single", ex);
            }
        }
        /// <summary>
        /// 编辑多条认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/Multiple", Name = "MIS_CMS_Authority_Update_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_Multiple(List<Authority> entities)
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
                foreach (Authority entity in entities)
                {
                    // 身份证
                    if (!string.IsNullOrEmpty(entity.IdCard))
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1, entity.Id);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复身份证的数据。"
                            });
                        }
                    }
                    // 认证
                    if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1, entity.Id);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复认证的数据。"
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
                        new AuthorityService.UpdateService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_Multiple", ex);
            }
        }
        /// <summary>
        /// 编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/ToStatus", Name = "MIS_CMS_Authority_Update_ToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_ToStatus(DTO_EntityToStatus<Authority> dto)
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
                // 重复身份证
                if (!string.IsNullOrEmpty(dto.Entity.IdCard))
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(dto.Entity.IdCard, dto.Entity.AuthorityIndex ?? -1, dto.Entity.Id);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复身份证的数据。"
                        });
                    }
                }
                // 重复认证
                if (dto.Entity.MemberId != null && dto.Entity.MemberId != -1 || dto.Entity.AuthorityIndex != null && dto.Entity.AuthorityIndex != -1)
                {
                    List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(dto.Entity.MemberId ?? -1, dto.Entity.AuthorityIndex ?? -1, dto.Entity.Id);
                    if (existAuthority.Count > 0)
                    {
                        return new JsonResult(new DTO_Result
                        {
                            Result = false,
                            Message = "存在重复认证的数据。"
                        });
                    }
                }
                // Entity
                if (dto.Entity != null)
                {
                    dto.Entity.EditUserId = AuthHelper.GetClaimFromToken(Token).Id;
                    dto.Entity.EditDateTime = DateTime.Now;
                }
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new AuthorityService.UpdateService().ToStatus(dto.Entity, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_ToStatus", ex);
            }
        }
        /// <summary>
        /// 批量编辑并设置状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/BatchToStatus", Name = "MIS_CMS_Authority_Update_BatchToStatus")]
        [HttpPost]
        [Authorize]
        public IActionResult Update_BatchToStatus(DTO_EntitiesToStatus<Authority> dto)
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
                foreach (Authority entity in dto.Entities)
                {
                    // 身份证
                    if (!string.IsNullOrEmpty(entity.IdCard))
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByIdCardWithAuthorityIndex(entity.IdCard, entity.AuthorityIndex ?? -1, entity.Id);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复身份证的数据。"
                            });
                        }
                    }
                    // 认证
                    if (entity.MemberId != null && entity.MemberId != -1 || entity.AuthorityIndex != null && entity.AuthorityIndex != -1)
                    {
                        List<Authority> existAuthority = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(entity.MemberId ?? -1, entity.AuthorityIndex ?? -1, entity.Id);
                        if (existAuthority.Count > 0)
                        {
                            return new JsonResult(new DTO_Result
                            {
                                Result = false,
                                Message = "存在重复认证的数据。"
                            });
                        }
                    }
                }
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
                        new AuthorityService.UpdateService().BatchToStatus(dto.Entities, dto.StatusKey)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_BatchToStatus", ex);
            }
        }
        /// <summary>
        /// 审批通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/Pass/{id}", Name = "MIS_CMS_Authority_Update_Pass_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Update_Pass(int id)
        {
            try
            {
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new AuthorityService.UpdateService().Pass(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_Pass", ex);
            }
        }
        /// <summary>
        /// 审批拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Update/Refuse/{id}", Name = "MIS_CMS_Authority_Update_Refuse_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Update_Refuse(int id)
        {
            try
            {
                // 返回
                return ResponseOk(
                    new UpdateMode.Request().ToResponse(
                        new AuthorityService.UpdateService().Refuse(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Update_Refuse", ex);
            }
        }
        #endregion

        #region DeleteMode
        /// <summary>
        ///  删除一条认证
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Delete/Single", Name = "MIS_CMS_Authority_Delete_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Single(Authority entity)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new AuthorityService.DeleteService().Execute(entity)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Delete_Single", ex);
            }
        }
        /// <summary>
        /// 删除多条认证
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Delete/Multiple", Name = "MIS_CMS_Authority_Delete_Multiple")]
        [HttpPost]
        [Authorize]
        public IActionResult Delete_Multiple(List<Authority> entities)
        {
            try
            {
                return ResponseOk(
                    new DeleteMode.Request().ToResponse(
                        new AuthorityService.DeleteService().Execute(entities)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Delete_Multiple", ex);
            }
        }
        #endregion

        #region ColumnsMode
        /// <summary>
        /// 查询认证的字段
        /// </summary>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Columns/Single", Name = "MIS_CMS_Authority_Columns_Single")]
        [HttpPost]
        [Authorize]
        public IActionResult Columns_Single()
        {
            try
            {
                return ResponseOk(
                    new ColumnsMode.Request().ToResponse(
                        new AuthorityService.ColumnsService().Single()
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Row/ById", Name = "MIS_CMS_Authority_Row_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Row_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new AuthorityService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Row/ById/{id}", Name = "MIS_CMS_Authority_Row_ById_Id")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ById_Id(int id)
        {
            try
            {
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        new AuthorityService.RowService().ById(id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Row_ById_Id", ex);
            }
        }
        /// <summary>
        /// 根据MemberId和认证序列查询认证
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="authorityIndex"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Row/ByMemberId/{memberId}/{authorityIndex}", Name = "MIS_CMS_Authority_Row_ByMemberId_MemberId_AuthorityIndex")]
        [HttpGet]
        [Authorize]
        public IActionResult Row_ByMemberId_MemberId_AuthorityIndex(int memberId, int authorityIndex)
        {
            try
            {
                List<Authority> list = new AuthorityService.RowsService().ByMemberIdWithAuthorityIndex(memberId, authorityIndex);
                if(list.Count > 1)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "该会员存在重复的认证信息。"
                    });
                }
                if(list.Count == 0)
                {
                    return new JsonResult(new DTO_Result
                    {
                        Result = false,
                        Message = "未发现会员认证信息。"
                    });
                }
                return ResponseOk(
                    new RowMode.Request().ToResponse(
                        list[0]
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Row_ByMemberId_MemberId_AuthorityIndex", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Rows/ByKeyWord", Name = "MIS_CMS_Authority_Rows_ByKeyWord")]
        [HttpPost]
        [Authorize]
        public IActionResult Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthorityService.RowsService().ByKeyWord(new BaseMode.KeyWord(dto.KeyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Rows/ByKeyWord/{keyWord}", Name = "MIS_CMS_Authority_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthorityService.RowsService().ByKeyWord(new BaseMode.KeyWord(keyWord))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据MemberId查询认证
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Rows/ByMemberId/{memberId}", Name = "MIS_CMS_Authority_Rows_ByMemberId_MemberId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByMemberId_MemberId(int memberId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthorityService.RowsService().ByMemberId(memberId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Rows_ByMemberId_MemberId", ex);
            }
        }
        /// <summary>
        /// 根据ApplierId查询认证
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Rows/ByApplierId/{applierId}", Name = "MIS_CMS_Authority_Rows_ByApplierId_ApplierId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByApplierId_ApplierId(int applierId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthorityService.RowsService().ByApplierId(applierId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Rows_ByApplierId_ApplierId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询认证
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Rows/ByApproverId/{approverId}", Name = "MIS_CMS_Authority_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        [Authorize]
        public IActionResult Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return ResponseOk(
                    new RowsMode.Request().ToResponse(
                        new AuthorityService.RowsService().ByApproverId(approverId)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Rows_ByApproverId_ApproverId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Single/ById", Name = "MIS_CMS_Authority_Single_ById")]
        [HttpPost]
        [Authorize]
        public IActionResult Single_ById(DTO_Id dto)
        {
            try
            {
                return ResponseOk(
                    new SingleMode.Request().ToResponse(
                        new AuthorityService.RowService().ById(dto.Id)
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Query/Page", Name = "MIS_CMS_Authority_Query_Page")]
        [HttpPost]
        [Authorize]
        public IActionResult Query_Page(DTO_Page dto)
        {
            try
            {
                return ResponseOk(
                    new QueryMode.Request().ToResponse(
                        new AuthorityService.RowsService().Page(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Page(dto.Page), new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new AuthorityService.RowsService().PageCount(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status)),
                        new AuthorityService.RowsService().PageSummary(new BaseMode.KeyWord(dto.KeyWord), new BaseMode.Join[] { }, new BaseMode.Date().Init(dto.Date), new BaseMode.Sort().Init(dto.Sort), new BaseMode.Status(dto.Status))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Query_Page", ex);
            }
        }
        #endregion

        #region TreeMode
        /// <summary>
        /// 模糊查询获得树型结构的认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Tree/ByKeyWord", Name = "MIS_CMS_Authority_Tree_ByKeyWord")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ByKeyWord(DTO_KeyWordWithConfig<Authority> dto)
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
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Tree_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据Id查询获得树型结构的认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Tree/ById", Name = "MIS_CMS_Authority_Tree_ById")]
        [HttpPost]
        [Authorize]
        protected IActionResult Tree_ById(DTO_IdWithConfig<Authority> dto)
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
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Tree_ById", ex);
            }
        }
        /// <summary>
        /// 树形结构的复杂查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("MIS/CMS/Authority/Tree", Name = "MIS_CMS_Authority_Tree")]
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
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Tree", ex);
            }
        }
        #endregion

        #endregion

        #region Unauthorized

        #region ColumnsMode
        /// <summary>
        /// 查询认证的字段
        /// </summary>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Columns/Single", Name = "Unauthorized_MIS_CMS_Authority_Columns_Single")]
        [HttpPost]
        public IActionResult Unauthorized_Columns_Single()
        {
            try
            {
                return Columns_Single();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Columns_Single", ex);
            }
        }
        #endregion

        #region RowMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Row/ById", Name = "Unauthorized_MIS_CMS_Authority_Row_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Row_ById(DTO_Id dto)
        {
            try
            {
                return Row_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Row_ById", ex);
            }
        }
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Row/ById/{id}", Name = "Unauthorized_MIS_CMS_Authority_Row_ById_Id")]
        [HttpGet]
        public IActionResult Unauthorized_Row_ById_Id(int id)
        {
            try
            {
                return Row_ById_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Row_ById_Id", ex);
            }
        }
        #endregion

        #region RowsMode
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Rows/ByKeyWord", Name = "Unauthorized_MIS_CMS_Authority_Rows_ByKeyWord")]
        [HttpPost]
        public IActionResult Unauthorized_Rows_ByKeyWord(DTO_KeyWord dto)
        {
            try
            {
                return Rows_ByKeyWord(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Rows_ByKeyWord", ex);
            }
        }
        /// <summary>
        /// 根据关键字模糊查询认证
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Rows/ByKeyWord/{keyWord}", Name = "Unauthorized_MIS_CMS_Authority_Rows_ByKeyWord_KeyWord")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByKeyWord_KeyWord(string keyWord)
        {
            try
            {
                return Rows_ByKeyWord_KeyWord(keyWord);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Rows_ByKeyWord_KeyWord", ex);
            }
        }
        /// <summary>
        /// 根据ApplierId查询认证
        /// </summary>
        /// <param name="applierId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Rows/ByApplierId/{applierId}", Name = "Unauthorized_MIS_CMS_Authority_Rows_ByApplierId_ApplierId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByApplierId_ApplierId(int applierId)
        {
            try
            {
                return Rows_ByApplierId_ApplierId(applierId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Rows_ByApplierId_ApplierId", ex);
            }
        }
        /// <summary>
        /// 根据ApproverId查询认证
        /// </summary>
        /// <param name="approverId"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Rows/ByApproverId/{approverId}", Name = "Unauthorized_MIS_CMS_Authority_Rows_ByApproverId_ApproverId")]
        [HttpGet]
        public IActionResult Unauthorized_Rows_ByApproverId_ApproverId(int approverId)
        {
            try
            {
                return Rows_ByApproverId_ApproverId(approverId);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Rows_ByApproverId_ApproverId", ex);
            }
        }
        #endregion

        #region SingleMode
        /// <summary>
        /// 根据Id查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Single/ById", Name = "Unauthorized_MIS_CMS_Authority_Single_ById")]
        [HttpPost]
        public IActionResult Unauthorized_Single_ById(DTO_Id dto)
        {
            try
            {
                return Single_ById(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Single_ById", ex);
            }
        }
        #endregion

        #region QueryMode
        /// <summary>
        /// 分页查询认证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Unauthorized/MIS/CMS/Authority/Query/Page", Name = "Unauthorized_MIS_CMS_Authority_Query_Page")]
        [HttpPost]
        public IActionResult Unauthorized_Query_Page(DTO_Page dto)
        {
            try
            {
                return Query_Page(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.CMS.AuthorityController.Unauthorized_Query_Page", ex);
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
            public class Request : HttpClients.HttpModes.CreateMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.CreateMode.Response<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.CreateMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.UpdateMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.UpdateMode.Response<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.UpdateMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.DeleteMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.DeleteMode.Response<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.DeleteMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.ColumnsMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.ColumnsMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.ColumnsMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.RowMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.RowsMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.RowsMode.Response<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.RowsMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.SingleMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.SingleMode.Response<Authority> ToResponse(Authority entity)
                {
                    return base.ToResponse(entity);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.SingleMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.QueryMode.Request<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.QueryMode.Response<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.QueryMode.Response<Authority>
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
            public class Request : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Authority>
            {
                /// <summary>
                /// 
                /// </summary>
                /// <param name="entityList"></param>
                /// <returns></returns>
                public override HttpClients.HttpModes.TreeMode.AntdTreeResponse<Authority> ToResponse(List<Authority> entityList)
                {
                    return base.ToResponse(entityList);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public class Response : HttpClients.HttpModes.TreeMode.AntdTreeRequest<Authority>
            {

            }
        }
        #endregion

        #endregion

        #region HttpEntities

        #endregion
    }
}