
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Support.Configuration.Swagger
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureSwaggerDocument(this IServiceCollection services)
        {
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = Configuration.SwaggerConfiguration.Title;
                configure.Version = Configuration.SwaggerConfiguration.Version1;
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."

                });

            });

            return services;
        }
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}
