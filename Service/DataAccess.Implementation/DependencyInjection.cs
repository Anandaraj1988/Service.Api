namespace ServiceApi.DataAccess.Implementation
{
    using Microsoft.Extensions.DependencyInjection;
    using DataAccess.Interface;

    public static class DependencyInjection
    {
        public static void AddDataAccessInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserDataProvider, UserDataProvider>();
        }
    }
}
