using System;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Clients.Interface
{
    /// <summary>
    /// Интерфейс сервиса заработной платы.
    /// </summary>
    public interface ISalaryService
    {
        /// <summary>
        /// Возвращает размер заработной платы по бухгалтерскому коду сотрудника.
        /// </summary>
        /// <param name="code">Бухгалтерский код сотрудника.</param>
        /// <returns>Размер заработной платы.</returns>
        Task<Decimal> GetSalaryAsync(string code);
    }
}