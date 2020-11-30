using Microsoft.AspNetCore.Mvc;

namespace ServiceApi.Api.Controllers.V1
{
    using Business.Filters;

    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class SecretController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecret()
        {
            return Ok("I have no Secret");
        }
    }
}
