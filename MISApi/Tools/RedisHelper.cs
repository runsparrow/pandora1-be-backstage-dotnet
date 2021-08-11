using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using System;
using System.Text;

namespace MISApi.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisHelper
    {
        private static RedisCache redisCache = null;
        private static RedisCacheOptions options = null;
        /// <summary>
        /// 
        /// </summary>
        static RedisHelper()
        {
            options = new RedisCacheOptions();
            options.Configuration = ConfigurationHelper.GetRedisConnectionString("Connection");
            options.InstanceName = ConfigurationHelper.GetRedisConnectionString("InstanceName");
            redisCache = new RedisCache(options);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="instanceName"></param>
        public RedisHelper(string connectionString, string instanceName)
        {
            options = new RedisCacheOptions();
            options.Configuration = connectionString;
            options.InstanceName = instanceName;
            redisCache = new RedisCache(options);
        }
        /// <summary>
        /// 添加string数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="exprireTime">过期时间 单位分钟</param>
        /// <returns></returns>
        public static bool SetStringValue(string key, string value, int exprireTime = 10)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            try
            {
                redisCache.SetString(key, value, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(exprireTime)
                });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.SetStringValue", ex);
            }
        }
        /// <summary>
        /// 获取string数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetStringValue(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return null;
                }
                else
                {
                    return redisCache.GetString(key);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.GetStringValue", ex);
            }
        }
        /// <summary>
        /// 添加string数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="exprireTime">过期时间 单位分钟</param>
        /// <returns></returns>
        public static bool SetValue(string key, object value, int exprireTime = 10)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }
                else
                {
                    redisCache.SetString(key, JsonConvert.SerializeObject(value), new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(exprireTime)
                    });
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.SetValue", ex);
            }
        }
        /// <summary>
        /// 获取string数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static T GetValue<T>(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return JsonConvert.DeserializeObject<T>(null);
                }
                else
                {
                    if(redisCache.GetString(key) == null)
                    {
                        return default(T);
                    }
                    return JsonConvert.DeserializeObject<T>(redisCache.GetString(key));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.GetValue", ex);
            }
        }
        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="key">键</param>
        public static bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            try
            {
                redisCache.Remove(key);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.Remove", ex);
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="key">键</param>
        public static bool Refresh(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            try
            {
                redisCache.Refresh(key);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.RedisHelper.Get", ex);
            }
        }
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">过期时间 单位小时</param>
        public static bool Replace(string key, string value, int expireTime = 24)
        {
            if (Remove(key))
            {
                return SetStringValue(key, value, expireTime);
            }
            else
            {
                return false;
            }
        }
    }
}
