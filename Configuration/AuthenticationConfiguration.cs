using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthorizationWithJWT.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static void AddApplicationAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }

        public static void UseApplicationAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
