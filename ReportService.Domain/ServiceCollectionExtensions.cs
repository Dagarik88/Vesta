using Microsoft.Extensions.DependencyInjection;
using ReportService.Domain.Services;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Domain
{
    /// <summary>
    /// Расширения для регистрации служб.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Методы публичные

        /// <summary>
        /// Регистрация доменных служб.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <returns></returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.RegisterStorages();
            services.AddServices();

            return services;
        }

        #endregion

        #region Методы приватные

        /// <summary>
        /// Регистрация хранилищ.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        private static void RegisterStorages(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentStorage, DepartmentStorage>();
        }
        /// <summary>
        /// Регистрация сервисов.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IReportBuilder, ReportBuilder>();
        }

        #endregion
    }
}