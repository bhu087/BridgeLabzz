using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.View
{
    public class EmployeeView : IEmployeeView
    {
        IEmployeeRepository repository = new EmployeeRepository();
        public bool Login(string name, string userId, string mobile)
        {
            return this.repository.Login(name, userId, mobile);
        }
        public void Register(Employee employee)
        {
            this.repository.Register(employee);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return this.repository.GetEmployees();
        }
    }
}
