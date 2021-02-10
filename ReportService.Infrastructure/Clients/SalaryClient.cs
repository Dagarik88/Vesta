using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ReportService.Domain.Exceptions;
using ReportService.Infrastructure.Clients.Interface;

namespace ReportService.Infrastructure.Clients
{
    /// <summary>
    /// Http-клиент к сервису зарплаты.
    /// </summary>
    public class SalaryClient : ISalaryService
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
        public SalaryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает размер заработной платы по бухгалтерскому коду сотрудника.
        /// </summary>
        /// <param name="code">Бухгалтерский код сотрудника.</param>
        /// <returns>Размер заработной платы.</returns>
        public async Task<Decimal> GetSalaryAsync(string code)
        {
            decimal result = 0;

            try
            {
                var response = await _httpClient.PostAsync($"/api/empcode/{code}", null);

                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var str = await response.Content.ReadAsStringAsync();

                    Decimal.TryParse(str, out result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new SalaryException($"Не удалось зарплату сотрудника по бухгалтерскому коду {code}", ex);
            }

            return result;
        }

        #endregion
    }
}