using MISApi.Dal.EF;
using MISApi.Entities.ASM;
using BaseMode = MISApi.HttpClients.HttpModes.BaseMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MISApi.CacheServices.ASM
{
    /// <summary>
    /// 
    /// </summary>
    public class DictionaryCacheService : BaseCacheService.EF<Dictionary, PandoraContext>
    {

        #region RPC CreateMode
        /// <summary>
        /// CreateMode Service
        /// </summary>
        public class CreateService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public override Dictionary Create(Dictionary dictionary)
            {
                return Dictionary.Instance.Insert(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Create(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Insert(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }

        #endregion

        #region RPC UpdateMode
        /// <summary>
        /// UpdateMode Service
        /// </summary>
        public class UpdateService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public override Dictionary Update(Dictionary dictionary)
            {
                return Dictionary.Instance.Update(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Update(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Update(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }
        #endregion

        #region RPC DeleteMode
        /// <summary>
        /// DeleteMode Service
        /// </summary>
        public class DeleteService : DictionaryCacheService
        {
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionary"></param>
            /// <returns></returns>
            public override Dictionary Delete(Dictionary dictionary)
            {
                return Dictionary.Instance.Delete(dictionary);
            }
            /// <summary>
            /// 默认的基础方法
            /// </summary>
            /// <param name="dictionaryList"></param>
            /// <returns></returns>
            public override List<Dictionary> Delete(List<Dictionary> dictionaryList)
            {
                dictionaryList.ForEach(
                        dictionary =>
                        {
                            Dictionary.Instance.Delete(dictionary);
                        }
                    );
                return dictionaryList;
            }
        }
        #endregion

        #region RPC Read ColumnsMode
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : DictionaryCacheService
        {
            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Dictionary Sample()
            {
                try
                {
                    return new Dictionary();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.ColumnsService.Sample", ex);
                }
            }

            /// <summary>
            /// 返回字段集
            /// </summary>
            /// <returns></returns>
            public Dictionary Full()
            {
                try
                {
                    return new Dictionary();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.ColumnsService.Full", ex);
                }
            }
        }

        #endregion

        #region RPC Read RowMode

        /// <summary>
        /// 
        /// </summary>
        public class RowService : DictionaryCacheService
        {
            /// <summary>
            /// 根据 id 查询
            /// </summary>
            /// <param name="id">Id</param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public Dictionary ById(int id, params BaseMode.Join[] joins)
            {
                try
                {
                    return SQLEntityToSingle(
                            SQLToList()
                                .Where(row => row.Id == id)
                                .SingleOrDefault()
                        );
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.ById", ex);
                }
            }
            /// <summary>
            /// 根据 key 查询
            /// </summary>
            /// <param name="key"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public Dictionary ByKey(string key, params BaseMode.Join[] joins)
            {
                try
                {
                    return SQLEntityToSingle(
                            SQLToList()
                                .Where(row => row.Key == key)
                                .SingleOrDefault()
                        );
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.ByKey", ex);
                }
            }
            /// <summary>
            /// 首记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public Dictionary First(string keyWord, BaseMode.Status status)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return SQLEntityToSingle(
                            list.FirstOrDefault()
                        );
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.First", ex);
                }
            }
            /// <summary>
            /// 末记录
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public Dictionary Last(string keyWord, BaseMode.Status status)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.LastOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.Last", ex);
                }
            }
            /// <summary>
            /// 下一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public Dictionary Next(int id, string keyWord, BaseMode.Status status)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord + "^Id>" + id);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.Next", ex);
                }
            }
            /// <summary>
            /// 上一条
            /// </summary>
            /// <param name="id"></param>
            /// <param name="keyWord"></param>
            /// <param name="status"></param>
            /// <param name="joins"></param>
            /// <returns></returns>
            public Dictionary Prev(int id, string keyWord, BaseMode.Status status, params BaseMode.Join[] joins)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord + "^Id<" + id);
                    // status查询
                    list = StatusToList(list, status);
                    // 返回结果
                    return list.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowService.Prev", ex);
                }
            }
        }

        #endregion

        #region RPC Read RowsMode

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : DictionaryCacheService
        {
            /// <summary>
            /// 关键字查询
            /// </summary>
            /// <param name="keyWord">关键字</param>
            /// <returns></returns>
            public List<Dictionary> ByKeyWord(string keyWord)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord);
                    // 返回结果
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowsService.ByKeyWord", ex);
                }
            }
            /// <summary>
            /// 分页查询
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="page"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public List<Dictionary> Page(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Page page, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord.Value);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord.Ext);
                    // status查询
                    list = StatusToList(list, status);
                    // 时间范围查询
                    list = DateToList(list, dates);
                    // 排序
                    list = SortToList(list, sorts);
                    // 分页
                    list = PageToList(list, page);
                    // 返回
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowsService.Page", ex);
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
                try
                {
                    // 定义
                    var list = SQLToList();
                    // keyWord查询
                    list = KeyWordToList(list, keyWord.Value);
                    // keyWordExt查询
                    list = KeyWordExtToList(list, keyWord.Ext);
                    // status查询
                    list = StatusToList(list, status);
                    // 时间范围查询
                    list = DateToList(list, dates);
                    // 返回
                    return list.Count();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowsService.PageCount", ex);
                }
            }
            /// <summary>
            /// 汇总信息
            /// </summary>
            /// <param name="keyWord"></param>
            /// <param name="joins"></param>
            /// <param name="dates"></param>
            /// <param name="sorts"></param>
            /// <param name="status"></param>
            /// <returns></returns>
            public SummaryEntity PageSummary(BaseMode.KeyWord keyWord, BaseMode.Join[] joins, BaseMode.Date[] dates, BaseMode.Sort[] sorts, BaseMode.Status status)
            {
                try
                {
                    // 返回
                    return new SummaryEntity();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.RowsService.PageSummary", ex);
                }
            }
        }

        #endregion

        #region RPC Read SingleMode
        /// <summary>
        /// 
        /// </summary>
        public class SingleService : RowService
        {

        }

        #endregion

        #region RPC Read QueryMode

        /// <summary>
        /// 
        /// </summary>
        public class QueryService : RowsService
        {

        }

        #endregion

        #region RPC Read TreeMode

        /// <summary>
        /// 
        /// </summary>
        public class TreeService : DictionaryCacheService
        {
            #region 调用RowService的方法
            /// <summary>
            ///  根据 id 查询
            ///  1. 本方法返回是单条记录
            /// </summary>
            /// <param name="id">id</param>
            /// <param name="joins">可变参数</param>
            /// <returns></returns>
            public List<Dictionary> ById(int id, params BaseMode.Join[] joins)
            {
                List<Dictionary> resultList = new List<Dictionary>();
                resultList.Add(
                        new RowService().ById(id, joins)
                    );
                return resultList;
            }
            #endregion

            #region 调用RowsService的方法
            /// <summary>
            /// 关键字查询
            /// </summary>
            /// <param name="keyWord"></param>
            /// <returns></returns>
            public List<Dictionary> ByKeyWord(string keyWord)
            {
                return new RowsService().ByKeyWord(keyWord);
            }
            #endregion
        }
        #endregion

        #region Inner Method

        /// <summary>
        /// 
        /// </summary>
        public List<Dictionary> CacheAll()
        {
            try
            {
                return SQLToList();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.CacheAll", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="entityList"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private decimal Sum(Func<Dictionary, decimal> selector, List<Dictionary> entityList, params BaseMode.Join[] joins)
        {
            try
            {
                return entityList.Sum(selector);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.Sum", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="entityList"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private int Sum(Func<Dictionary, int> selector, List<Dictionary> entityList, params BaseMode.Join[] joins)
        {
            try
            {
                return entityList.Sum(selector);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.Sum", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private Dictionary SQLEntityToSingle(Dictionary entity)
        {
            if (entity == null)
                return null;
            else
            {
                // 主表
                Dictionary dictionary = entity;
                // 返回
                return dictionary;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyWord"></param>
        /// <param name="joins"></param>
        /// <returns></returns>
        private List<Dictionary> KeyWordToList(List<Dictionary> list, string keyWord, params BaseMode.Join[] joins)
        {
            try
            {
                // 截取keyWord
                keyWord = keyWord.IndexOf("^") == -1 ? keyWord : keyWord.Substring(0, keyWord.IndexOf("^"));
                // #分割生成数组
                string[] ands = keyWord.Split('#');
                // 空格分割生成数组
                string[] ors = Regex.Split(keyWord, "\\s+", RegexOptions.IgnoreCase);
                // 多个条件精确查询，单个条件关键字查询
                if (ands.Length > 1)
                {
                    for (var i = 0; i < ands.Length; i++)
                    {
                        var andKeyWord = ands[i];
                        list = list.Where(row =>
                                row.Name.Contains(andKeyWord) ||
                                row.Desc.Contains(andKeyWord)
                            ).ToList();
                    }
                }
                else if (ors.Length > 1)
                {
                    list = list.Where(row =>
                            ors.Contains(row.Name) ||
                            ors.Contains(row.Desc)
                        ).ToList();
                }
                else
                {
                    list = list.Where(row =>
                            row.Name.Contains(keyWord) ||
                            row.Desc.Contains(keyWord)
                        ).ToList();
                }
                // 返回
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.KeyWordToList", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        private List<Dictionary> KeyWordExtToList(List<Dictionary> list, string keyWord)
        {
            try
            {
                if (keyWord.IndexOf("^") != -1)
                {
                    // 截取keyWordExt
                    var keyWordExt = keyWord.Substring(keyWord.IndexOf("^") + 1, keyWord.Length - keyWord.IndexOf("^") - 1);
                    // 拆分查询条件
                    var splits = keyWordExt.Split('^');
                    // 循环
                    for (var i = 0; i < splits.Length; i++)
                    {

                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.KeyWordExtToList", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        private List<Dictionary> DateToList(List<Dictionary> list, params BaseMode.Date[] dates)
        {
            try
            {
                dates.ToList().ForEach(date =>
                {
                    if (date.Name.ToLower().Equals("createdatetime"))
                    {
                        list = list.Where(row =>
                            row.CreateDateTime >= date.MinDate && row.CreateDateTime <= date.MaxDate
                        ).ToList();
                    }
                });
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.DateToList", ex);
            }
        }
        /// <summary>
        /// 数据字典
        /// </summary>
        /// <param name="list"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private List<Dictionary> StatusToList(List<Dictionary> list, BaseMode.Status status)
        {
            try
            {
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.StatusToList", ex);
            }
        }
        /// <summary>
        ///  排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sorts"></param>
        /// <returns></returns>
        private List<Dictionary> SortToList(List<Dictionary> list, params BaseMode.Sort[] sorts)
        {
            try
            {
                return list.OrderBy(row => row.Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.SortToList", ex);
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="list"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        private List<Dictionary> PageToList(List<Dictionary> list, BaseMode.Page page)
        {
            try
            {
                return list
                   .Take(page.Index * page.Size)
                   .Skip(page.Size * (page.Index - 1))
                   .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.PageToList", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Dictionary> SQLToList()
        {
            try
            {
                return Dictionary.Instance.CacheAll();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.CacheServices.ASM.DictionaryCacheService.SQLToList", ex);
            }
        }
        #endregion

        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        public class SummaryEntity
        {

        }
        #endregion
    }
}