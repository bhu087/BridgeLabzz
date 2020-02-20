using EmployeeManagement.Models;
using EmployeeManagement.View;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
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
            if (ModelState.IsValid)
            {
                if (salary == null)
                {
                    salary = string.Empty;
                }
                Employee employee = new Employee();
                employee.UserId = "";
                employee.Name = name;
                employee.Mobile = mobile;
                employee.Salary = salary;
                employee.City = city;
                try
                {
                    employeeView.Register(employee);
                    return this.Ok("Added Successfully");
                }
                catch (Exception e)
                {
                    return this.BadRequest(e.Message);
                }
            }
            return View();
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
