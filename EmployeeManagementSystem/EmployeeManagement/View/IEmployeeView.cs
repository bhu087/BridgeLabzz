/////------------------------------------------------------------------------
////<copyright file="IEmployeeView.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeManagement.Models;

    /// <summary>
    /// This is the Employee view interface
    /// </summary>
    public interface IEmployeeView
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
        /// <returns>returns boolean value</returns>
        bool Login(Employee employee);

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>returns List of values</returns>
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns boolean value</returns>
        bool UpdateEmployee(Employee employee);
    }
}
