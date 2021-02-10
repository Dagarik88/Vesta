using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ReportService.Domain.Repository;
using ReportService.Infrastructure.Clients.Interface;
using ReportService.Infrastructure.Repository;

namespace ReportService.Tests.Infrastructure.Repository
{
    public class SalaryRepositoryTests
    {
        #region Поля

        private readonly ISalaryRepository _salaryRepository;

        #endregion

        #region Конструтокры

        public SalaryRepositoryTests()
        {
            var accountingService = new Mock<IAccountingService>();
            accountingService.Setup(x => x.GetCodeAsync(It.IsAny<string>())).ReturnsAsync((string inn) =>
            {
                switch (inn)
                {
                    case "968898022491":
                        return "001";
                    case "965984026092":
                        return "002";
                    case "966406163183":
                        return "003";
                    default:
                        return string.Empty;
                }
            });

            var salaryService = new Mock<ISalaryService>();
            salaryService.Setup(x => x.GetSalaryAsync(It.IsAny<string>())).ReturnsAsync((string code) =>
            {
                switch (code)
                {
                    case "001":
                        return 10000;
                    case "002":
                        return 20000;
                    case "003":
                        return 30000;
                    default:
                        return 0;
                }
            });
            
            _salaryRepository = new SalaryRepository(salaryService.Object, accountingService.Object);
        }

        #endregion

        #region Тесты

        [Test(Description = "Тест на получение данных о заработной плате")]
        [TestCaseSource(nameof(TestCasesSalary))]
        public async Task GetSalaryTest(string inn, decimal salary)
        {
            // Действие
            var result = await _salaryRepository.GetSalaryByInnAsync(inn);

            // Проверка
            Assert.AreEqual(salary, result, "Зарплата не верна");
        }

        #endregion

        #region Методы приватные

        
        private static IEnumerable<TestCaseData> TestCasesSalary()
        {
            yield return new TestCaseData("968898022491", (decimal)10000);
            yield return new TestCaseData("965984026092", (decimal)20000);
            yield return new TestCaseData("966406163183", (decimal)30000);
            yield return new TestCaseData("966401877642", (decimal)0);
        }


        #endregion
    }
}