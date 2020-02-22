/////------------------------------------------------------------------------
////<copyright file="EmployeeNUnitTest.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeNUnitTesting
{
    using System;
    using EmployeeManagement.Models;
    using EmployeeManagement.View;
    using NUnit.Framework;

    /// <summary>
    /// Employee NUnit Testing class
    /// </summary>
    public class EmployeeNUnitTest
    {
        /// <summary>
        /// Logins the test 1.
        /// </summary>
        [Test]
        public void LoginTest1()
        {
            var employee = new Employee();
            employee.Name = "Bhushan";
            employee.Mobile = "12345";
            var employeeProject = new EmployeeView();
            Assert.False(employeeProject.Login(employee));
        }

        /// <summary>
        /// Logins the test 2.
        /// </summary>
        [Test]
        public void LoginTest2()
        {
            var employee = new Employee();
            employee.Name = "Johnsi";
            employee.Mobile = "1223456652";
            var employeeProject = new EmployeeView();
            bool flag = employeeProject.Login(employee);
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Logins the test 3.
        /// </summary>
        [Test]
        public void LoginTest3()
        {
            try 
            {
                var employee = new Employee();
                employee.Mobile = "svc";
                var employeeProject = new EmployeeView();
                bool flag = employeeProject.Login(employee);
            }
            catch (Exception e)
            {
                Assert.AreEqual("NullReferenceException", e.GetType().Name);
            }
        }

        /// <summary>
        /// Logins the test 4.
        /// </summary>
        [Test]
        public void LoginTest4()
        {
            try
            {
                var employee = new Employee();
                var employeeProject = new EmployeeView();
                bool flag = employeeProject.Login(employee);
            }
            catch (Exception e)
            {
                Assert.AreEqual("NullReferenceException", e.GetType().Name);
            }
        }

        /// <summary>
        /// Updates the test 1.
        /// </summary>
        [Test]
        public void UpdateTest1()
        {
            try
            {
                var employee = new Employee();
                var employeeProject = new EmployeeView();
                bool flag = employeeProject.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                Assert.AreEqual("SqlException", e.GetType().Name);
            }
        }

        /// <summary>
        /// Updates the test 2.
        /// </summary>
        [Test]
        public void UpdateTest2()
        {
                var employee = new Employee();
                employee.UserId = "8031";
                employee.Name = "Johnsi";
                employee.Mobile = "1223456652";
                employee.Salary = "10000";
                employee.City = "Sagara";
                var employeeProject = new EmployeeView();
                bool flag = employeeProject.UpdateEmployee(employee);
                Assert.IsTrue(flag);
        }

        /// <summary>
        /// Updates the test 3.
        /// </summary>
        [Test]
        public void UpdateTest3()
        {
            try
            {
                var employee = new Employee();
                employee.UserId = "1000";
                employee.Name = "John";
                employee.Mobile = "1223456652";
                employee.Salary = "1000";
                //// employee.City = "Sirsi";
                var employeeProject = new EmployeeView();
                bool flag = employeeProject.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                Assert.AreEqual("SqlException", e.GetType().Name);
            }
        }

        /// <summary>
        /// Registers the test.
        /// </summary>
        [Test]
        public void RegisterTest()
        {
            try
            {
                var employee = new Employee();
                employee.Name = "John";
                employee.Mobile = "1223456652";
                employee.Salary = "1000";
                //// employee.City = "Sirsi";
                var employeeProject = new EmployeeView();
                employeeProject.Register(employee);
            }
            catch (Exception e)
            {
                Assert.AreEqual("SqlException", e.GetType().Name);
            }
        }
    }
}