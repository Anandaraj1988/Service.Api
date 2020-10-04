using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="request">
        /// CreateUserRequest
        /// UserName => string, 
        /// Password => string,
        /// Domain => string, 
        /// UserRole  => int => 100, 101, 102
        /// </param>
        /// <returns>Created User</returns>
        [HttpPost("AddUser")]
        public async Task<IEnumerable<User>> CreateUser([FromQuery] CreateUserRequest request) => 
            await serviceProvider.CreateUserAsync(request.UserName, request.Password, request.Domain, request.UserRole);

        /// <summary>
        /// LoginRequest
        /// </summary>
        /// <param name="request">
        /// LoginRequest
        /// UserName => string, 
        /// Password => string,
        /// </param>
        /// <returns>Return true/false</returns>
        [HttpGet("Login")]
        public async Task<LoginResult> UserLogin([FromQuery] LoginRequest request) => 
            await serviceProvider.UserLoginAsync(request.UserName, request.Password);
    }
}
