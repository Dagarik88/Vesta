using System.Threading.Tasks;

namespace ReportService.Domain.Repository
{
    /// <summary>
    /// Интерфейс репозитория зароботных плат.
    /// </summary>
    public interface ISalaryRepository
    {
        /// <summary>
        /// Возвращает размер заработной платы по ИНН.
        /// </summary>
        /// <param name="inn">ИНН.</param>
        /// <returns>Размер зароботной платы.</returns>
        Task<decimal> GetSalaryByInnAsync(string inn);
    }
}