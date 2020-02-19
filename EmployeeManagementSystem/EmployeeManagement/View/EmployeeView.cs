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
        public void Register(string Id, string name, string mobile, string salary, string city)
        {
            this.repository.Register(Id, name, mobile, salary, city);
        }
    }
}
