namespace ReportService.Infrastructure.Models
{
    /// <summary>
    /// Информация о сотруднике.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ФИО сотрудника.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ИНН.
        /// </summary>
        public string Inn { get; set; }
    }
}