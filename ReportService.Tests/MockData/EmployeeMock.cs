using System.Collections.Generic;
using ReportService.Domain.Models;
using ReportService.Infrastructure.Models;

namespace ReportService.Tests.MockData
{
    public static class EmployeeMock
    {
        public static IEnumerable<Employee> Employees => new List<Employee>
        {
            new Employee
            {
                Inn = "966406163183",
                Name = "Николаев Валентин Тестович"
            },
            new Employee
            {
                Inn = "965984026092",
                Name = "Мясников Якун Тестович"
                
            },
            new Employee
            {
                Inn = "968898022491",
                Name = "Хохлов Владимир Тестович"
            },
        };
    }
}