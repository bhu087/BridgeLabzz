using EmployeeManagement.View;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : ControllerBase
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
        public void Register(string Id, string name, string mobile, string salary, string city)
        {
            employeeView.Register(Id, name, mobile, salary, city);
        }
    }
}
