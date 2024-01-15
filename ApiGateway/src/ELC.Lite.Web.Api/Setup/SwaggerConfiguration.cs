using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ELC.Lite.Web.Api.Setup
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SecuredAPI Gateway API",
                        Version = "v1",
                        Description = "Entry points for the SecuredAPI Gateway API"
                    });

                c.AddLocalIdentity();

                c.EnableAnnotations();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ELC.Lite.Web.API");
                //c.RoutePrefix = "api/documentation";
                c.RoutePrefix = string.Empty;

                //if (GatewayCustomerSettings.Instance.Auth == IdentityType.B2C)
                //{
                //    c.OAuthClientId(AuthB2CSettings.Instance.SwaggerOAuthClientId);
                //    c.OAuthAppName(AuthB2CSettings.Instance.SwaggerOAuthAppName);
                //    c.OAuthClientSecret(AuthB2CSettings.Instance.SwaggerOAuthClientSecret);
                //}
            });
        }

        public static void AddLocalIdentity(this SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "JSON Web Token to access resources. Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new [] { string.Empty }
                }
            });
        }
    }
}
