using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.UseCase;
using ReportService.Domain.Models;

namespace ReportService.Api.Controllers
{
    /// <summary>
    /// Контроллер для получения отчётов.
    /// </summary>
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        #region Поля

        /// <summary>
        /// Юскейс для построения отчётов.
        /// </summary>
        private readonly SalaryReportUseCase _salaryReportUseCase;

        #endregion

        #region Конструткоры

        /// <summary>
        /// Контроллер для получения отчётов.
        /// </summary>
        /// <param name="salaryReportUseCase">Юскейс для построения отчётов.</param>
        public ReportController(SalaryReportUseCase salaryReportUseCase)
        {
            _salaryReportUseCase = salaryReportUseCase;
        }

        #endregion

        /// <summary>
        /// Возвращает txt отчёт  по заработным платам за определенный период времени в разрезе подразделений компании.
        /// </summary>
        /// <param name="year">Год.</param>
        /// <param name="month">Месяц.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{year}/{month}")]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Download(int year, int month)
        {
            try
            {
                var result = await _salaryReportUseCase.GetSalaryReportAsync(month, year, ReportType.TXT);

                return File(result, "application/octet-stream", "report.txt");
            }
            catch (Exception e)
            {
                return BadRequest("Не получилось сформировать отчёт.");
            }
        }
    }
}