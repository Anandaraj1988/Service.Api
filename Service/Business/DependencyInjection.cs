using Microsoft.Extensions.DependencyInjection;
using ServiceApi.Business.Implementation;
using ServiceApi.Business.Interface;

namespace ServiceApi.Business
{
    public static class DependencyInjection
    {
        public static void AddBusinessInjection(this IServiceCollection services)
        {
            // Add business validators

            // Add business implementations
            services.AddTransient<IUserDataService, UserDataService>();
        }
    }
}
