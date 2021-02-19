using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

namespace GatewayApi
{
    public class ConfigurationHelper
    {

        public static readonly IConfiguration Configuration;

        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return Configuration.GetValue<string>(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return Configuration.GetConnectionString(key);
        }
    }
}
