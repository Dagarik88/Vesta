using System.Collections.Generic;
using System.Linq;
using ReportService.Domain.Models;

namespace ReportService.Infrastructure.Models.Mappings
{
    public static class EmployeeToEmployeeDto
    {
        public static EmployeeDto ConvertToDto(this Employee source)
        {
            if (source == null)
            {
                return default;
            }

            return new EmployeeDto
            {
                Inn = source.Inn,
                Name = source.Name
            };
        }
        public static IEnumerable<EmployeeDto> ConvertToDto(this IEnumerable<Employee> source)
        {
            return source?.Select(x=>x.ConvertToDto()).ToList();
        }
        
    }
}