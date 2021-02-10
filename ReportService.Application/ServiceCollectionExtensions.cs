using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.UseCase;
using ReportService.Domain.Services;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Application
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
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddUseCases();

            return services;
        }

        #endregion

        #region Методы приватные

        /// <summary>
        /// Регистрация useCase.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<SalaryReportUseCase>();
        }

        #endregion
    }
}