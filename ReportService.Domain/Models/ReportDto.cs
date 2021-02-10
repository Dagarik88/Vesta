using System.Collections;
using System.Collections.Generic;

namespace ReportService.Domain.Models
{
    /// <summary>
    /// Информация по отчёту.
    /// </summary>
    public class ReportDto
    {
        /// <summary>
        /// Наименование отчета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список подразделений.
        /// </summary>
        public IEnumerable<DepartmentDto> Departments { get; set; }

        /// <summary>
        /// Общая зароботная плата по организации.
        /// </summary>
        public decimal TotalSalary { get; set; }
    }
}