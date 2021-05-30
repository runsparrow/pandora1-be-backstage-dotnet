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
    public class MemberService : BaseService.EF<Member, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : MemberService
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
            public Member Execute(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Member> Execute(List<Member> entityList)
            {
                try
                {
                    // 定义
                    List<Member> resultList = new List<Member>();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : MemberService
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
            public Member Execute(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Member> Execute(List<Member> entityList)
            {
                try
                {
                    // 定义
                    List<Member> resultList = new List<Member>();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : MemberService
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
            public Member Execute(Member entity)
            {
                try
                {
                    // 定义
                    Member result = new Member();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Member> Execute(List<Member> entitys)
            {
                try
                {
                    // 定义
                    List<Member> resultList = new List<Member>();
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
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : MemberService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Member Single()
            {
                try
                {
                    return new Member();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : MemberService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Member ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Member.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowService.ById", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 会员名并排除会员Id 查询
            /// </summary>
            /// <param name="name">会员名</param>
            /// <param name="id">会员Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Member ByName(string name, int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Member.Name == name && row.Member.Id != id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowService.ByName", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 手机号 查询
            /// </summary>
            /// <param name="mobile">手机号</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Member ByMobile(string mobile, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Member.Mobile == mobile)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowService.ByMobile", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 身份证 查询
            /// </summary>
            /// <param name="idCard">身份证</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Member ByIdCard(string idCard, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Member.IdCard == idCard)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowService.ByIdCard", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : MemberService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Member> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.Base.MemberService.RowsService.ByKeyWord", ex);
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
            public List<Member> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.CMS.Base.MemberService.RowsService.PageSummary", ex);
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
                var left = context.CMS_Member.Select(Main => new SQLEntity
                {
                    Member = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Member.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Member = Main.Member,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Member = Main.Member,
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
                throw new Exception("MISApi.Services.CMS.Base.MemberService.SQLQueryable", ex);
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
                                row.Member.Name.Contains(andKeyWord) ||
                                row.Member.Email.Contains(andKeyWord) ||
                                row.Member.Mobile.Contains(andKeyWord) ||
                                row.Member.LoginIPAddress.Contains(andKeyWord) ||
                                row.Member.Remark.Contains(andKeyWord) ||
                                row.Member.StatusName.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Member.Name) ||
                            ors.Contains(row.Member.Email) ||
                            ors.Contains(row.Member.Mobile) ||
                            ors.Contains(row.Member.LoginIPAddress) ||
                            ors.Contains(row.Member.Remark) ||
                            ors.Contains(row.Member.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Member.Name.Contains(keyWord) ||
                            row.Member.Email.Contains(keyWord) ||
                            row.Member.Mobile.Contains(keyWord) ||
                            row.Member.LoginIPAddress.Contains(keyWord) ||
                            row.Member.Remark.Contains(keyWord) ||
                            row.Member.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.MemberService.KeyWordQueryable", ex);
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
                        if (splits[i].ToLower().Contains("reuploadcount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.ReUploadCount >= min && row.Member.ReUploadCount <= max);
                        }
                        if (splits[i].ToLower().Contains("uploadcount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.UploadCount >= min && row.Member.UploadCount <= max);
                        }
                        if (splits[i].ToLower().Contains("redowncount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.ReDownCount >= min && row.Member.ReDownCount <= max);
                        }
                        if (splits[i].ToLower().Contains("downcount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.DownCount >= min && row.Member.DownCount <= max);
                        }
                        if (splits[i].ToLower().Contains("rebuycount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.ReBuyCount >= min && row.Member.ReBuyCount <= max);
                        }
                        if (splits[i].ToLower().Contains("buycount"))
                        {
                            decimal min = splits[i].IndexOf(">") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf(">") + 1, splits[i].Length - splits[i].IndexOf(">") - 1)) : int.MinValue;
                            decimal max = splits[i].IndexOf("<") > -1 ? decimal.Parse(splits[i].Substring(splits[i].IndexOf("<") + 1, splits[i].Length - splits[i].IndexOf("<") - 1)) : int.MaxValue;
                            queryable = queryable.Where(row => row.Member.BuyCount >= min && row.Member.BuyCount <= max);
                        }
                        if (splits[i].ToLower().Contains("isauthority"))
                        {
                            bool isAuthority = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Member.IsAuthority == isAuthority);
                        }
                        if (splits[i].ToLower().Contains("isself"))
                        {
                            bool isSelf = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Member.IsSelf == isSelf);
                        }
                        if (splits[i].ToLower().Contains("statusid"))
                        {
                            int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                            queryable = queryable.Where(row => row.Member.StatusId == statusId);
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
                throw new Exception("MISApi.Services.CMS.Base.MemberService.KeyWordExtQueryable", ex);
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
                        if (date.Name.ToLower().Equals("leveldeadline"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Member.LevelDeadline >= date.MinDate && row.Member.LevelDeadline <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("registdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Member.RegistDateTime >= date.MinDate && row.Member.RegistDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.MemberService.DateQueryable", ex);
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
                    return queryable.Where(row => status.Values.Contains(row.Member.StatusValue));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.MemberService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.MemberService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.CMS.Base.MemberService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Member SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Member memberEntity = entity.Member;
                // 状态
                memberEntity.Status = entity.Status ?? null;
                // 返回
                return memberEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.MemberService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Member> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.Base.MemberService.SQLEntityToList", ex);
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
            public Member Member { get; set; }
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