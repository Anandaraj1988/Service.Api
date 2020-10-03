using Microsoft.AspNetCore.Mvc;

namespace ServiceApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("ShowName")]
        public string DisplayName()
        {
            return "Its Anandaraj";
        }
    }
}
