/////------------------------------------------------------------------------
////<copyright file="EmployeeController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using EmployeeManagement.Models;
    using EmployeeManagement.View;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    
    /// <summary>
    /// Employee Controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Regular expression mobile number
        /// </summary>
        private Regex mobileNumber = new Regex("^[0-9]{10}$");

        /// <summary>
        /// The name Regular expression
        /// </summary>
        private Regex nameRegex = new Regex("^[A-Z]{1}[a-z]{5,10}$");

        /// <summary>
        /// The city Regular expression
        /// </summary>
        private Regex cityRegex = new Regex("^[A-Z]{1}[a-z]{5,10}$");

        /// <summary>
        /// The salary Regular expression
        /// </summary>
        private Regex salaryRegex = new Regex("^[0-9]{5}$");

        /// <summary>
        /// The identifier Regular expression
        /// </summary>
        private Regex idRegex = new Regex("^[0-9]{4}$");

        /// <summary>
        /// The employee view
        /// </summary>
        private IEmployeeView employeeView = new EmployeeView();

        /// <summary>
        /// Logins the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="mobile">The mobile.</param>
        /// <returns>action result</returns>
        [HttpPost]
        [Route("api/login")]
        public ActionResult Login(string name, string mobile)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Mobile = mobile;
            try
            {
                bool responceFlag = this.employeeView.Login(employee);
                if (responceFlag)
                {
                    return this.Ok(responceFlag);
                }

                return this.BadRequest("User not registered");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="mobile">The mobile.</param>
        /// <param name="salary">The salary.</param>
        /// <param name="city">The city.</param>
        /// <returns>action result</returns>
        [HttpPost]
        [Route("api/add")]
        public ActionResult Register(string name, string mobile, string salary, string city)
        {
            Employee employee = new Employee();
            if (name == null)
            {
                return this.Ok("Name Required");
            }

            Match nameMatch = this.nameRegex.Match(name);
            if (!nameMatch.Success)
            {
                return this.Ok("Name is invalid");
            }

            if (mobile == null)
            {
                return this.Ok("Mobile Number Required");
            }

            Match mobileMatch = this.mobileNumber.Match(mobile);
            if (!mobileMatch.Success)
            {
                return this.Ok("Mobile Number Invalid");
            }

            if (city == null)
            {
                return this.Ok("City Required");
            }

            Match cityMatch = this.nameRegex.Match(city);
            if (!cityMatch.Success)
            {
                return this.Ok("Invalid city name");
            }

            if (salary == null)
            {
                salary = string.Empty;
            }

            employee.UserId = string.Empty;
            employee.Name = name;
            employee.Mobile = mobile;
            employee.Salary = salary;
            employee.City = city;
            try
            {
                this.employeeView.Register(employee);
                return this.Ok("Added Successfully");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>action result</returns>
        [HttpGet]
        [Route("api/getEmplyees")]
        public ActionResult GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = this.employeeView.GetEmployees();
                return this.Ok(employees);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="mobile">The mobile.</param>
        /// <param name="salary">The salary.</param>
        /// <param name="city">The city.</param>
        /// <returns>action result</returns>
        [HttpPost]
        [Route("api/update")]
        public ActionResult UpdateEmployee(string userId, string name, string mobile, string salary, string city)
        {
            if (salary == null)
            {
                salary = "0";
            }

            if (userId == null)
            {
                return this.Ok("User Id Required");
            }
            
            Match userIdMatch = this.idRegex.Match(userId);
            if (!userIdMatch.Success)
            {
                return this.Ok("userId is invalid");
            }

            if (name == null)
            {
                return this.Ok("Name Required");
            }

            Match nameMatch = this.nameRegex.Match(name);
            if (!nameMatch.Success)
            {
                return this.Ok("Name is invalid");
            }

            if (mobile == null)
            {
                return this.Ok("Mobile Number Required");
            }

            Match mobileMatch = this.mobileNumber.Match(mobile);
            if (!mobileMatch.Success)
            {
                return this.Ok("Mobile Number Invalid");
            }

            Match salaryMatch = this.salaryRegex.Match(salary);
            if (!salaryMatch.Success)
            {
                return this.Ok("Invalid Amount");
            }

            if (city == null)
            {
                return this.Ok("City Required");
            }

            Match cityMatch = this.cityRegex.Match(city);
            if (!cityMatch.Success)
            {
                return this.Ok("Invalid city name");
            }

            Employee employee = new Employee
            {
                UserId = userId,
                Name = name,
                Mobile = mobile,
                Salary = salary,
                City = city
            };
            bool returnResult = this.employeeView.UpdateEmployee(employee);
            if (returnResult)
            {
                return this.Ok("Updated Successfully");
            }
            else
            {
                return this.BadRequest("User Not Found");
            }
        }
    }
}
