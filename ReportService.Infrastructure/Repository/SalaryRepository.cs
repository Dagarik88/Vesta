using System.Threading.Tasks;
using ReportService.Domain.Repository;
using ReportService.Infrastructure.Clients.Interface;

namespace ReportService.Infrastructure.Repository
{
    /// <summary>
    /// Репозиторий зароботной платы.
    /// </summary>
    public class SalaryRepository : ISalaryRepository
    {
        #region Поля

        /// <summary>
        /// Сервис бухгалтерии.
        /// </summary>
        private readonly IAccountingService _accountingService;

        /// <summary>
        /// Сервис зароботной платы.
        /// </summary>
        private readonly ISalaryService _salaryService;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Репозиторий зароботной платы.
        /// </summary>
        /// <param name="salaryService">Сервис зароботной платы.</param>
        /// <param name="accountingService">Сервис бухгалтерии.</param>
        public SalaryRepository(
            ISalaryService salaryService,
            IAccountingService accountingService)
        {
            _salaryService = salaryService;
            _accountingService = accountingService;
        }

        #endregion

        #region Методы

        #endregion

        /// <summary>
        /// Возвращает размер заработной платы по ИНН.
        /// </summary>
        /// <param name="inn">ИНН.</param>
        /// <returns>Размер зароботной платы.</returns>
        public async Task<decimal> GetSalaryByInnAsync(string inn)
        {
            var accountingCode = await _accountingService.GetCodeAsync(inn);

            if (string.IsNullOrEmpty(accountingCode))
            {
                return 0;
            }

            return await _salaryService.GetSalaryAsync(accountingCode);
        }
    }
}