using MISApi.Dal.EF;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MISApi.Entities.ASM;
using MISApi.Entities.WFM;

namespace MISApi.Services.ASM.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class HospitalService : BaseService.EF<Hospital, PandoraContext>
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : HospitalService
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
            public Hospital Execute(Hospital entity)
            {
                try
                {
                    // 定义
                    Hospital result = new Hospital();
                    // 事务
                    transService.TransRegist(delegate {
                        entity = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.CreateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Hospital> Execute(List<Hospital> entityList)
            {
                try
                {
                    // 定义
                    List<Hospital> resultList = new List<Hospital>();
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
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.CreateService.Execute", ex);
                }
            }

        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : HospitalService
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
            public Hospital Execute(Hospital entity)
            {
                try
                {
                    // 定义
                    Hospital result = new Hospital();
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
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.UpdateService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entityList"></param>
            /// <returns></returns>
            public List<Hospital> Execute(List<Hospital> entityList)
            {
                try
                {
                    // 定义
                    List<Hospital> resultList = new List<Hospital>();
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
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.UpdateService.Execute", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : HospitalService
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
            public Hospital Execute(Hospital entity)
            {
                try
                {
                    // 定义
                    Hospital result = new Hospital();
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
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.DeleteService.Execute", ex);
                }
            }
            /// <summary>
            /// 默认的事务方法
            /// </summary>
            /// <param name="entitys"></param>
            /// <returns></returns>
            public List<Hospital> Execute(List<Hospital> entitys)
            {
                try
                {
                    // 定义
                    List<Hospital> resultList = new List<Hospital>();
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
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.DeleteService.Execute", ex);
                }
            }
        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : HospitalService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Hospital Single()
            {
                try
                {
                    return new Hospital();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.ColumnsService.Execute", ex);
                }
            }
        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : HospitalService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Hospital ById(int id, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Hospital.Id == id)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowService.ById", ex);
                    }
                }
            }
            /// <summary>
            /// 根据 key 查询
            /// </summary>
            /// <param name="key">Key</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public Hospital ByKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context, joins)
                                .Where(row => row.Hospital.Key == key)
                                .SingleOrDefault()
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowService.ByKey", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : HospitalService
        {
            /// <summary>
            /// 根据关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Hospital> ByKeyWord(BaseMode.KeyWord keyWord, params BaseMode.Join[] joins)
            {
                try
                {
                    return new RowsService().Page(keyWord, joins, null, null, null, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 根据父节点Id查询
            /// </summary>
            /// <param name="pid">父节点Id</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Hospital> ByPid(int pid, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToList(
                                SQLQueryable(context, joins).Where(row => row.Hospital.Pid == pid).ToList()
                            );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.ByPid", ex);
                    }
                }
            }
            /// <summary>
            /// 根据父节点键名查询
            /// </summary>
            /// <param name="key">父节点键名</param>
            /// <param name="joins">关联表</param>
            /// <returns></returns>
            public List<Hospital> ByParentKey(string key, params BaseMode.Join[] joins)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        Hospital hospital = new RowService().ByKey(key);
                        return new RowsService().ByPid(hospital == null ? 0 : hospital.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.ByParentKey", ex);
                    }
                }
            }
            /// <summary>
            /// 根据Key查询所有子节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Hospital> SubsetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Hospital> list = new RowService().ByKey(key) == null ? new List<Hospital>() : new List<Hospital> { new RowService().ByKey(key) };
                    return SubsetByIdRecursion(list, list[0].Id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.SubsetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Key查询所有父节点（递归并包含Key自身）
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Hospital> SupersetByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    Hospital currentHospital = new RowService().ByKey(key) ?? new Hospital();
                    List<Hospital> result = SupersetByIdRecursion(new List<Hospital>(), currentHospital.Pid, joins);
                    result.Add(currentHospital);
                    string path = "^";
                    // 生成path
                    result.ForEach(hospital =>
                    {
                        path = hospital.Path = $"{path}{hospital.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.SupersetByKey", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有子节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Hospital> SubsetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    List<Hospital> list = new RowService().ById(id) == null ? new List<Hospital>() : new List<Hospital> { new RowService().ById(id) };
                    return SubsetByIdRecursion(list, id, joins);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.SubsetById", ex);
                }
            }
            /// <summary>
            /// 根据Id查询所有父节点（递归并包含Id自身）
            /// </summary>
            /// <param name="id"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public List<Hospital> SupersetById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    Hospital currentHospital = new RowService().ById(id);
                    List<Hospital> result = SupersetByIdRecursion(new List<Hospital>(), currentHospital.Pid, joins);
                    result.Add(currentHospital);
                    string path = "^";
                    // 生成path
                    result.ForEach(hospital =>
                    {
                        path = hospital.Path = $"{path}{hospital.Name}^";
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.SupersetById", ex);
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
            public List<Hospital> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
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
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.Page", ex);
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
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.PageCount", ex);
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
                        throw new Exception("MISApi.Services.ASM.Base.HospitalService.RowsService.PageSummary", ex);
                    }
                }
            }
        }

        #endregion

        #region Inner Methods
        /// <summary>
        /// 根据Key递归获取Hospital
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Hospital> SubsetByKeyRecursion(List<Hospital> list, string key, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    var entity = new RowService().ByKey(key);
                    if (entity != null)
                    {
                        SubsetByIdRecursion(list, entity.Id, joins);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.SubsetByKeyRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Key递归获取Hospital
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Hospital> SupersetByKeyRecursion(List<Hospital> list, string key, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    var entity = new RowService().ByKey(key);
                    if (entity != null)
                    {
                        SupersetByIdRecursion(list, entity.Id, joins);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.SupersetByKeyRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Id递归获取Hospital
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Hospital> SubsetByIdRecursion(List<Hospital> list, int id, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Hospital.Pid == id).ToList().ForEach(sqlEntity => {
                        list.Add(sqlEntity.Hospital);
                        SubsetByIdRecursion(list, sqlEntity.Hospital.Id, joins);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.SubsetByIdRecursion", ex);
                }
            }
        }
        /// <summary>
        /// 根据Id递归获取Hospital
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pid"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Hospital> SupersetByIdRecursion(List<Hospital> list, int pid, params BaseMode.Join[] joins)
        {
            using (PandoraContext context = new PandoraContext())
            {
                try
                {
                    SQLQueryable(context, joins).Where(row => row.Hospital.Id == pid).ToList().ForEach(sqlEntity => {
                        SupersetByIdRecursion(list, sqlEntity.Hospital.Pid, joins);
                        list.Add(sqlEntity.Hospital);
                    });
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.ASM.Base.HospitalService.SupersetByIdRecursion", ex);
                }
            }
        }
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
                var left = context.ASM_Hospital.Select(Main => new SQLEntity
                {
                    Hospital = Main
                });
                // 遍历
                foreach (var join in joins)
                {
                    // SQLEntity.ParentHospital
                    if (join.Name.ToLower().Equals("parenthospital"))
                    {
                        left = left.LeftOuterJoin(context.ASM_Hospital, Main => Main.Hospital.Pid, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Hospital = Main.Hospital,
                            ParentHospital = Left,
                            Status = Main.Status
                        });
                    }
                    // SQLEntity.Status
                    if (join.Name.ToLower().Equals("status"))
                    {
                        left = left.LeftOuterJoin(context.WFM_Status, Main => Main.Hospital.StatusId, Left => Left.Id, (Main, Left) => new SQLEntity
                        {
                            Hospital = Main.Hospital,
                            ParentHospital = Main.ParentHospital,
                            Status = Left
                        });
                    }
                }
                // 一对多
                var group = left.Select(Main => new SQLEntity
                {
                    Hospital = Main.Hospital,
                    ParentHospital = Main.ParentHospital,
                    Status = Main.Status
                });
                // 遍历
                foreach (var join in joins)
                {

                }
                // 返回
                return group;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.SQLQueryable", ex);
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
                                row.Hospital.Name.Contains(andKeyWord) ||
                                row.Hospital.Key.Contains(andKeyWord) ||
                                row.Hospital.Desc.Contains(andKeyWord) ||
                                row.Hospital.Address.Contains(andKeyWord) ||
                                row.Hospital.Phone.Contains(andKeyWord) ||
                                row.Hospital.NationName.Contains(andKeyWord) ||
                                row.Hospital.ProvinceName.Contains(andKeyWord) ||
                                row.Hospital.CityName.Contains(andKeyWord) ||
                                row.Hospital.DivisionName.Contains(andKeyWord) ||
                                row.Hospital.StatusName.Contains(andKeyWord)
                            );
                    }
                }
                else if (ors.Length > 1)
                {
                    queryable = queryable.Where(row =>
                            ors.Contains(row.Hospital.Name) ||
                            ors.Contains(row.Hospital.Key) ||
                            ors.Contains(row.Hospital.Desc) ||
                            ors.Contains(row.Hospital.Address) ||
                            ors.Contains(row.Hospital.Phone) ||
                            ors.Contains(row.Hospital.NationName) ||
                            ors.Contains(row.Hospital.ProvinceName) ||
                            ors.Contains(row.Hospital.CityName) ||
                            ors.Contains(row.Hospital.DivisionName) ||
                            ors.Contains(row.Hospital.StatusName)
                        );
                }
                else
                {
                    queryable = queryable.Where(row =>
                            row.Hospital.Name.Contains(keyWord) ||
                            row.Hospital.Key.Contains(keyWord) ||
                            row.Hospital.Desc.Contains(keyWord) ||
                            row.Hospital.Address.Contains(keyWord) ||
                            row.Hospital.Phone.Contains(keyWord) ||
                            row.Hospital.NationName.Contains(keyWord) ||
                            row.Hospital.ProvinceName.Contains(keyWord) ||
                            row.Hospital.CityName.Contains(keyWord) ||
                            row.Hospital.DivisionName.Contains(keyWord) ||
                            row.Hospital.StatusName.Contains(keyWord)
                        );
                }
                // 返回
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.KeyWordQueryable", ex);
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
                    if (splits[i].ToLower().Contains("nationcode"))
                    {
                        string nationCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                        queryable = queryable.Where(row => row.Hospital.NationCode == nationCode);
                    }
                    if (splits[i].ToLower().Contains("provincecode"))
                    {
                        string provinceCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                        queryable = queryable.Where(row => row.Hospital.ProvinceCode == provinceCode);
                    }
                    if (splits[i].ToLower().Contains("citycode"))
                    {
                        string cityCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                        queryable = queryable.Where(row => row.Hospital.CityCode == cityCode);
                    }
                    if (splits[i].ToLower().Contains("divisioncode"))
                    {
                        string divisionCode = splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1);
                        queryable = queryable.Where(row => row.Hospital.DivisionCode == divisionCode);
                    }
                    if (splits[i].ToLower().Contains("isgeneral"))
                    {
                        bool isGeneral = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Hospital.IsGeneral == isGeneral);
                    }
                    if (splits[i].ToLower().Contains("isspecial"))
                    {
                        bool isSpecial = bool.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Hospital.IsSpecial == isSpecial);
                    }
                    if (splits[i].ToLower().Contains("pid"))
                    {
                        int pid = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Hospital.Pid == pid);
                    }
                    if (splits[i].ToLower().Contains("statusid"))
                    {
                        int statusId = int.Parse(splits[i].Substring(splits[i].IndexOf("=") + 1, splits[i].Length - splits[i].IndexOf("=") - 1));
                        queryable = queryable.Where(row => row.Hospital.StatusId == statusId);
                    }
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.KeyWordExtQueryable", ex);
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
                        if (date.Name.ToLower().Equals("createdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Hospital.CreateDateTime >= date.MinDate && row.Hospital.CreateDateTime <= date.MaxDate
                                );
                        }
                        if (date.Name.ToLower().Equals("editdatetime"))
                        {
                            queryable = queryable
                                .Where(row =>
                                    row.Hospital.EditDateTime >= date.MinDate && row.Hospital.EditDateTime <= date.MaxDate
                                );
                        }
                    });
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.DateQueryable", ex);
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
                    return queryable.Where(row => status.Values.Contains(row.Hospital.StatusValue));
                }
                return queryable;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.StatusQueryable", ex);
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
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.SortQueryable", ex);
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
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.PageQueryable", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected Hospital SQLEntityToSingle(SQLEntity entity)
        {
            try
            {
                //判断搜索结果是否为空
                if (entity == null)
                    return null;
                // 主表
                Hospital hospitalEntity = entity.Hospital;
                // 上级医院
                hospitalEntity.ParentHospital = entity.ParentHospital ?? null;
                // 状态
                hospitalEntity.Status = entity.Status ?? null;
                // 返回
                return hospitalEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.SQLEntityToSingle", ex);
            }
        }
        /// <summary>
        /// SQLEntity转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<Hospital> SQLEntityToList(List<SQLEntity> list)
        {
            try
            {
                return list.ConvertAll(row => SQLEntityToSingle(row));
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.ASM.Base.HospitalService.SQLEntityToList", ex);
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
            public Hospital Hospital { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Hospital ParentHospital { get; set; }
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