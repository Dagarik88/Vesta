using System;

namespace ReportService.Domain.Helper
{
    /// <summary>
    /// Резолвер наименования месецев.
    /// </summary>
    public static class MonthNameReoslver
    {
        /// <summary>
        /// Возвращает наименование месяца по порядковому номеру.
        /// </summary>
        /// <param name="month">Номер месяца.</param>
        /// <returns>Наименование месяца.</returns>
        /// <exception cref="NotImplementedException">Выбрасывает исключение в случае запроса несуществующего месяца.</exception>
        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
                default:
                    throw new ArgumentException("Такого месяца не существует.");
            }
        }
    }
}