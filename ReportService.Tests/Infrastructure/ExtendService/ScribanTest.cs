using System.Threading.Tasks;
using NUnit.Framework;
using ReportService.Domain.Models;
using ReportService.Infrastructure.Services;
using ReportService.Tests.Helper;

namespace ReportService.Tests.Infrastructure.ExtendService
{
    public class ScribanTest
    {
        #region Поля

        private ScribanEngine _scribanEngine;

        private ReportDto _report;

        #endregion

        #region Конструкторы

        public ScribanTest()
        {
            _scribanEngine = new ScribanEngine();

            _report = new ReportDto
            {
                Name = "Тестовый отчёт",
                Departments = new[]
                {
                    new DepartmentDto
                    {
                        Name = "Тестовое подразделение",
                        Employees = new[]
                        {
                            new EmployeeDto
                            {
                                Name = "Тестов Тест Тестович",
                                Inn = "23213",
                                Salary = 1000
                            }
                        }
                    }
                }
            };
        }

        #endregion

        #region Тесты

        [Test(Description = "Тест для проверки черного ящика.")]
        public async Task RenderTestOnSalaryReport()
        {
            var act = await FileHelpers.GetFileAsync("TemplateStandard", "SalaryReportResult.txt");

            var result = await _scribanEngine.RenderAsync("SalaryReport.txt", _report);

            Assert.AreEqual(act, result, "Результат редеринга шаблонов не идентичен.");
        }

        #endregion
    }
}