namespace ReportService.Domain.Models
{
    /// <summary>
    /// Тип отчёта.
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// Неизвестный.
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        /// Текстовый формат.
        /// </summary>
        TXT = 1,
        
        /// <summary>
        /// XML.
        /// </summary>
        XML = 2
    }
}