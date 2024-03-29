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
            /// 创建指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Member ToStatus(Member entity, string statusKey)
            {
                try
                {
                    // 定义
                    Member result = new Member();
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
                    throw new Exception("MISApi.Services.CMS.MemberService.CreateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量创建指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Member> BatchToStatus(List<Member> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Member> results = new List<Member>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new MemberService.CreateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.CreateService.BatchToStatus", ex);
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
            /// 编辑指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Member ToStatus(Member entity, string statusKey)
            {
                try
                {
                    // 定义
                    Member result = new Member();
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
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量编辑指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Member> BatchToStatus(List<Member> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Member> results = new List<Member>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new MemberService.UpdateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.BatchToStatus", ex);
                }
            }
            /// <summary>
            /// 认证会员通过
            /// </summary>
            /// <param name="memberId"></param>
            /// <returns></returns>
            public virtual Member AuthorityPass(int memberId)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        // 获取会员
                        Member member = new MemberService.RowService().ById(memberId);
                        if (member != null)
                        {
                            member.IsAuthority = true;
                            new MemberService.UpdateService().Execute(member);
                        }
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.AuthorityPass", ex);
                }
            }
            /// <summary>
            /// 增加会员套餐给指定会员
            /// </summary>
            /// <param name="memberId"></param>
            /// <param name="memberPowerId"></param>
            /// <returns></returns>
            public virtual Member AddByMemberPowerId(int memberId,int memberPowerId)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        // 获取会员
                        Member member = new MemberService.RowService().ById(memberId);
                        if(member != null)
                        {
                            // 获取会员套餐
                            MemberPower memberPower = new MemberPowerService.RowService().ById(memberPowerId);
                            if(memberPower != null)
                            {
                                member.BuyCount = memberPower.BuyLimit == -1? -1: member.BuyCount + memberPower.BuyLimit;
                                member.ReBuyCount = memberPower.BuyLimit == -1 ? -1 : member.ReBuyCount + memberPower.BuyLimit;
                                member.DownCount = memberPower.DownLimit == -1 ? -1 : member.DownCount + memberPower.DownLimit;
                                member.ReDownCount = memberPower.DownLimit == -1 ? -1 : member.ReDownCount + memberPower.DownLimit;
                                member.UploadCount = memberPower.UploadLimit == -1 ? -1 : member.UploadCount + memberPower.UploadLimit;
                                member.ReUploadCount = memberPower.UploadLimit == -1 ? -1 : member.ReUploadCount + memberPower.UploadLimit;
                                member.LevelDeadline = member.LevelDeadline < DateTime.Now ? DateTime.Now : member.LevelDeadline;
                                member.LevelDeadline = member.LevelDeadline.Value.AddDays(memberPower.DaysLimit??0);
                                new MemberService.UpdateService().Execute(member);
                            }
                            result = member;
                        }
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.AddByMemberPowerId", ex);
                }
            }
            /// <summary>
            /// 退还会员套餐给指定会员
            /// </summary>
            /// <param name="memberId"></param>
            /// <param name="memberPowerId"></param>
            /// <returns></returns>
            public virtual Member ReduceByMemberPowerId(int memberId, int memberPowerId)
            {
                try
                {
                    // 定义
                    Member result = new Member();
                    // 事务
                    transService.TransRegist(delegate {
                        // 获取会员
                        Member member = new MemberService.RowService().ById(memberId);
                        if (member != null)
                        {
                            // 获取会员套餐
                            MemberPower memberPower = new MemberPowerService.RowService().ById(memberPowerId);
                            if (memberPower != null)
                            {
                                member.BuyCount = memberPower.BuyLimit == -1? -1: member.BuyCount - memberPower.BuyLimit;
                                member.ReBuyCount = memberPower.BuyLimit == -1 ? -1 : member.ReBuyCount - memberPower.BuyLimit;
                                member.DownCount = memberPower.DownLimit == -1 ? -1 : member.DownCount - memberPower.DownLimit;
                                member.ReDownCount = memberPower.DownLimit == -1 ? -1 : member.ReDownCount - memberPower.DownLimit;
                                member.UploadCount = memberPower.UploadLimit == -1 ? -1 : member.UploadCount - memberPower.UploadLimit;
                                member.ReUploadCount = memberPower.UploadLimit == -1 ? -1 : member.ReUploadCount - memberPower.UploadLimit;
                                member.LevelDeadline = member.LevelDeadline.Value.AddDays(-memberPower.DaysLimit??0);
                                new MemberService.UpdateService().Execute(member);
                            }
                        }
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.MemberService.UpdateService.ReduceByMemberPowerId", ex);
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
                        throw new Exception("MISApi.Services.CMS.MemberService.RowService.Verify", ex);
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