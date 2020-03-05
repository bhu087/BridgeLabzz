/////------------------------------------------------------------------------
////<copyright file="AccountManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Account
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Model.Account;
    using Repository.Repo;

    /// <summary>
    /// Account manager
    /// </summary>
    /// <seealso cref="Manager.Account.IAccountManager" />
    public class AccountManager : IAccountManager
    {
        /// <summary>
        /// The account repository interface
        /// </summary>
        public readonly IAccountRepo accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManager"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        public AccountManager(IAccountRepo accountRepository)
        {
                this.accountRepository = accountRepository;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>string value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<string> Delete(int id)
        {
            try 
            {
                var result = this.accountRepository.Delete(id);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>string value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<string> ForgetPassword(string email)
        {
            try
            {
                var result = this.accountRepository.ForgetPassword(email);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>string value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public IEnumerable<Registration> GetAll()
        {
            try
            {
                var list = this.accountRepository.GetAll();
                return list;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return Registration model</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Registration GetById(int id)
        {
            try 
            {
                var singleUser = this.accountRepository.GetById(id);
                return singleUser;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>string value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<string> Login(Login loginModel)
        {
            try
            {
                var result = this.accountRepository.Login(loginModel);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Logins the by google.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>return Register model</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<Registration> LoginByGoogle(Login loginModel)
        {
            try
            {
                var result = this.accountRepository.LoginByGoogle(loginModel);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Logs the out from social account.
        /// </summary>
        /// <returns>string value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<string> LogOutFromSocialAccount()
        {
            try
            {
                return this.accountRepository.LogOutFromSocialAccount();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>integer value</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<int> Register(Registration register)
        {
            try
            {
                var result = this.accountRepository.Register(register);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>return notification</returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<string> ResetPassword(string email)
        {
            try
            {
                var result = this.accountRepository.ResetPassword(email);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        /// <exception cref="Exception">throw the exception</exception>
        public Task<int> Update(string email, int id, Registration register)
        {
            try
            {
                var result = this.accountRepository.Update(email, id, register);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
