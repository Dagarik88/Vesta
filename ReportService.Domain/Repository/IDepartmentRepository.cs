using System.Collections.Generic;
using System.Threading.Tasks;
using ReportService.Domain.Models;

namespace ReportService.Domain.Repository
{
    /// <summary>
    /// Интерфейс репозиторий подразделений.
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Возвращает список подразделений.
        /// </summary>
        /// <returns>Список подразделений.</returns>
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
    }
}