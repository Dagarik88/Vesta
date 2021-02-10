using System.Collections.Generic;
using System.Threading.Tasks;
using ReportService.Domain.Models;
using ReportService.Domain.Repository;
using ReportService.Domain.Services.Interfaces;

namespace ReportService.Domain.Services
{
    /// <summary>
    /// Хранилище подразделений. 
    /// </summary>
    public class DepartmentStorage : IDepartmentStorage
    {
        #region Поля

        /// <summary>
        /// Репозиторий подразделений.
        /// </summary>
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Репозиторий сотрудников.
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Репозиторий зарплат.
        /// </summary>
        private readonly ISalaryRepository _salaryRepository;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Хранилище подразделений. 
        /// </summary>
        /// <param name="salaryRepository">Репозиторий зарплат.</param>
        /// <param name="employeeRepository">Репозиторий сотрудников.</param>
        /// <param name="departmentRepository">Репозиторий подразделений.</param>
        public DepartmentStorage(
            ISalaryRepository salaryRepository,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает список подразделений с зарплатной веткой сотрудиков.
        /// </summary>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <returns></returns>
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentSalaryReportAsync(int month, int year)
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();

            foreach (var department in departments)
            {
                var employees = await _employeeRepository.GetEmployeeByDepartmentIdsAsync(department.Id);

                foreach (var employee in employees)
                {
                    employee.Salary = await _salaryRepository.GetSalaryByInnAsync(employee.Inn);
                }

                department.Employees = employees;
            }

            return departments;
        }

        #endregion
    }
}