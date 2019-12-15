using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWelcomeService, WelcomeService>(); //AddTransient  ,  AddScoped
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication("ApiKey").AddScheme<AuthenticationSchemeOptions, ApiKeyAuth>("ApiKey", null);
            // services.Discovery();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.0",
                    Title = "QMFrameWork WebAPI",
                    Description = "启梦框架",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "QMFrameWork", Email = "792559417@qq.com", Url = "https://blog.csdn.net/weixin_42550800" }
                });

                //  c.DocInclusionPredicate((docName, description) => true);
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });//api界面新增authorize按钮

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,

                //        },
                //        new List<string>()
                //    }
                //});


            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement            {
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "ApiKey" }
            //        }, new List<string>() }
            //});
                //var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                //var xmlPath = Path.Combine(basePath, "TrySwaggerCore.xml");
                //c.IncludeXmlComments(xmlPath, true);
            });
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IWelcomeService welcomeService,IConfiguration config)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             
            app.UseMvc(builder =>
            {
                builder.MapRoute("Default", "{controller}/{action}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });

            app.Run(async (context) =>
            {
                // var welcome = welcomeService.GetMessage(); 
                var welcomeFromCfg = config["WelcomeInConfig"];
                await context.Response.WriteAsync(welcomeFromCfg);
            });
        }
    }
}
