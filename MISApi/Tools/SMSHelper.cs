using MISApi.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISApi.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class SMSHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string AuthCode(string mobile)
        {
            try
            {
                var account = "manyun106vgx2";
                var timestamps = Convert.ToInt64((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds).ToString();
                // 接口密码(msvZrIhi) + 手机号 + 时间戳 MD5加密
                var password = EncryptHelper.GetMD5($"msvZrIhi{mobile}{timestamps}");
                var code = RandHelper.GenerateRandomNumber(6);
                var content = $"您的验证码是：{code}，有效时间10分钟。";
                // 调用短信API
                HttpClientHelper.HttpGetResponse(
                    new List<KeyValuePair<string, string>>
                    {
                    new KeyValuePair<string, string>("account", account),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("mobile", mobile),
                    new KeyValuePair<string, string>("content", content),
                    new KeyValuePair<string, string>("timestamps", timestamps),
                    new KeyValuePair<string, string>("extNumber", ""),
                    new KeyValuePair<string, string>("extInfo", "")
                    },
                    "http://sapi.appsms.cn:8088/msgHttp/json/mt"
                );
                // 返回结果
                return code;
            }
            catch(Exception ex)
            {
                throw new Exception("MISApi.Tools.SMSHelper.Send", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public class Entity
        {
            /// <summary>
            /// 
            /// </summary>
            public string Mobile { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime SMSDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Type { get; set; }
        }
    }
}
