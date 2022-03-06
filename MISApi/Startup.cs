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
        /// ���캯��
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ����
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
                // ����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // ��ʹ���շ�
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // ����ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //// DefaultValueĬ��ֵ
                //options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                //// NullValueĬ��ֵ
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
                    Description = "���������Bearer��Token",
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
            // �����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            // �����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/mis/swagger.json", "MIS Docs");
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "MIS API";
                options.DocExpansion(DocExpansion.None);
            });

            // �����м����������쳣����
            app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });
            // ����·��
            app.UseRouting();
            // �������UseRouting��UseEndpoints֮��
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // ʹ�� RouteAttribute
                endpoints.MapControllers();
            });
            // ������̬·��
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            // ����������Ļ���
            new CacheStartup();
            // �����ض���
            app.Run(context =>
            {
                context.Response.Redirect("swagger");
                return Task.FromResult(0);
            });
        }
    }

    /// <summary>
    /// ����swagger�����ĵ��ı�ǩ����
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
                new OpenApiTag{ Name="User", Description="��Ȩ���Ľӿ�"},
            };
        }
    }
}