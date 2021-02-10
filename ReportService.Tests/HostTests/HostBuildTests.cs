using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ReportService.Tests.HostTests
{
    /// <summary>
    /// Тест на корректный билд приложения.
    /// Так же валидирует DI контейнер, на наличие незарегистрированных сервисов.
    /// Встроенный валидатор на текущий момент, не может провалидировать:
    /// 1. Зависимости в конструкторах контроллеров, если они явно не зареганы в DI,
    /// по умолчанию они создаются с помощью <see cref="ActivatorUtilities"/>.
    /// 2. Зависимости из [FromServices]
    /// 3. Сервисы, которые достаются явно из <see cref="IServiceProvider"/>.
    /// 4. Сервисы, которые зарегистрированы через функцию фабрики. Например services.AddScoped(() => new Test());
    /// 5. Не могут быть провалидированы Open Generics.
    /// </summary>
    public class HostBuildTests
    {
        #region Тесты

        /// <summary>
        /// Приложение билдится без ошибок.
        /// </summary>
        /// <param name="testCaseName">Наименование тест-кейса.</param>
        /// <param name="hostBuilder">Билдер.</param>
        [TestCaseSource(nameof(TestCases))]
        public void HostBuildsWithoutErrors(string testCaseName, IHostBuilder hostBuilder)
        {
            Assert.DoesNotThrow(() => hostBuilder.Build(), testCaseName);
        }

        [TestCaseSource(nameof(TestCasesForUseCases))]
        public void FacadesResolved(string typeName, Type type)
        {
            Assert.Multiple(() =>
            {
                foreach (var appCase in TestCases())
                {
                    var app = appCase.Arguments[0].As<string>();


                    var builder = appCase.Arguments[1].As<IHostBuilder>();

                    var host = builder.Build();
                    Assert.DoesNotThrow(() => host.Services.GetRequiredService(type), $"Тип {typeName} не зарегистрирован для {app}");
                }
            });
        }

        #endregion Тесты

        #region Методы (private)

        private static IEnumerable<TestCaseData> TestCasesForUseCases()
        {
            return TestCasesForTypes("UseCase");
        }

        /// <summary>
        /// Тест кейсы для сервисов не реализующих интерфейсы.
        /// </summary>
        private static IEnumerable<TestCaseData> TestCasesForTypes(string serviceGroupPostfix)
        {
            var useCaseTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(x => x.Name.EndsWith(serviceGroupPostfix));

            return useCaseTypes.Select(x => new TestCaseData(x.Name, x));
        }

        /// <summary>
        /// Тест кейсы для <see cref="HostBuildsWithoutErrors"/>.
        /// </summary>
        private static IEnumerable<TestCaseData> TestCases()
        {
            var args = Array.Empty<string>();

            yield return new TestCaseData(
                typeof(Api.Program).Assembly.GetName().Name,
                Api.Program.CreateWebHostBuilder(args)
            );
        }

        #endregion Методы (private)
    }

}