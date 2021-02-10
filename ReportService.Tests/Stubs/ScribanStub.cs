using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService.Domain.Models;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Tests.Stubs
{
    /// <summary>
    /// Имитирует работу скрибан.
    /// </summary>
    public class ScribanStub : ITemplateEngine
    {
        /// <summary>
        /// Рендер шаблона.
        /// </summary>
        /// <param name="templateName">Имя шаблона визуализации.</param>
        /// <param name="objectToVisualize">Объект, используемый для визуализации.</param>
        public ValueTask<string> RenderAsync(string templateName, object objectToVisualize)
        {
            var report = objectToVisualize as ReportDto;
            if (report == null)
            {
                throw new NotImplementedException("Для данного типа не реализован шаблонизатор.");
            }

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(report.Name);
            
            foreach (var department in report.Departments)
            {
                strBuilder.AppendLine("--------------------------------------------");
                strBuilder.AppendLine(department.Name);

                foreach (var employee in department.Employees)
                {
                    strBuilder.AppendLine($"{employee.Name}         {employee.Salary}р");
                }
            }
            
            strBuilder.AppendLine("--------------------------------------------");
            strBuilder.AppendLine($"Всего по предприятию{report.Departments.SelectMany(x => x.Employees.Select(e => e.Salary)).Sum()}р");

            return new ValueTask<string>(strBuilder.ToString());

        }
    }
}