using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NetCoreExample.Interfaces.Contexts;
using NetCoreExample.Interfaces.Repository;
using NetCoreExample.Interfaces.Service;
using NetCoreExample.Model.Domains;
using NetCoreExample.Repositories.Contexts;
using NetCoreExample.Repositories.SqlServer;
using NetCoreExample.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NetCoreExample.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddJsonOptions(jsonOptions =>
                    {
                        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetCoreExample.API", Version = "v1" });
            });

            // Bind Configuration
            services.Configure<AppSetting>(Configuration);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSetting>>().Value);

            // TODO: SQL Connection
            // connectionstring            
            services.AddSingleton<IDbContext>(new DbContext(@"Server=192.168.0.10\SQLEXPRESS,1433;Database=TestAlex;Integrated Security=False;User Id=sa;Password=testlocal;MultipleActiveResultSets=True"));

            services.AddSingleton<IMenuRepository, MenuRepository>();
            services.AddSingleton<IMenuService, MenuService>();

            // Redis Cached
            var redisServer = Configuration["RedisServer"];
            var redisInstance = Configuration["RedisInstanceName"];
            var redisPassword = Configuration["RedisPassword"];
            var redisConnString = string.Format("{0}:6379,password={1}", redisServer, redisPassword);

            var redisCacheSetting = new RedisCacheSetting();
            Configuration.GetSection(nameof(RedisCacheSetting)).Bind(redisCacheSetting);
            if (redisCacheSetting.Enabled)
            {
                services.AddStackExchangeRedisCache((options) =>
                {
                    options.Configuration = redisConnString;
                    options.InstanceName = redisInstance;
                });
                services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCoreExample API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
