using System.Collections.Generic;

namespace ReportService.Domain.Models
{
    /// <summary>
    /// Информация по подразделению.
    /// </summary>
    public class DepartmentDto
    {
        /// <summary>
        /// Id подразделения.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}