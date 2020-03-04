using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Manager.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Account;
using Newtonsoft.Json;

namespace FundooAPIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountManager manager;
        //protected string googleplus_client_id = "1034367374374-cumrd86psek13h3cte3a30g3ojh93mm4.apps.googleusercontent.com";    // Replace this with your Client ID
        //protected string googleplus_client_secret = "-Lx-O2ZtldcQ86PJ-ru-oJ-E";                                                // Replace this with your Client Secret
        //protected string googleplus_redirect_url = "https://localhost:44371/swagger";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        //protected string Parameters;
        public AccountController(IAccountManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("register")]
        public ActionResult Register(Registration register)
        {
            try
            {
                var result = this.manager.Register(register);
                if (result != null)
                {
                    return Ok(register);
                }
                return this.BadRequest();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var result = this.manager.Delete(id);
            if (result != null)
            {
                return Ok("Delete Successful");
            }
            return this.BadRequest("Something Wrong");
        }
        [HttpPost]
        [Route("update")]
        public ActionResult Update(Registration register)
        {
            try
            {
                var result = manager.Update(register);
                if (result != null)
                {
                    return Ok("Udated successfully");
                }
                return this.BadRequest("Not updated");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult GetAll()
        {
            try
            {
                var result = manager.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        [Route("getById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = this.manager.GetById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return this.BadRequest("User Not Registered");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login loginModel)
        {
            var result = this.manager.Login(loginModel);
            if (result == null)
            {
                return this.BadRequest();
            }
            else
            {
                return this.Ok(result.Result);
            }
        }
        [HttpPost]
        [Route("resetPassword")]
        public ActionResult ResetPassword(string email)
        {
            var result = this.manager.ResetPassword(email);
            try
            {
                if (result == null)
                {
                    return this.BadRequest();
                }
                else
                {
                    return this.Ok(result.Result);
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(e.ToString());
            }
        }
        [HttpPost]
        [Route("forgetPassword")]
        public ActionResult ForgetPassword(string email)
        {
            var result = this.manager.ForgetPassword(email);
            try
            {
                if (result == null)
                {
                    return this.BadRequest();
                }
                else
                {
                    return this.Ok(result.Result);
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(e.ToString());
            }
        }
        [HttpPost]
        [Route("loginbygoogle")]
        public ActionResult LoginByGoogle(Login loginModel)
        {
            try
            {
                var result = (this.manager.LoginByGoogle(loginModel));
                if (result != null)
                {  
                    return this.Ok(result);
                }
                return this.BadRequest("Something Wrong");
            }
            catch (Exception)
            {
                throw new Exception();
            }
              
        }
    }
}