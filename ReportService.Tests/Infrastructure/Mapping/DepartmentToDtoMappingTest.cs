using System.Linq;
using NUnit.Framework;
using ReportService.Infrastructure.Models.Mappings;
using ReportService.Tests.MockData;

namespace ReportService.Tests.Infrastructure.Mapping
{
    public class DepartmentToDtoMappingTest
    {
        [Test(Description = "Тест маппинга сущностей подразделение из БД в Dto.")]
        public void ConvertEmployeeTest()
        {
            // Подготовка
            var act = DepartmentMock.Departments.FirstOrDefault();

            // Действие
            var result = act.ConvertToDto();
            
            // Проверка
            Assert.Multiple(() => 
            {
                Assert.AreEqual(act.Id, result.Id, "Id подразделений не равны.");
                Assert.AreEqual(act.Name, result.Name, "Наименование подразделений не равны.");
                Assert.IsEmpty(result.Employees, "Список сотрудников должен быть пустым.");
            });
        }
    }
}