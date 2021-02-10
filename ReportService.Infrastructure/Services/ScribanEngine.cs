using System;
using System.IO;
using System.Threading.Tasks;
using ReportService.Domain.Services.Interfaces;
using Scriban;
using Scriban.Runtime;

namespace ReportService.Infrastructure.Services
{
    /// <summary>
    /// Шаблонизатор для Scriban <see href="https://github.com/lunet-io/scriban"/>
    /// </summary>
    public class ScribanEngine : ITemplateEngine
    {
        /// <summary>
        /// Рендер шаблона.
        /// </summary>
        /// <param name="templateName">Имя шаблона визуализации.</param>
        /// <param name="objectToVisualize">Объект, используемый для визуализации.</param>
        public ValueTask<string> RenderAsync(string templateName, object objectToVisualize)
        {
            var context = new TemplateContext {LoopLimit = int.MaxValue, EnableRelaxedMemberAccess = true};

            var template = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/Templates/{templateName}");
            
            try
            {
                var parsedTemplate = Template.Parse(template);
                var scriptObject = new ScriptObject();
                scriptObject.Import(objectToVisualize);
                scriptObject.Import(typeof(ListFunctions));
                context.PushGlobal(scriptObject);
                return parsedTemplate.RenderAsync(context);
            }
            finally
            {
                context.PopGlobal();
            }
        }
    }
}