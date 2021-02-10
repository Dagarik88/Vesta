using Microsoft.AspNetCore.Builder;

namespace ReportService.Api.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IApplicationBuilder"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Конфигурация сваггера.
        /// </summary>
        /// <param name="app">Конфигурация конвейера запросов.</param>
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/ReportService/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/api/ReportService/swagger/v1/swagger.json", "Report Service API");
                a.RoutePrefix = "api/help";
            });
        }
    }

}