using System.Threading.Tasks;

namespace ReportService.Domain.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса построения отчётов.
    /// </summary>
    public interface IReportBuilder
    {
        /// <summary>
        /// Возвращает отчёт в виде строки.
        /// </summary>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <param name="templateName">Имя шаблона.</param>
        /// <returns>Отчёт по заработной плате.</returns>
        Task<string> GetSalaryReportAsync(int month, int year, string templateName);
    }
}