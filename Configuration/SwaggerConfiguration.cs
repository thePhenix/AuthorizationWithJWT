using Microsoft.OpenApi.Models;

namespace AuthorizationWithJWT.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services, string title, string version)
        {
            // Swagger API documentation
            services.AddSwaggerGen(c =>
            {
                c.SchemaGeneratorOptions = new Swashbuckle.AspNetCore.SwaggerGen.SchemaGeneratorOptions { SchemaIdSelector = type => type.FullName };
                c.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id="Bearer"}
                        },
                        new string[] {}
                    }
                });
            });
        }

        public static IApplicationBuilder UserSwaggerForApplication(this IApplicationBuilder app, string name)
        {
            // Swagger API documentation
            return app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", name);
                });
        }
    }
}
