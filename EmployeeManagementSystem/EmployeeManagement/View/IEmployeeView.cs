using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.View
{
    interface IEmployeeView
    {
        void Register(Employee employee);
        bool Login(string name, string userId, string mobile);
        IEnumerable<Employee> GetEmployees();
    }
}
