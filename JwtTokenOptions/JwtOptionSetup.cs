using AuthorizationWithJWT.JWTTokenOptions;
using Microsoft.Extensions.Options;

namespace AuthorizationWithJWT.JwtTokenOptions
{
    public class JwtOptionSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;
        private const string SectionName = "jwt";
        public JwtOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
