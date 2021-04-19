using MISApi.CacheServices.WFM;
using MISApi.Dal.EF;
using MISApi.Entities.AVM;
using MISApi.Entities.WFM;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISApi.Services.AVM
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.UserService.CreateService
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
            public virtual User ToStatus(User entity, string statusKey)
            {
                try
                {
                    // 定义
                    User result = new User();
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
                    throw new Exception("MISApi.Services.AVM.UserService.CreateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量创建指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<User> BatchToStatus(List<User> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<User> results = new List<User>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new UserService.CreateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.AVM.UserService.CreateService.BatchToStatus", ex);
                }
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.UserService.UpdateService
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
            public virtual User ToStatus(User entity, string statusKey)
            {
                try
                {
                    // 定义
                    User result = new User();
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
                    throw new Exception("MISApi.Services.AVM.UserService.UpdateService.ToStatus", ex);
                }
            }
            /// <summary>
            /// 批量编辑指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<User> BatchToStatus(List<User> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<User> results = new List<User>();
                    // 事务
                    transService.TransRegist(delegate {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new UserService.UpdateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.AVM.UserService.UpdateService.BatchToStatus", ex);
                }
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.UserService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.UserService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.UserService.RowService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public User Verify(string key, string password)
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
                                    (row.User.Name == key && row.User.Password == encrypt) ||
                                    (row.User.Mobile == key && row.User.Password == encrypt) ||
                                    (row.User.Email == key && row.User.Password == encrypt)
                                ) && row.User.StatusValue == 1)
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.AVM.UserService.RowService.Verify", ex);
                    }
                }
            }
        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.UserService.RowsService
        {

        }

        #endregion
    }
}