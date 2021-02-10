using System;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Domain.Repository;
using ReportService.Domain.Services;
using ReportService.Domain.Services.Interfaces;
using ReportService.Infrastructure.Clients;
using ReportService.Infrastructure.Clients.Interface;
using ReportService.Infrastructure.Configurations;
using ReportService.Infrastructure.Helpers;
using ReportService.Infrastructure.Repository;
using ReportService.Infrastructure.Services;

namespace ReportService.Infrastructure
{
    /// <summary>
    /// Расширения для регистрации служб.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Методы публичные

        /// <summary>
        /// Регистрация инфраструктурных служб.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <param name="setUp">Конфигурация сервисов.</param>
        /// <returns></returns>
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> setUp)
        {
            var options = new InfrastructureOptions();
            setUp(options);
            
            services.AddOptions<InfrastructureOptions>()
                .Configure(x => setUp(x))
                .Validate<IValidator<InfrastructureOptions>>((x, validator) => validator.Validate(x).IsValid);
            
            services.RegisterValidators(Assembly.GetExecutingAssembly());

            services.AddRepositories(options.DbConnection);

            services.RegisterServices();

            services.AddHttpClients(options);
        }

        #endregion

        #region Методы приватные

        /// <summary>
        /// Регистрация HTTP-клиентов.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <param name="options">Конфигурация приложения.</param>
        private static void AddHttpClients(this IServiceCollection services, InfrastructureOptions options)
        {
            services.AddHttpClient<ISalaryService, SalaryClient>(httpClient =>
                httpClient.BaseAddress = new Uri(options.SalaryServiceUrl));

            services.AddHttpClient<IAccountingService, AccountingClient>(httpClient =>
                httpClient.BaseAddress = new Uri(options.AccountingServiceUrl));
        }


        /// <summary>
        /// Регистрация репозиториев.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <param name="connection">Строка подключения к БД.</param>
        private static void AddRepositories(this IServiceCollection services, string connection)
        {
            services.AddTransient<IDepartmentRepository, DepartmentRepository>(provider =>
                new DepartmentRepository(connection));

            services.AddTransient<IEmployeeRepository, EmployeeRepository>(provider =>
                new EmployeeRepository(connection));

            services.AddScoped<ISalaryRepository, SalaryRepository>();
        }

        /// <summary>
        /// Регистрация вадаторов.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        /// <param name="validatorsAssembly">Наименование сборки.</param>
        private static void RegisterValidators(this IServiceCollection services, Assembly validatorsAssembly)
        {
            services.AddValidatorsFromAssembly(validatorsAssembly);
        }

        /// <summary>
        /// Регистрация сервисов.
        /// </summary>
        /// <param name="services">Провайдер служб.</param>
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITemplateEngine, ScribanEngine>();
        }

        #endregion
    }
}