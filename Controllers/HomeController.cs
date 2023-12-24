using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithJWT.Controllers
{
    public class HomeController : ControllerBase
    {
        [Authorize]
        [Route("api/Home")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Authentication works!");
        }
    }
}
