using AuthorizationWithJWT.Interfaces;
using AuthorizationWithJWT.Services;

namespace AuthorizationWithJWT.Configuration
{
    public static class DependencyConfiguration
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            AddAuthenticationDependencies(services);
            services.AddSwagger("API", "v1");
        }

        private static void AddAuthenticationDependencies(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
