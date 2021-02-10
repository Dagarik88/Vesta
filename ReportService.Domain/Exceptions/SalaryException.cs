using System;

namespace ReportService.Domain.Exceptions
{
    /// <summary>
    /// Исключение, вызыванное ошибкой при получении зарплатных данных.
    /// </summary>
    public class SalaryException : Exception
    {
        /// <summary>
        /// Создает новый экземпляр исключения <see cref="SalaryException"/>.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public SalaryException(
            string errorMessage,
            Exception innerException
        ) : base(errorMessage, innerException)
        {
        }
    }
}