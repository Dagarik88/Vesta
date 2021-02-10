using System;
using System.IO;
using System.Threading.Tasks;

namespace ReportService.Tests.Helper
{
    /// <summary>
    /// Хелпер для доступа к файлам.
    /// </summary>
    public static class FileHelpers
    {
        /// <summary>
        /// Возвращает содержимое файла.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <param name="fileName">Наименование.</param>
        /// <returns></returns>
        public static Task<string> GetFileAsync(string path, string fileName)
        {
            var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/{path}/{fileName}";
            return File.ReadAllTextAsync(filePath);
        }
    }
}