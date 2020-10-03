using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace ServiceApi.Api.Config
{
    internal static class Swagger
    {
        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
