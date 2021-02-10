using System;
using System.Collections.Generic;
using NUnit.Framework;
using ReportService.Domain.Helper;

namespace ReportService.Tests.Domain.Helper
{
    public class MonthNameResolverTests
    {
        #region Тесты

        [Test(Description = "Провека верный маппинг наименование месяца.")]
        [TestCaseSource(nameof(TestCasesMonth))]
        public void MonthNameResolved(int month, string monthName)
        {
            var result = MonthNameResolver.GetMonthName(month);

            Assert.AreEqual(monthName, result, "Имена месецев не совпадает.");
        }


        [Test(Description = "Провека на ожидаемую ошибку.")]
        public void MonthNameException()
        {
            Assert.Throws<ArgumentException>(() =>
                MonthNameResolver.GetMonthName(13));
        }

        #endregion

        #region Методы приватные

        private static IEnumerable<TestCaseData> TestCasesMonth()
        {
            yield return new TestCaseData(1, "Январь");
            yield return new TestCaseData(2, "Февраль");
            yield return new TestCaseData(3, "Март");
            yield return new TestCaseData(4, "Апрель");
            yield return new TestCaseData(5, "Май");
            yield return new TestCaseData(6, "Июнь");
            yield return new TestCaseData(7, "Июль");
            yield return new TestCaseData(8, "Август");
            yield return new TestCaseData(9, "Сентябрь");
            yield return new TestCaseData(10, "Октябрь");
            yield return new TestCaseData(11, "Ноябрь");
            yield return new TestCaseData(12, "Декабрь");
        }

        #endregion
    }
}