﻿using MISApi.CacheServices.WFM;
using MISApi.Dal.EF;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using MISApi.HttpClients;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.MemberService.CreateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 在用
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Member ToOpen(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.member.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = new MemberService.CreateService().Execute(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.CreateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 注册
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Member Regist(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        if(new MemberService.RowService().ByMobile(entity.Mobile) == null)
                        {
                            result = new MemberService.CreateService().ToOpen(entity);
                        }
                        else
                        {
                            throw new Exception("手机号码已存在，不能注册！"); ;
                        }
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.CreateService.Regist", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.MemberService.UpdateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public UpdateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 在用
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Member ToOpen(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.member.open");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.ToOpen", ex);
                }
            }
            /// <summary>
            /// 关闭
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public virtual Member ToClose(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey("cms.member.close");
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.ToClose", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.MemberService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.MemberService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.MemberService.RowService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public Member Verify(string key, string password)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 加密
                        var encrypt = EncryptHelper.GetBase64String(password);
                        // 返回
                        return SQLEntityToSingle(
                            SQLQueryable(context)
                                .SingleOrDefault(row => (
                                    (row.Member.Name == key && row.Member.Password == encrypt) ||
                                    (row.Member.Mobile == key && row.Member.Password == encrypt) ||
                                    (row.Member.Email == key && row.Member.Password == encrypt)
                                ) && row.Member.StatusValue == 1)
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.AVM.MemberService.RowService.Verify", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.MemberService.RowsService
        {

        }

        #endregion
    }
}