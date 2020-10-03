using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceApi.Api.Controllers.V1
{
    using Business.Interface;
    using Api.Model.V1;
    using Business.Filters;

    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        readonly IUserDataService serviceProvider;

        public UserController(IUserDataService _serviceProvider)
        {
            this.serviceProvider = _serviceProvider;
        }

        //[HttpGet("ShowName")]
        //public string DisplayName()
        //{
        //    return "Its Anandaraj";
        //}

        [HttpPost("AddUser")]
        public async Task<ActionResult<bool>> CreateUser([FromQuery]CreateUserRequest request)
        {
            return await serviceProvider.CreateUserAsync(request.UserName, request.Password, request.Domain, request.UserRole);
        }
    }
}
