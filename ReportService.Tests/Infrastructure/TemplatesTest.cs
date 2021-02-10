using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using ReportService.Tests.Helper;

namespace ReportService.Tests.Infrastructure
{
    public class TemplatesTest
    {
        [Test(Description = "Поверяем что шаблон не изменился.")]
        [TestCaseSource(nameof(TestCasesFiles))]
        public async Task TemplateNotChanget(string path, string fileName)
        {
            // Подготовка
            var act = await FileHelpers.GetFileAsync("TemplateStandard", fileName);
            
            // Действие
            var result = await FileHelpers.GetFileAsync(path, fileName);

            // Проверка
            Assert.AreEqual(act, result, "Шаблоны не равны.");
        }

        private static IEnumerable<TestCaseData> TestCasesFiles()
        {
            yield return new TestCaseData("Templates", "SalaryReport.txt");
        }
    }
}