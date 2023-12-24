using AuthorizationWithJWT.Dto;
using AuthorizationWithJWT.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithJWT.Controllers
{

    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("api/Authentication")]
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponseDto>> Authenticate([FromBody] AuthenticationRequestDto request)
        {
            return await _authenticationService.GetAccessToken(request);
        }
    }
}
