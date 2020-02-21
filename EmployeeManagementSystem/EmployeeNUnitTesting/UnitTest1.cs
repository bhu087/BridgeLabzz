using EmployeeManagement.View;
using EmployeeManagement.Models;
using NUnit.Framework;
using EmployeeManagement.Controllers;

namespace EmployeeNUnitTesting
{
    public class Tests
    {
        [Test]
        public void LoginTest1()
        {
            var employee = new Employee();
            employee.Name = "Bhushan";
            employee.Mobile = "12345";
            var employeeProject = new EmployeeView();
            Assert.False(employeeProject.Login(employee));
        }
        [Test]
        public void LoginTest2()
        {
            var employee = new Employee();
            employee.Name = "X";
            employee.Mobile = "svc";
            var employeeProject = new EmployeeView();
            bool flag = employeeProject.Login(employee);
            Assert.IsTrue(flag);
        }
        [Test]
        public void LoginTest3()
        {
            var employee = new Employee();
            employee.Mobile = "svc";
            var employeeProject = new EmployeeView();
            bool flag = employeeProject.Login(employee);
            Assert.IsTrue(!flag);
        }
    }
}