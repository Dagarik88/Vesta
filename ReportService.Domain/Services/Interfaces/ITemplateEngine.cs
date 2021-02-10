using System.Threading.Tasks;

namespace ReportService.Domain.Services.Interfaces
{
    /// <summary>
    /// Интерфейс движка шаблонизатора.
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Рендер шаблона.
        /// </summary>
        /// <param name="templateName">Имя шаблона визуализации.</param>
        /// <param name="objectToVisualize">Объект, используемый для визуализации.</param>
        ValueTask<string> RenderAsync(string templateName, object objectToVisualize);
    }
}