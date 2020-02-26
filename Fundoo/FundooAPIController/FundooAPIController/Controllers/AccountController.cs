﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Account;

namespace FundooAPIController.Controllers
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
        [Route("getall")]
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
    }
    
}