using System.Threading.Tasks;

namespace ReportService.Infrastructure.Clients.Interface
{
    /// <summary>
    /// Интерфейс сервиса бухгалтерии.
    /// </summary>
    public interface IAccountingService
    {
        /// <summary>
        /// Возвращает код сотрудника по ИНН.
        /// </summary>
        /// <param name="inn">ИНН сотрудника.</param>
        /// <returns>Код сотрудника.</returns>
        Task<string> GetCodeAsync(string inn);
    }
}