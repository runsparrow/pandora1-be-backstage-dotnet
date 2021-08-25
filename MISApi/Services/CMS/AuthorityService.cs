using MISApi.CacheServices.WFM;
using MISApi.Dal.EF;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorityService
    {
          
        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.AuthorityService.CreateService
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
            /// 创建指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Authority ToStatus(Authority entity, string statusKey)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.AuthorityService.CreateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量创建指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Authority> BatchToStatus(List<Authority> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Authority> results = new List<Authority>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new AuthorityService.CreateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.AuthorityService.CreateService.BatchToStatus", ex);
                }
            }
            ///// <summary>
            ///// 验证通过
            ///// </summary>
            ///// <param name="entity"></param>
            ///// <returns></returns>
            //public virtual Authority Pass(Authority entity)
            //{
            //    try
            //    {
            //        // 定义
            //        Authority result = new Authority();
            //        // 事务
            //        transService.TransRegist(delegate {
            //            // 认证信息
            //            result = new AuthorityService.CreateService().ToStatus(entity, "cms.authority.open");
            //            // 会员信息
            //            new MemberService.UpdateService().AuthorityPass(entity.MemberId??-1);
            //        });
            //        // 提交
            //        transService.TransCommit();
            //        // 返回
            //        return result;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("MISApi.Services.CMS.AuthorityService.CreateService.Pass", ex);
            //    }
            //}
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.AuthorityService.UpdateService
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
            /// 编辑指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Authority ToStatus(Authority entity, string statusKey)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
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
                    throw new Exception("MISApi.Services.CMS.AuthorityService.UpdateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量编辑指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Authority> BatchToStatus(List<Authority> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Authority> results = new List<Authority>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new AuthorityService.UpdateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.AuthorityService.UpdateService.BatchToStatus", ex);
                }
            }
            /// <summary>
            /// 验证通过
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual Authority Pass(int id)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        // 获取认证数据
                        Authority entity = new AuthorityService.RowService().ById(id);
                        // 认证信息
                        result = new AuthorityService.UpdateService().ToStatus(entity, "cms.authority.approver.pass");
                        // 会员信息
                        new MemberService.UpdateService().AuthorityPass(entity.MemberId ?? -1);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.AuthorityService.UpdateService.Pass", ex);
                }
            }
            /// <summary>
            /// 验证拒绝
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual Authority Refuse(int id)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        // 获取认证数据
                        Authority entity = new AuthorityService.RowService().ById(id);
                        // 认证信息
                        result = new AuthorityService.UpdateService().ToStatus(entity, "cms.authority.approver.refuse");
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.AuthorityService.UpdateService.Refuse", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.AuthorityService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.AuthorityService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.AuthorityService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.AuthorityService.RowsService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="memberId"></param>
            /// <param name="authorityIndex"></param>
            /// <param name="extraId">被排除判断的Id</param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Authority> ByMemberIdWithAuthorityIndex(int memberId, int authorityIndex, int extraId = -1, params HttpClients.HttpModes.BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.MemberId == memberId && row.Authority.AuthorityIndex == authorityIndex && row.Authority.Id != extraId && row.Authority.StatusValue > 0)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.AuthorityService.RowsService.ByMemberIdWithAuthorityIndex", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idCard"></param>
            /// <param name="authorityIndex"></param>
            /// <param name="extraId">被排除判断的Id</param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Authority> ByIdCardWithAuthorityIndex(string idCard, int authorityIndex, int extraId = -1, params HttpClients.HttpModes.BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.IdCard == idCard && row.Authority.AuthorityIndex == authorityIndex && row.Authority.Id != extraId && row.Authority.StatusValue > 0)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.AuthorityService.RowsService.ByIdCardWithAuthorityIndex", ex);
                    }
                }
            }
        }

        #endregion
    }
}