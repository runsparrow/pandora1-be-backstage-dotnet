using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace MISApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                 .UseKestrel(options =>
                 {
                     options.Listen(IPAddress.Any, 8001, listenOptions =>
                     {
                         listenOptions.UseHttps("t-pic-cn-iis-1128142825.pfx", "t-pic.cn");
                     });
                 })
                .UseStartup<Startup>();
                webBuilder.UseIIS();
            }
        );
    }
}
