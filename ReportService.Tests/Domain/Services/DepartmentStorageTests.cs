using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ReportService.Domain.Repository;
using ReportService.Domain.Services;
using ReportService.Domain.Services.Interfaces;
using ReportService.Infrastructure.Models.Mappings;
using ReportService.Tests.Helper;
using ReportService.Tests.MockData;

namespace ReportService.Tests.Domain.Services
{
    public class DepartmentStorageTests
    {
        private readonly IDepartmentStorage _departmentStorage;

        public DepartmentStorageTests()
        {
            var departmentRepository = new Mock<IDepartmentRepository>();
            departmentRepository
                .Setup(x => x.GetDepartmentsAsync())
                .ReturnsAsync(() => DepartmentMock.Departments.ConvertToDto());

            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository
                .Setup(x => x.GetEmployeeByDepartmentIdsAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => EmployeeMock.Employees.ConvertToDto());

            var salaryRepository = new Mock<ISalaryRepository>();
            salaryRepository
                .Setup(x => x.GetSalaryByInnAsync(It.IsAny<string>()))
                .ReturnsAsync((string inn) =>
                {
                    var rnd = new Random();
                    return rnd.NextDecimal();
                });

            _departmentStorage = new DepartmentStorage(salaryRepository.Object, employeeRepository.Object,
                departmentRepository.Object);
        }
        
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Тест на получение подразделений со списком сотрудников")]
        public async Task GetDepartmentWhithEmployeesTest()
        {
            // Подготовка
            var depDb = DepartmentMock.Departments;
            var empDb = EmployeeMock.Employees;
            
            // Действие
            var result = await _departmentStorage.GetDepartmentSalaryReportAsync(0, 0);
            
            // Проверка
            Assert.Multiple(() =>
            {
                foreach (var department in result)
                {
                    var actDep = depDb.FirstOrDefault(x => x.Id == department.Id);
                    Assert.AreEqual(actDep.Id, department.Id, "Идентификаторы подразделений не равны.");
                    Assert.AreEqual(actDep.Name, department.Name, "Наименование подразделений не равны.");
                    
                    foreach (var departmentEmployee in department.Employees)
                    {
                        var actEmp = empDb.FirstOrDefault(x => x.Inn == departmentEmployee.Inn);
                        
                        Assert.AreEqual(actEmp.Inn, departmentEmployee.Inn, "ИНН сотрудника не равны.");
                        Assert.AreEqual(actEmp.Name, departmentEmployee.Name, "ФИО сотрудника не равны.");
                    }
                }
            });
        }
    }
}