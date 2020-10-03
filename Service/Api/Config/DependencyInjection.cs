using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ServiceApi.Business;
using ServiceApi.Business.Common;
using ServiceApi.Business.MappingProfile;
using ServiceApi.DataAccess.Implementation;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ServiceApi.Api.Config
{
    internal static class DependencyInjection
    {
        internal static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessInjection();
            services.AddDataAccessInjection();

            // handle settings/options
            services.AddOptions();
            services.Configure<SwaggerAppSettings>(configuration.GetSection(nameof(SwaggerAppSettings)));
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
            var sp = services.BuildServiceProvider();

            // other part
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(BusinessMappingProfile));
        }
    }
}
