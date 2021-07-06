using System;

namespace MISApi.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// 转换Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long DateTimeToInt(DateTime time)
        {
            try
            {
                DateTime dd = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                TimeSpan ts = (time - dd);
                return (long)ts.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.ConvertHelper.ConvertDateTimeToInt", ex);
            }
        }
        /// <summary>        
        /// 时间戳转为C#格式时间        
        /// </summary>        
        /// <param name="timeStamp"></param>        
        /// <returns></returns>        
        public static DateTime StringToDateTime(string timeStamp)
        {
            try
            {
                DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
                long lTime = long.Parse(timeStamp + "0000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dtStart.Add(toNow);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.ConvertHelper.StringToDateTime", ex);
            }
        }
        /// <summary>
        /// 字符转数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long StringToInt(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.ConvertHelper.StringToInt", ex);
            }
        }
        /// <summary>
        /// 对象转字符
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjectToString(object o)
        {
            try
            {
                return o.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.ConvertHelper.ObjectToString", ex);
            }
        }
        /// <summary>
        /// 对象转数字
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int ObjectToInt(object o)
        {
            try
            {
                return (int)o;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Tools.ConvertHelper.ObjectToInt", ex);
            }
        }
    }
}
