using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceApi.Api.Controllers.V1
{
    using Business.Filters;
    using Business.Interface;
    using ServiceApi.Api.Model.V1;

    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [AdminAuth]
    public class DomainController : ControllerBase
    {
        readonly IDomainDataService serviceProvider;

        public DomainController(IDomainDataService _serviceProvider)
        {
            this.serviceProvider = _serviceProvider;
        }

        /// <summary>
        /// CreateDomain
        /// </summary>
        /// <param name="request">
        /// CreateDomainRequest
        /// Name => string, 
        /// ApiKey => Guid
        /// </param>
        /// <returns>Created User</returns>
        [HttpPost("AddUser")]
        public async Task<Domain> CreateUser([FromQuery] CreateDomainRequest request) =>
            await serviceProvider.CreateDomainAsync(request.Name, request.ApiKey);
    }
}
