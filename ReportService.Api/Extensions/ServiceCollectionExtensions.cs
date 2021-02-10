using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ReportService.Application.UseCase;

namespace ReportService.Api.Extensions
{
    /// <summary>
    /// Расширения для регистрации служб.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Методы публичные

        /// <summary>
        /// Регистрация служб уровня приложения.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <returns></returns>
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo());
            });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            return services;
        }

        #endregion

    }
}