/////------------------------------------------------------------------------
////<copyright file="IEmployeeRepository.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeManagement.Models;
    
    /// <summary>
    /// Employee repository interface
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Registers the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void Register(Employee employee);

        /// <summary>
        /// Logins the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns the boolean value</returns>
        bool Login(Employee employee);

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>returns the List of employees</returns>
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns the boolean value</returns>
        bool UpdateEmployee(Employee employee);
    }
}
