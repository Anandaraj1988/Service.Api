using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ServiceApi.Business.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiAdminRole = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiAdminRole, out var potentialApiSuperAdminRole))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiSuperAdminRole = configuration.GetValue<string>(key: "SuperAdmin");

            if (!apiSuperAdminRole.Equals(potentialApiSuperAdminRole))
            {
                context.Result = new UnauthorizedResult();
            }

            await next();
            //after
        }
    }
}
