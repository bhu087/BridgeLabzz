using EmployeeManagement.View;
using EmployeeManagement.Models;
using NUnit.Framework;

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
            Assert.IsTrue(employeeProject.Login(employee));
        }
    }
}