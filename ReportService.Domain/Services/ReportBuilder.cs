using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportService.Domain.Helper;
using ReportService.Domain.Models;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Domain.Services
{
    /// <summary>
    /// Сервис построения отчётов.
    /// </summary>
    public class ReportBuilder : IReportBuilder
    {
        #region Поля

        /// <summary>
        /// Хранилище подразделений.
        /// </summary>
        private readonly IDepartmentStorage _departmentStorage;

        /// <summary>
        /// Движок шаблонизатора отчётов.
        /// </summary>
        private readonly ITemplateEngine _templateEngine;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Сервис построения отчётов.
        /// </summary>
        /// <param name="departmentStorage">Хранилище подразделений.</param>
        /// <param name="templateEngine">Движок шаблонизатора отчётов.</param>
        public ReportBuilder(
            IDepartmentStorage departmentStorage,
            ITemplateEngine templateEngine)
        {
            _departmentStorage = departmentStorage;
            _templateEngine = templateEngine;
        }

        #endregion


        #region Методы

        /// <summary>
        /// Возвращает отчёт в виде строки.
        /// </summary>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <param name="templateName">Имя шаблона.</param>
        /// <returns>Отчёт по заработной плате.</returns>
        public async Task<string> GetSalaryReportAsync(int month, int year, string templateName)
        {
            var department = await _departmentStorage.GetDepartmentSalaryReportAsync(month, year);

            var report = new ReportDto
            {
                Name = $"{MonthNameResolver.GetMonthName(month) } {year}",
                Departments = department ?? new List<DepartmentDto>(),
                TotalSalary = department?.SelectMany(x => x.Employees.Select(e => e.Salary)).Sum() ?? 0
            };

            return await _templateEngine.RenderAsync(templateName, report);
        }

        #endregion
    }
}