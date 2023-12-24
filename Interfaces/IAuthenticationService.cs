using AuthorizationWithJWT.Dto;

namespace AuthorizationWithJWT.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> GetAccessToken(AuthenticationRequestDto requestDto);
    }
}
