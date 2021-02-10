using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ReportService.Domain.Models;
using ReportService.Domain.Repository;
using ReportService.Infrastructure.Helpers;
using ReportService.Infrastructure.Models;
using ReportService.Infrastructure.Models.Mappings;

namespace ReportService.Infrastructure.Repository
{
    /// <summary>
    /// Репозиторий сотрудников.
    /// </summary>
    public class EmployeeRepository : DbAccessor, IEmployeeRepository
    {
        #region Конструкторы

        /// <summary>
        /// Репозиторий сотрудников.
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public EmployeeRepository(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает список сотрудников подразделения.
        /// </summary>
        /// <param name="departmentId">Id подразделения.</param>
        /// <returns>Список сотрудников.</returns>
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeByDepartmentIdsAsync(int departmentId)
        {
            using (var db = OpenConnection())
            {
                var employees = await
                    db.QueryAsync<Employee>("SELECT e.name, e.inn FROM emps e WHERE e.departmentid = @departmentId",
                        new {departmentId});

                return employees.ConvertToDto();
            }
        }

        #endregion
    }
}