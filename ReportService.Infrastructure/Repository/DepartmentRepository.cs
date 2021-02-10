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
    /// Репозиторий подразделений.
    /// </summary>
    public class DepartmentRepository : DbAccessor, IDepartmentRepository
    {
        #region Конструкторы

        /// <summary>
        /// Репозиторий подразделений.
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает список подразделений.
        /// </summary>
        /// <returns>Список подразделений.</returns>
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            using (var db = OpenConnection())
            {
                var departments = await
                    db.QueryAsync<Department>(
                        "SELECT d.name, d.Id from deps d where d.active = true");

                return departments.ConvertToDto();
            }
        }

        #endregion
    }
}