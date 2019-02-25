//-----------------------------------------------------------------------
// <copyright file="IAuthRepository.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Repository
{
    using System.Threading.Tasks;
    using Fundoo.API.Model;

    /// <summary>
    /// interface of authorization class
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>task of user model</returns>
        Task<UserModel> Register(UserModel user, string password);

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>task of user model</returns>
        Task<UserModel> Login(string username, string password);

        /// <summary>
        /// Users the exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>boolean true and false</returns>
        Task<bool> UserExists(string username);
    }
}