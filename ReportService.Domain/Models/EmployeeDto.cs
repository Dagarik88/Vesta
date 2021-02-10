using System;

namespace ReportService.Domain.Models
{
    /// <summary>
    /// Информация по сотруднику.
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Инн сотрудника.
        /// </summary>
        public string Inn { get; set; }
        
        /// <summary>
        /// Размер зарабатной платы.
        /// </summary>
        public Decimal Salary { get; set; }
    }
}