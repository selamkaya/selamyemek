using SelamYemek.Api.Extensions;
using SelamYemek.Api.Filters;
using SelamYemek.Caching;
using SelamYemek.Caching.Base;
using SelamYemek.Common;
using SelamYemek.Data;
using SelamYemek.Repository;
using SelamYemek.Repository.Base;
using SelamYemek.Service;
using SelamYemek.Service.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelamYemek.Api 
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddStackExchangeRedisCache(config =>
            {
                config.Configuration = Configuration.GetValue("RedisConfiguration", "");
            });

            services.AddMvc()
                .AddMvcOptions(o => o.AddFiltersExt())
                .AddJsonOptionsExt();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRedisOperation, RedisOperation>();

            services.AddSwaggerExt();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerExt();

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new VoidResult()
                        {
                            Code = 500,
                            Message = ex.Message
                        }));
                }
                });
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
