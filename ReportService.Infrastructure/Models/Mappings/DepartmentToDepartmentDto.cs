using System;
using System.Collections.Generic;
using System.Linq;
using ReportService.Domain.Models;

namespace ReportService.Infrastructure.Models.Mappings
{
    public static class DepartmentToDepartmentDto
    {
        public static DepartmentDto ConvertToDto(this Department source)
        {
            if (source == null)
            {
                return default;
            }
            
            return new DepartmentDto
            {
                Id = source.Id,
                Name = source.Name,
                Employees = new List<EmployeeDto>()
            };
        }
        public static IEnumerable<DepartmentDto> ConvertToDto(this IEnumerable<Department> source)
        {
            
            return source?.Select(x=>x.ConvertToDto()).ToList();
        }
        
    }
}