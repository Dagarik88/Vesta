using System.Linq;
using NUnit.Framework;
using ReportService.Infrastructure.Models.Mappings;
using ReportService.Tests.MockData;

namespace ReportService.Tests.Infrastructure.Mapping
{
    public class EmployeeToDtoMappingTest
    {
        [Test(Description = "Тест маппинга сущностей сотрудник из БД в Dto.")]
        public void ConvertEmployeeTest()
        {
            // Подготовка
            var act = EmployeeMock.Employees.FirstOrDefault();

            // Действие
            var result = act.ConvertToDto();
            
            // Проверка
            Assert.Multiple(() => 
            {
                Assert.AreEqual(act.Inn, result.Inn, "ИНН сотрудников не равны.");
                Assert.AreEqual(act.Name, result.Name, "ФИО сотрудников не равны.");
            });
        }
    }
}