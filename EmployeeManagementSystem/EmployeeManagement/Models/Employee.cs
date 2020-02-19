using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        private string userId;
        private string name;
        private string mobile;
        private string salary;
        private string city;
        public string UserId { get => this.userId; set => this.userId = value; }
        public string Name { get => this.name; set => this.name = value; }
        public string Mobile { get => this.mobile; set => this.mobile = value; }
        public string Salary { get => this.salary; set => this.salary = value; }
        public string City { get => this.city; set => this.city = value; }
    }
}
