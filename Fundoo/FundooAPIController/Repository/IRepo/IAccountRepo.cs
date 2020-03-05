/////------------------------------------------------------------------------
////<copyright file="IAccountRepo.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository.Repo
{
    using Model.Account;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Account repository
    /// </summary>
    public interface IAccountRepo
    {
        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>returns status of register</returns>
        Task<int> Register(Registration register);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status of delete</returns>
        Task<int> Delete(int id);

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>status of update</returns>
        Task<int> Update(Registration register);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>all registrations</returns>
        IEnumerable<Registration> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Get register by id</returns>
        Registration GetById(int id);

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>returns status of login</returns>
        Task<string> Login(Login loginModel);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>status of reset password</returns>
        Task<string> ResetPassword(string email);

        /// <summary>
        /// Logins the by google.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns>registration model of google login</returns>
        Task<Registration> LoginByGoogle(Login loginModel);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>status of forget password</returns>
        Task<string> ForgetPassword(string email);

        /// <summary>
        /// Logs the out from social account.
        /// </summary>
        /// <returns>return status of logout</returns>
        Task<string> LogOutFromSocialAccount();
    }
}
