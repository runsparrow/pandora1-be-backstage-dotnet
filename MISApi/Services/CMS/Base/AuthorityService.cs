using MISApi.Dal.EF;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;

namespace MISApi.Services.CMS.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorityService : BaseService.EF<Authority, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : AuthorityService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private readonly TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Authority Execute(Authority entity)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Authority> Execute(List<Authority> entityList)
            {
                try
                {
                    // 定义
                    List<Authority> resultList = new List<Authority>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entityList.ForEach(entity =>
                        {
                            resultList.Add(
                                    new CreateService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : AuthorityService
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
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Authority Execute(Authority entity)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Authority> Execute(List<Authority> entityList)
            {
                try
                {
                    // 定义
                    List<Authority> resultList = new List<Authority>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        entityList.ForEach(entity =>
                        {
                            resultList.Add(
                                    new UpdateService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : AuthorityService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public DeleteService()
            {
                transService = new TransService();
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public Authority Execute(Authority entity)
            {
                try
                {
                    // 定义
                    Authority result = new Authority();
                    // 事务
                    transService.TransRegist(delegate {
                        result = base.Delete(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Authority> Execute(List<Authority> entitys)
            {
                try
                {
                    // 定义
                    List<Authority> resultList = new List<Authority>();
                    // 事务
                    transService.TransRegist(delegate {
                        entitys.ForEach(entity =>
                        {
                            resultList.Add(
                                    new DeleteService().Execute(entity)
                                );
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : AuthorityService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Authority Single()
            {
                try
                {
                    return new Authority();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : AuthorityService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Authority ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowService.ById", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : AuthorityService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Authority> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="memberId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Authority> ByMemberId(int memberId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.MemberId == memberId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.ByMemberId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="applierId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Authority> ByApplierId(int applierId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.ApplierId == applierId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.ByApplierId", ex);
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="approverId"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Authority> ByApproverId(int approverId, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                            SQLQueryable(context, joins)
                                .Where(row => row.Authority.ApproverId == approverId)
                                .ToList()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.ByApproverId", ex);
                    }
                }
            }
            /// <summary>
            /// 分页
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="page"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public List<Authority> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, joins);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord.Value);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord.Ext);
                        // 日期
                        queryable = DateQueryable(queryable, dates);
                        // 状态
                        queryable = StatusQueryable(queryable, status);
                        // 排序
                        queryable = SortQueryable(queryable, sorts);
                        // 分页
                        queryable = PageQueryable(queryable, page);
                        // 返回
                        return SQLEntityToList(
                                queryable.ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.Page", ex);
                    }
                }
            }
            /// <summary>
            /// 分页计数
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public int PageCount(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 定义
                        var queryable = SQLQueryable(context, joins);
                        // keyWord查询
                        queryable = KeyWordQueryable(queryable, keyWord.Value);
                        // keyWordExt查询
                        queryable = KeyWordExtQueryable(queryable, keyWord.Ext);
                        // 日期
                        queryable = DateQueryable(queryable, dates);
                        // 状态
                        queryable = StatusQueryable(queryable, status);
                        // 排序
                        queryable = SortQueryable(queryable, sorts);
                        // 返回
                        return queryable.Count();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.PageCount", ex);
                    }
                }
            }
            /// <summary>
            /// 分页汇总
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        // 返回
                        return new SummaryEntity();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.AuthorityService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods

        /// <summary>
        /// 默认查询
        /// </summary>
        /// <param name="context"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> SQLQueryable(PandoraContext context, params BaseMode.Join[] joins)
        {
            try
            {
                // 定义
                var left = context.CMS_Authority.Select(Main => new SQLEntity
                {
                    Authority = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Authority.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Authority = Main.Authority,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Authority = Main.Authority,
                    Status = Main.Status
                });
                // 遍历
                foreach (var join in joins)
                {

                }
                // 返回
                return group;
            }
            catch(Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.SQLQueryable", ex);
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> KeyWordQueryable(IQueryable<SQLEntity> queryable, string keyWord)
        {
            try
            {
                // #分割生成and数组
                string[] ands = keyWord.Split('#');
                // 空格分割生成or数组
                string[] ors = Regex.Split(keyWord, "\\s+", RegexOptions.IgnoreCase);
                // 多个条件精确查询，单个条件关键字查询
                if (ands.Length > 1)
                {
                    for (var i = 0; i < ands.Length; i++)
                    {
                        var andKeyWord = ands[i];
                        queryable = queryable.Where(row =>
                                row.Authority.MemberName.Contains(andKeyWord) ||
                                row.Authority.IdentityName.Contains(andKeyWord) ||
                                row.Authority.NationName.Contains(andKeyWord) ||
                                row.Authority.ProvinceName.Contains(andKeyWord) ||
                                row.Authority.CityName.Contains(andKeyWord) ||
                                row.Authority.DivisionName.Contains(andKeyWord) ||
                                row.Authority.UnitName.Contains(andKeyWord) ||
                                row.Authority.OfficeName.Contains(andKeyWord) ||
                                row.Authority.DutyName.Contains(andKeyWord) ||
                                row.Authority.JobNo.Contains(andKeyWord) ||
                                row.Authority.IdCard.Contains(andKeyWord) ||
                                row.Authority.CertificateNo.Contains(andKeyWord) ||
                                row.Authority.Mobile.Contains(andKeyWord) ||
                                row.Authority.Email.Contains(andKeyWord) ||
                                row.Authority.ApplierName.Contains(andKeyWord) ||
                                row.Authority.ApproverName.Contains(andKeyWord) ||
                                row.Authority.ApproverDesc.Contains(andKeyWord) ||
                                row.Authority.Remark.Contains(andKeyWord) ||
                                row.Authority.StatusName.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Authority.MemberName) ||
                            ors.Contains(row.Authority.IdentityName) ||
                            ors.Contains(row.Authority.NationName) ||
                            ors.Contains(row.Authority.ProvinceName) ||
                            ors.Contains(row.Authority.CityName) ||
                            ors.Contains(row.Authority.DivisionName) ||
                            ors.Contains(row.Authority.OfficeName) ||
                            ors.Contains(row.Authority.DutyName) ||
                            ors.Contains(row.Authority.JobNo) ||
                            ors.Contains(row.Authority.IdCard) ||
                            ors.Contains(row.Authority.CertificateNo) ||
                            ors.Contains(row.Authority.Mobile) ||
                            ors.Contains(row.Authority.Email) ||
                            ors.Contains(row.Authority.ApplierName) ||
                            ors.Contains(row.Authority.ApproverName) ||
                            ors.Contains(row.Authority.ApproverDesc) ||
                            ors.Contains(row.Authority.Remark) ||
                            ors.Contains(row.Authority.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Authority.MemberName.Contains(keyWord) ||
                            row.Authority.IdentityName.Contains(keyWord) ||
                            row.Authority.NationName.Contains(keyWord) ||
                            row.Authority.ProvinceName.Contains(keyWord) ||
                            row.Authority.CityName.Contains(keyWord) ||
                            row.Authority.DivisionName.Contains(keyWord) ||
                            row.Authority.OfficeName.Contains(keyWord) ||
                            row.Authority.DutyName.Contains(keyWord) ||
                            row.Authority.JobNo.Contains(keyWord) ||
                            row.Authority.IdCard.Contains(keyWord) ||
                            row.Authority.CertificateNo.Contains(keyWord) ||
                            row.Authority.Mobile.Contains(keyWord) ||
                            row.Authority.Email.Contains(keyWord) ||
                            row.Authority.ApplierName.Contains(keyWord) ||
                            row.Authority.ApproverName.Contains(keyWord) ||
                            row.Authority.ApproverDesc.Contains(keyWord) ||
                            row.Authority.Remark.Contains(keyWord) ||
                            row.Authority.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.KeyWordQueryable", ex);
            }
        }
        /// <summary>
        /// 关键字扩展
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="keyWordExt"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> KeyWordExtQueryable(IQueryable<SQLEntity> queryable, string keyWordExt)
        {
            try
            {
                // 拆分查询条件
                var splits = keyWordExt.Split('^');
                // 遍历
                for (var i = 0; i < splits.Length; i++)
                {
                    try
                    {
                        if (splits[i].ToLower().Contains("jobno"))
                        {
                            string jobNo = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.JobNo == jobNo);
                        }
                        if (splits[i].ToLower().Contains("certificateno"))
                        {
                            string certificateNo = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.CertificateNo == certificateNo);
                        }
                        if (splits[i].ToLower().Contains("mobile"))
                        {
                            string mobile = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.Mobile == mobile);
                        }
                        if (splits[i].ToLower().Contains("email"))
                        {
                            string email = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.Email == email);
                        }
                        if (splits[i].ToLower().Contains("realname"))
                        {
                            string realName = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.RealName == realName);
                        }
                        if (splits[i].ToLower().Contains("idcard"))
                        {
                            string idcard = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.IdCard == idcard);
                        }
                        if (splits[i].ToLower().Contains("idcard"))
                        {
                            string idcard = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.IdCard == idcard);
                        }
                        if (splits[i].ToLower().Contains("alipay"))
                        {
                            string alipay = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.Alipay == alipay);
                        }
                        if (splits[i].ToLower().Contains("wechatpay"))
                        {
                            string wechatpay = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.WechatPay == wechatpay);
                        }
                        if (splits[i].ToLower().Contains("authorityindex"))
                        {
                            int authorityIndex = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.AuthorityIndex == authorityIndex);
                        }
                        if (splits[i].ToLower().Contains("memberid"))
                        {
                            int memberId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.MemberId == memberId);
                        }
                        if (splits[i].ToLower().Contains("identityid"))
                        {
                            int identityId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.IdentityId == identityId);
                        }
                        if (splits[i].ToLower().Contains("unitid"))
                        {
                            int unitId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.UnitId == unitId);
                        }
                        if (splits[i].ToLower().Contains("officeId"))
                        {
                            int officeId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.OfficeId == officeId);
                        }
                        if (splits[i].ToLower().Contains("dutyid"))
                        {
                            int dutyId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.DutyId == dutyId);
                        }
                        if (splits[i].ToLower().Contains("nationcode"))
                        {
                            string nationCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.NationCode == nationCode);
                        }
                        if (splits[i].ToLower().Contains("provincecode"))
                        {
                            string provinceCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.ProvinceCode == provinceCode);
                        }
                        if (splits[i].ToLower().Contains("citycode"))
                        {
                            string cityCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.CityCode == cityCode);
                        }
                        if (splits[i].ToLower().Contains("divisioncode"))
                        {
                            string divisionCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                            queryable = queryable.Where(row => row.Authority.DivisionCode == divisionCode);
                        }
                        if (splits[i].ToLower().Contains("statusid"))
                        {
                            int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Authority.StatusId == statusId);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.KeyWordExtQueryable", ex);
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> DateQueryable(IQueryable<SQLEntity> queryable, params BaseMode.Date[] dates)
        {
            try
            {
                if (dates != null)
                {
                    dates.ToList().ForEach(date =>
                    {
                        if (date.Name.ToLower().Equals("applierdate"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Authority.ApplierDate >= date.MinDate && row.Authority.ApplierDate <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("approverdate"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Authority.ApproverDate >= date.MinDate && row.Authority.ApproverDate <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.DateQueryable", ex);
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> StatusQueryable(IQueryable<SQLEntity> queryable, BaseMode.Status status)
        {
            try
            {
                if (status != null && status.Values.Count() > 0)
                {
                    return queryable.Where(row => status.Values.Contains(row.Authority.StatusValue??0));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.StatusQueryable", ex);
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="sorts"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> SortQueryable(IQueryable<SQLEntity> queryable, params BaseMode.Sort[] sorts)
        {
            try
            {
                if (sorts != null)
                {
                    if (sorts.Length == 1)
                    {
                        queryable = queryable.OrderBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.{sorts[0].Name}", sorts[0].Mode);
                    }
                    else
                    {
                        for (int i = 1; i < sorts.Length; i++)
                        {
                            queryable = queryable.ThenBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.{sorts[i].Name}", sorts[i].Mode);
                        }
                    }
                }
                else
                {
                    queryable = queryable.DefaultBy($"{typeof(SQLEntity).ReflectedType.Name.Replace("Service", "")}.id");
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.SortQueryable", ex);
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected IQueryable<SQLEntity> PageQueryable(IQueryable<SQLEntity> queryable, BaseMode.Page page)
        {
            try
            {
                if (page != null)
                {
                    queryable = queryable
                       .Take(page.Index * page.Size)
                       .Skip(page.Size * (page.Index - 1));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Authority SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Authority authorityEntity = entity.Authority;
                // 申请人
                authorityEntity.Applier = entity.Applier ?? null;
                // 审批人
                authorityEntity.Approver = entity.Approver ?? null;
                // 状态
                authorityEntity.Status = entity.Status ?? null;
                // 返回
                return authorityEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Authority> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.AuthorityService.SQLEntityToList", ex);
            }
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        protected class SQLEntity
        {
            /// <summary>
            /// 
            /// </summary>
            public Authority Authority { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Member Applier { get; set; }
            /// <summary>
            /// 审批人
            /// </summary>
            public Entities.AVM.User Approver { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Status Status { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class SummaryEntity
        {

        }
        #endregion
    }
}