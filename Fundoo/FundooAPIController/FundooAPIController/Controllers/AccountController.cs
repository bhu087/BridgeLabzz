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
        protected string googleplus_client_id = "1034367374374-cumrd86psek13h3cte3a30g3ojh93mm4.apps.googleusercontent.com";    // Replace this with your Client ID
        protected string googleplus_client_secret = "-Lx-O2ZtldcQ86PJ-ru-oJ-E";                                                // Replace this with your Client Secret
        protected string googleplus_redirect_url = "https://localhost:44371/swagger";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        protected string Parameters;
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
            return Ok("Something Wrong");
        }
        [HttpPost]
        [Route("update")]
        public ActionResult Update(Registration register)
        {
            try
            {
                var result = manager.Update(register);
                return Ok("Udated successfully");
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
        [Route("loginbygoogle")]
        public void LoginByGoogle(string email)
        {
            var code1 = (this.manager.LoginByGoogle(email));
            var code = code1.Result;
            string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&code=FFFF";
            var request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            UTF8Encoding utfenc = new UTF8Encoding();
            byte[] bytes = utfenc.GetBytes(poststring);
            Stream outputstream = null;
            try
            {
                string responseFromServer; // = streamReader.ReadToEnd();
                request.ContentLength = bytes.Length;
                outputstream = request.GetRequestStream();
                outputstream.Write(bytes, 0, bytes.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(s))
                {
                    s.Flush();
                    responseFromServer = sr.ReadToEnd();
                    Debug.WriteLine(responseFromServer);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }  
        }
    }
}