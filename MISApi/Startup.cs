using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using IDocumentFilter = Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter;

namespace MISApi
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 属性
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Json
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // 忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 不使用驼峰
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // 设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //// DefaultValue默认值
                //options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                //// NullValue默认值
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("mis", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MIS API",
                    Description = "API for MIS",
                    Contact = new OpenApiContact() { Name = "wenzhutech", Email = "wenzhutech@163.com" }
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
                options.CustomSchemaIds(x => x.FullName);
                options.EnableAnnotations();

                var bearerScheme = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "请输入带有Bearer的Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                };
                // Add security definitions
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            // JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,
                    ValidIssuer = "http://localhost:44319",
                    ValidAudience = "api",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("This is ocelot security key"))
                };
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            // 启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            // 启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/mis/swagger.json", "MIS Docs");
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "MIS API";
                options.DocExpansion(DocExpansion.None);
            });

            // 启用中间件服务进行异常处理
            app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });
            // 启用路由
            app.UseRouting();
            // 必须出于UseRouting与UseEndpoints之间
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // 使用 RouteAttribute
                endpoints.MapControllers();
            });
            // 启动静态路径
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            // 启动基础表的缓存
            new CacheStartup();
            // 启动重定向
            app.Run(context =>
            {
                context.Response.Redirect("swagger");
                return Task.FromResult(0);
            });
        }
    }

    /// <summary>
    /// 用于swagger生成文档的标签描述
    /// </summary>
    public class MISDocumentFilter : IDocumentFilter
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag{ Name="User", Description="授权中心接口"},
            };
        }
    }
}