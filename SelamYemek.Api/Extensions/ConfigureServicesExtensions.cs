using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SelamYemek.Api.Filters;

namespace SelamYemek.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static void AddSwaggerExt(this IServiceCollection services)
        {
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Yemek",
                    Version = "v1",
                    Description = "Api Yemek"
                });
            });
        }

        public static void UseSwaggerExt(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(o => {
                o.RoutePrefix = "swagger";
            });
        }

        public static void AddFiltersExt(this MvcOptions mvcOptions)
        {
            mvcOptions.Filters.Add<ValidationFilter>();
        }

        public static IMvcBuilder AddJsonOptionsExt(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddJsonOptions(o => {
                o.JsonSerializerOptions.IgnoreNullValues = true;
            });
            return mvcBuilder;
        }
    }
}
