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
        public ActionResult Login(string name, string userId, string mobile)
        {
            Console.WriteLine("Hi");
            try
            {
                bool responceFlag = employeeView.Login(name, userId, mobile);
                return this.Ok(responceFlag);
            }
            catch(Exception e)
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
    }
}
