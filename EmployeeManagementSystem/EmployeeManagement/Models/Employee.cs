using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Salary { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
