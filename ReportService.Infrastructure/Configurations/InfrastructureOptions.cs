using FluentValidation;

namespace ReportService.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public class InfrastructureOptions
    {
        /// <summary>
        /// Строка подключения к БД.
        /// </summary>
        public string DbConnection { get; set; }
        
        /// <summary>
        /// Url адрес к зарплатному сервису.
        /// </summary>
        public string SalaryServiceUrl { get; set; }
        
        /// <summary>
        /// Url адрес к бухгалтерскому сервису.
        /// </summary>
        public string AccountingServiceUrl { get; set; }
        
    }

    /// <summary>
    /// Валидатор конфигурации.
    /// </summary>
    public class InfrastructureOptionsValidator : AbstractValidator<InfrastructureOptions>
    {
        
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public InfrastructureOptionsValidator()
        {
            RuleFor(a => a.DbConnection).NotEmpty();
            
            RuleFor(a => a.SalaryServiceUrl).NotEmpty();
            RuleFor(a => a.AccountingServiceUrl).NotEmpty();
        }
    }
}