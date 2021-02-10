using System.Collections.Generic;

namespace ReportService.Infrastructure.Models
{
    /// <summary>
    /// Информация по подразделению.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id подразделения.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование подразделения.
        /// </summary>
        public string Name { get; set; }
    }
}