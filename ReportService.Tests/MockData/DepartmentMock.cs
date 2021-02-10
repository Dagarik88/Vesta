using System.Collections.Generic;
using ReportService.Domain.Models;
using ReportService.Infrastructure.Models;

namespace ReportService.Tests.MockData
{
    public static class DepartmentMock
    {
        public static IEnumerable<Department> Departments => new List<Department>
        {
            new Department
            {
                Id = 1,
                Name = "Тестовый департамент 1"
            },
            new Department
            {
                Id = 2,
                Name = "Тестовый департамент 2"
            },
            new Department
            {
                Id = 3,
                Name = "Тестовый департамент 3"
            },
        };
    }
}