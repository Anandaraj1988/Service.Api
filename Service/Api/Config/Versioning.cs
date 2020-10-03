using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceApi.Config
{
    internal static class Versioning
    {
        internal static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
               {
                   options.DefaultApiVersion = new ApiVersion(1, 0);
                   options.AssumeDefaultVersionWhenUnspecified = true;
               });

            services.AddVersionedApiExplorer(options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}
