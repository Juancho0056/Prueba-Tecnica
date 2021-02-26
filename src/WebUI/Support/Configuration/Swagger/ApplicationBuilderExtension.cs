using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Support.Configuration.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUi3(settings =>
            {

                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            return app;
        }

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
