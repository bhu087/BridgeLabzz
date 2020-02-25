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
    public class AccountController : ControllerBase
    {
        public readonly IAccountManager manager;
        public AccountController(IAccountManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("register")]
        public ActionResult Register(Register register)
        {
            var result = this.manager.RegisterAsync(register);
            return Ok(result);
        }
    }
}