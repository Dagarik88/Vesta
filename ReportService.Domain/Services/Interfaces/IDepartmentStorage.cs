using System.Collections.Generic;
using System.Threading.Tasks;
using ReportService.Domain.Models;

namespace ReportService.Domain.Services.Interfaces
{
    /// <summary>
    /// Хранилище подразделений. 
    /// </summary>
    public interface IDepartmentStorage
    {

        /// <summary>
        /// Возвращает список подразделений с зарплатной веткой сотрудиков.
        /// </summary>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <returns></returns>
        Task<IEnumerable<DepartmentDto>> GetDepartmentSalaryReportAsync(int month, int year);
    }
}