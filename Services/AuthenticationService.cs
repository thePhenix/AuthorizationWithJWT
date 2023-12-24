using AuthorizationWithJWT.Dto;
using AuthorizationWithJWT.Interfaces;
using AuthorizationWithJWT.JWTTokenOptions;
using AuthorizationWithJWT.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationWithJWT.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public readonly JwtOptions _jwtOptions;

        public AuthenticationService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<AuthenticationResponseDto> GetAccessToken(AuthenticationRequestDto authenticationRequestDto)
        {
            var user = await GetUserAsync(authenticationRequestDto);
            var authenticationResponse = new AuthenticationResponseDto();

            if (user != null)
            {
                var currentTime = DateTime.UtcNow;
                var expiryTime = currentTime.AddHours(1);
                var tokenHandler = new JwtSecurityTokenHandler();
                var credentialKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    }),
                    Audience = _jwtOptions.Audience,
                    Issuer = _jwtOptions.Issuer,
                    Expires = expiryTime,
                    SigningCredentials = new SigningCredentials(credentialKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                authenticationResponse.Token = token;
            }
            else
            {
                authenticationResponse.AuthenticationErrorMessage = "User does not exist!";
            }

            return authenticationResponse;
        }

        private async Task<User?> GetUserAsync(AuthenticationRequestDto authenticationRequestDto)
        {
            if (string.Equals(authenticationRequestDto.Email, "test@test.com"))
            {
                return await Task.FromResult(new User
                {
                    Id = 123,
                    Email = authenticationRequestDto.Email
                });
            }

            return null;
        }
    }
}
