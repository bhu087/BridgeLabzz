/////------------------------------------------------------------------------
////<copyright file="IAccountManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Account
{
    using Model.Account;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Account interface
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>it returns the status of the rigistration</returns>
        Task<int> Register(Registration register);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>it sends the status of Delete</returns>
        Task<string> Delete(int id);

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>it sends the status of the update</returns>
        Task<int> Update(string email, int id, Registration register);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>returns all Registration lists</returns>
        IEnumerable<Registration> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return Object for get by id</returns>
        Registration GetById(int id);

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>returns string</returns>
        Task<string> Login(Login loginModel);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns string</returns>
        Task<string> ResetPassword(string email);

        /// <summary>
        /// Logins the by google.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>Return model of logged in</returns>
        Task<Registration> LoginByGoogle(Login loginModel);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns string</returns>
        Task<string> ForgetPassword(string email);

        /// <summary>
        /// Logs the out from social account.
        /// </summary>
        /// <returns>returns string</returns>
        Task<string> LogOutFromSocialAccount();
    }
}
