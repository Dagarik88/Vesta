using System.Collections.Generic;
using System.Threading.Tasks;
using ReportService.Domain.Models;

namespace ReportService.Domain.Repository
{
    /// <summary>
    /// Интерфейс репозитория сотрудников.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Возвращает список сотрудников подразделения.
        /// </summary>
        /// <param name="departmentId">Id подразделения.</param>
        /// <returns>Список сотрудников.</returns>
        Task<IEnumerable<EmployeeDto>> GetEmployeeByDepartmentIdsAsync(int departmentId);
    }
}