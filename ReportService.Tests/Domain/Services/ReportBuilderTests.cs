using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ReportService.Domain.Services;
using ReportService.Domain.Services.Interfaces;
using ReportService.Tests.MockData;
using ReportService.Tests.Stubs;

namespace ReportService.Tests.Domain.Services
{
    public class ReportBuilderTests
    {
        #region Поля

        private IReportBuilder _reportBuilder;

        #endregion

        #region Коснтуркторы

        public ReportBuilderTests()
        {
            var departmentStorage = new Mock<IDepartmentStorage>();
            departmentStorage
                .Setup(x => x.GetDepartmentSalaryReportAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() => DepartmentDtoMock.Departments);

            _reportBuilder = new ReportBuilder(departmentStorage.Object, new ScribanStub());
        }

        #endregion

        #region Тесты

        [Test(Description = "Тест на получение зарплатного отчёта.")]
        public async Task GetSalayReport()
        {
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrowAsync(async () =>
                        await _reportBuilder.GetSalaryReportAsync(1, 2019, string.Empty),
                    "При попытке формировании отчёта возникла непредвиденная ошибка.");
            });
        }

        [Test(Description = "Тест на получение ошибки при попытке формирование зарплатного отчёта.")]
        public async Task GetSalayReportWithException()
        {
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(
                    async () => await _reportBuilder.GetSalaryReportAsync(21, 2019, string.Empty),
                    "Ожидалось получить ArgumentException");
            });
        }

        #endregion
    }
}