using System;
using System.Collections.Generic;
using System.Linq;
using ReportService.Domain.Models;
using ReportService.Infrastructure.Models.Mappings;
using ReportService.Tests.Helper;

namespace ReportService.Tests.MockData
{
    public static class DepartmentDtoMock
    {
        public static IEnumerable<DepartmentDto> Departments
        {
            get
            {
                var departments = DepartmentMock.Departments.ConvertToDto();

                var rnd = new Random(0);

                foreach (var department in departments)
                {
                    var emp = EmployeeMock.Employees.ConvertToDto();
                    department.Employees = emp.Select(x =>
                    {
                        x.Salary = rnd.NextDecimal();
                        return x;
                    }).ToList();
                }

                return departments;
            }
        }
    }
}