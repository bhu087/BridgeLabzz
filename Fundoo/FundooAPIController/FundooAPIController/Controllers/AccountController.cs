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
    using Contract;
    using LoggerService;
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
        /// The logger
        /// </summary>
        ILoggerManager logger = new LoggerManager();
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
                if (result.Result != 0)
                {

                    logger.LogDebug("Debug Succeccfull : Register(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(register);
                }
                logger.LogDebug("Debug Succeccfull : Register(Account)");
                logger.LogInfo(result.Status.ToString());
                logger.LogWarn("Account already exists for this email ID " + register.Email);
                return this.BadRequest("Account already exists for this email ID");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : Register(Account)");
                logger.LogError("Error : " + e.Message);
                return this.BadRequest(e.Message);
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
            try
            {
                var result = this.manager.Delete(id);
                if (!result.Result.Equals(""))
                {
                    logger.LogDebug("Debug Succeccfull : delete(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok("Delete Successful");
                }
                logger.LogDebug("Debug Succeccfull : delete(Account)");
                logger.LogInfo(result.Status.ToString());
                logger.LogWarn("Account Not available " + id);
                return this.BadRequest("Something Wrong");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : delete(Account)");
                logger.LogError("Error : " + e.Message);
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>Send Action result</returns>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        [Route("update")]
        public ActionResult Update(string email, int id, Registration register)
        {
            try
            {
                var result = this.manager.Update(email, id, register);
                if (result.Result != 0)
                {
                    logger.LogDebug("Debug Succeccfull : Update(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok("Udated successfully");
                }
                logger.LogDebug("Debug Succeccfull : update(Account)");
                logger.LogInfo(result.Status.ToString());
                logger.LogWarn("Account Not available " + id);
                return this.BadRequest("Not updated");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : update(Account)");
                logger.LogError("Error : " + e.Message);
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
                    logger.LogDebug("Debug Succeccfull : Get All(Account)");
                    logger.LogInfo(result.ToString());
                    return this.Ok(result);
                }
                logger.LogDebug("Debug Succeccfull : getAll(Account)");
                logger.LogInfo(result.ToString());
                logger.LogWarn("List Not available ");
                return this.BadRequest("No Accounts available");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : getAll(Account)");
                logger.LogError("Error : " + e.Message);
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
                    logger.LogDebug("Debug Succeccfull : Get By Id(Account)");
                    logger.LogInfo(result.ToString());
                    return this.Ok(result);
                }
                logger.LogDebug("Debug Succeccfull : getById(Account)");
                logger.LogInfo(result.ToString());
                logger.LogWarn("Account Not available " + id);
                return this.BadRequest("User Not Registered");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : getById(Account)");
                logger.LogError("Error : " + e.Message);
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
            try
            {
                var result = this.manager.Login(loginModel);
                if (result == null)
                {
                    logger.LogDebug("Debug Succeccfull : login(Account)");
                    logger.LogInfo(result.Status.ToString());
                    logger.LogWarn("Account Not available " + loginModel.Email);
                    return this.BadRequest();
                }
                else
                {
                    logger.LogDebug("Debug Succeccfull : Login(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(result.Result);
                }
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : login(Account)");
                logger.LogError("Error : " + e.Message);
                return this.BadRequest(e.ToString());
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
                    logger.LogDebug("Debug Succeccfull : resetPassword(Account)");
                    logger.LogInfo(result.Status.ToString());
                    logger.LogWarn("Account Not available " + email);
                    return this.BadRequest("Account Not available");
                }
                else
                {
                    logger.LogDebug("Debug Succeccfull : reset password(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(result.Result);
                }
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : resetPassword(Account)");
                logger.LogError("Error : " + e.Message);
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
                    logger.LogDebug("Debug Succeccfull : forgetPassword(Account)");
                    logger.LogInfo(result.Status.ToString());
                    logger.LogWarn("Account Not available " + email);
                    return this.BadRequest("Account Not Available");
                }
                else
                {
                    logger.LogDebug("Debug Succeccfull : forget password(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(result.Result);
                }
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : forgetPassword(Account)");
                logger.LogError("Error : " + e.Message);
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
                    logger.LogDebug("Debug Succeccfull : login By Google(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(result);
                }
                logger.LogDebug("Debug Succeccfull : loginbygoogle(Account)");
                logger.LogInfo(result.Status.ToString());
                logger.LogWarn("Account Not available " + loginModel.Email);
                return this.BadRequest("Something Wrong");
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : loginbygoogle(Account)");
                logger.LogError("Error : " + e.Message);
                throw new Exception(e.Message);
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
                    logger.LogDebug("Debug Succeccfull : logout form Social Account(Account)");
                    logger.LogInfo(result.Status.ToString());
                    return this.Ok(result);
                }
                logger.LogDebug("Debug Succeccfull : logoutFromSocialAccount(Account)");
                logger.LogInfo(result.Status.ToString());
                logger.LogWarn("Not Logged In");
                return this.BadRequest(result.Result);
            }
            catch (Exception e)
            {
                logger.LogDebug("Debug Succeccfull : logoutFromSocialAccount(Account)");
                logger.LogError("Error : " + e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}