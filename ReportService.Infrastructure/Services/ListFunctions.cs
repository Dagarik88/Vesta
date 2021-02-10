using System.Collections;

namespace ReportService.Infrastructure.Services
{
    /// <summary>
    /// Функции для работы с коллекциями в шаблонизаторе.
    /// </summary>
    public static class ListFunctions
    {
        /// <summary>
        /// Получение элемента по индексу.
        /// </summary>
        /// <param name="list">Список.</param>
        /// <param name="index">Индекс.</param>
        public static object GetByIndex(IEnumerable list, int index)
        {
            if (list == null || index < 0)
            {
                return null;
            }

            if (list is IList readList && index <= readList.Count - 1)
            {
                return readList[index];
            }

            return null;
        }
    }
}