using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ReportService.Infrastructure.Clients.Interface;

namespace ReportService.Infrastructure.Clients
{
    /// <summary>
    /// Http-клиент к сервису бухгалтерии.
    /// </summary>
    public class AccountingClient : IAccountingService
    {
        #region Поля

        /// <summary>
        /// HTTP-клиент.
        /// </summary>
        private readonly HttpClient _httpClient;

        #endregion

        #region Консктрукторы

        /// <summary>
        ///  Http-клиент к сервису зарплаты.
        /// </summary>
        /// <param name="httpClient">HTTP-клиент.</param>
        public AccountingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает код сотрудника по ИНН.
        /// </summary>
        /// <param name="inn">Код сотрудника.</param>
        /// <returns>Код сотрудника.</returns>
        public async Task<string> GetCodeAsync(string inn)
        {
            var result = string.Empty;

            var response = await _httpClient.GetAsync($"/api/inn/{inn}");

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        #endregion
    }
}