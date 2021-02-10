using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReportService.Api.Extensions;
using ReportService.Application;
using ReportService.Domain;
using ReportService.Infrastructure;

namespace ReportService.Api
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public class Startup
    {
        #region Поля

        /// <summary>
        /// Интерфейс для получения данных окружения.
        /// </summary>
        private readonly IHostEnvironment _env;

        /// <summary>
        /// Конфигурация микросервиса.
        /// </summary>
        private readonly IConfiguration _configuration;

        #endregion Поля

        #region Конструктор

        /// <summary>
        /// Основной класс микросервиса.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
        /// <param name="env">Данные окружения.</param>
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Конфигурация сервисов приложения.
        /// </summary>
        /// <param name="services">Конфигуратор сервисов.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPresentation()
                .AddApplication()
                .AddDomain()
                .AddInfrastructure(options =>
                {
                    options.DbConnection = _configuration.GetConnectionString("Database");
                    options.AccountingServiceUrl = _configuration.GetValue<string>("AccountingServiceUrl");
                    options.SalaryServiceUrl = _configuration.GetValue<string>("SalaryServiceUrl");
                });
        }

        /// <summary>
        /// Конфигурация приложения.
        /// </summary>
        /// <param name="app">Конфигуратор приложения.</param>
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureSwagger();
            
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        #endregion Методы
    }
}