using EmployeeManagement.Models;
using EmployeeManagement.View;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        Regex mobileNumber = new Regex("^[0-9]{10}$");
        Regex nameRegex = new Regex("^[A-Z]{1}[a-z]{5,10}");
        Regex cityRegex = new Regex("^[A-Z]{1}[a-z]{5,10}");
        Regex salaryRegex = new Regex("^['1'-'9']{1}['0'-'9']{3,5}");
        Regex idRegex = new Regex("^['1'-'9']{1},['0'-'9']{3,5}");
        IEmployeeView employeeView = new EmployeeView();
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
        [HttpPost]
        [Route("api/add")]
        public ActionResult Register(string name, string mobile, string salary, string city)
        {
            Employee employee = new Employee();
            if (name == null)
            {
                return this.Ok("Name Required");
            }
            Match nameMatch = nameRegex.Match(name);
            if (!nameMatch.Success)
            {
                return this.Ok("Name is invalid");
            }
            if (mobile == null)
            {
                return this.Ok("Mobile Number Required");
            }
            Match mobileMatch = mobileNumber.Match(mobile);
            if (!mobileMatch.Success)
            {
                return this.Ok("Mobile Number Invalid");
            }
            if (city == null)
            {
                return this.Ok("City Required");
            }
            Match cityMatch = nameRegex.Match(city);
            if (!cityMatch.Success)
            {
                return this.Ok("Invalid city name");
            }
            if (salary == null)
            {
                salary = string.Empty;
            }
            employee.UserId = "";
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
            Match userIdMatch = nameRegex.Match(userId);
            if (!userIdMatch.Success)
            {
                return this.Ok("userId is invalid");
            }
            if (name == null)
            {
                return this.Ok("Name Required");
            }
            Match nameMatch = nameRegex.Match(name);
            if (!nameMatch.Success)
            {
                return this.Ok("Name is invalid");
            }
            if (mobile == null)
            {
                return this.Ok("Mobile Number Required");
            }
            Match mobileMatch = mobileNumber.Match(mobile);
            if (!mobileMatch.Success)
            {
                return this.Ok("Mobile Number Invalid");
            }
            Match salaryMatch = mobileNumber.Match(salary);
            if (!salaryMatch.Success)
            {
                return this.Ok("Invalid Amount");
            }
            if (city == null)
            {
                return this.Ok("City Required");
            }
            Match cityMatch = nameRegex.Match(city);
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
            try
            {
                bool returnResult = this.employeeView.UpdateEmployee(employee);
                return this.Ok(returnResult);
            }
            catch(Exception e)
            {
                return this.BadRequest(e.Message);
            }
            
        }
    }
}
