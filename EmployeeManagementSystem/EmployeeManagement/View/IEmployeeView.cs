using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.View
{
    interface IEmployeeView
    {
        void Register(string Id, string name, string mobile, string salary, string city);
        bool Login(string name, string userId, string mobile);
    }
}
