/////------------------------------------------------------------------------
////<copyright file="EmployeeView.cs" company="BridgeLabz">
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
    using EmployeeManagement.Repository;

    /// <summary>
    /// This is the employee View class
    /// </summary>
    /// <seealso cref="EmployeeManagement.View.IEmployeeView" />
    public class EmployeeView : IEmployeeView
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IEmployeeRepository repository = new EmployeeRepository();

        /// <summary>
        /// Logins the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// returns boolean value
        /// </returns>
        public bool Login(Employee employee)
        {
            bool responseFlag = this.repository.Login(employee);
            return responseFlag;
        }

        /// <summary>
        /// Registers the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void Register(Employee employee)
        {
            this.repository.Register(employee);
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>
        /// returns List of values
        /// </returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return this.repository.GetEmployees();
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// returns boolean value
        /// </returns>
        public bool UpdateEmployee(Employee employee)
        {
            return this.repository.UpdateEmployee(employee);
        }
    }
}