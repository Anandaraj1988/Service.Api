using Microsoft.Extensions.DependencyInjection;

namespace ServiceApi.Business
{
    using Business.Implementation;
    using Business.Interface;

    public static class DependencyInjection
    {
        public static void AddBusinessInjection(this IServiceCollection services)
        {
            // Add business validators

            // Add business implementations
            services.AddTransient<IUserDataService, UserDataService>();
            services.AddTransient<IDomainDataService, DomainDataService>();
        }
    }
}
