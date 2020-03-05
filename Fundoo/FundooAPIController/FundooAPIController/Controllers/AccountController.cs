/////------------------------------------------------------------------------
////<copyright file="AccountController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------

namespace FundooAPIController.Controllers
{
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

    /// <summary>
    /// Account controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountManager manager;
        ////protected string googleplus_client_id = "1034367374374-cumrd86psek13h3cte3a30g3ojh93mm4.apps.googleusercontent.com";    // Replace this with your Client ID
        ////protected string googleplus_client_secret = "-Lx-O2ZtldcQ86PJ-ru-oJ-E";                                                // Replace this with your Client Secret
        ////protected string googleplus_redirect_url = "https://localhost:44371/swagger";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        ////protected string Parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public AccountController(IAccountManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>Send Action result</returns>
        [HttpPost]
        [Route("register")]
        public ActionResult Register(Registration register)
        {
            try
            {
                var result = this.manager.Register(register);
                if (result != null)
                {
                    return this.Ok(register);
                }

                return this.BadRequest();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Send Action result</returns>
        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var result = this.manager.Delete(id);
            if (result != null)
            {
                return this.Ok("Delete Successful");
            }

            return this.BadRequest("Something Wrong");
        }

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("update")]
        public ActionResult Update(Registration register)
        {
            try
            {
                var result = this.manager.Update(register);
                if (result != null)
                {
                    return this.Ok("Udated successfully");
                }

                return this.BadRequest("Not updated");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("getAll")]
        public ActionResult GetAll()
        {
            try
            {
                var result = this.manager.GetAll();
                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("No Accounts available");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("getById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = this.manager.GetById(id);
                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("User Not Registered");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>Send Action result</returns>
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

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Send Action result</returns>
        [HttpPost]
        [Route("resetPassword")]
        public ActionResult ResetPassword(string email)
        {
            var result = this.manager.ResetPassword(email);
            try
            {
                if (result == null)
                {
                    return this.BadRequest("Account Not available");
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

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Send Action result</returns>
        [HttpPost]
        [Route("forgetPassword")]
        public ActionResult ForgetPassword(string email)
        {
            var result = this.manager.ForgetPassword(email);
            try
            {
                if (result == null)
                {
                    return this.BadRequest("Account Not Available");
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

        /// <summary>
        /// Logins the by google.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("loginbygoogle")]
        public ActionResult LoginByGoogle(Login loginModel)
        {
            try
            {
                var result = this.manager.LoginByGoogle(loginModel);
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

        /// <summary>
        /// Logs the out from social account.
        /// </summary>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("logoutFromSocialAccount")]
        public ActionResult LogOutFromSocialAccount()
        {
            try
            {
                var result = this.manager.LogOutFromSocialAccount();
                if (result.Result.Equals("LoggedOut form Google Account"))
                {
                    return this.Ok(result);
                }

                return this.BadRequest(result.Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}