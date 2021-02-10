using System;
using System.Text;
using System.Threading.Tasks;
using ReportService.Domain.Models;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Application.UseCase
{
    /// <summary>
    /// Использование - получение отчёта по заработным платам за определенный период времени
    /// в разрезе подразделений компании.
    /// </summary>
    public class SalaryReportUseCase
    {
        #region Константы

        /// <summary>
        /// Наименование шаблона отчёта.
        /// </summary>
        private const string TEMPLATE_NAME = "SalaryReport.txt";

        #endregion
        
        #region Поля

        /// <summary>
        /// Сервис построения отчётов.
        /// </summary>
        private IReportBuilder _reportBuilder;

        #endregion


        #region Конструкторы

        /// <summary>
        /// Создает новый экземпляр <see cref="SalaryReportUseCase"/>
        /// </summary>
        /// <param name="reportBuilder">Сервис построения отчётов.</param>
        public SalaryReportUseCase(IReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает отчёт по ЗП в массиве байтов.
        /// </summary>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <param name="reportType">Тип отчёта.</param>
        /// <returns>Тело отчёта в массиве байтов.</returns>
        public async Task<byte[]> GetSalaryReportAsync(int month, int year, ReportType reportType)
        {
            if (reportType == ReportType.TXT)
            {
                var report = await _reportBuilder.GetSalaryReportAsync(month, year, TEMPLATE_NAME);

                return Encoding.UTF8.GetBytes(report);    
            }

            throw new NotImplementedException("Отчёт в запрашиваемом формате не реализован.");

        }

        #endregion
    }
}