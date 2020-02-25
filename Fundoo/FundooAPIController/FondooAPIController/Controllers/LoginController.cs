using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Common.Account;

namespace FondooAPIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        IAccountManager accountManager;
        public ActionResult Login()
        {
            Login login = new Login()
            {
                Email = "Hello",
                Password = "123456"
            };
            var flag = accountManager.LoginAsync(login);
            return Ok(flag);
        }
    }
}