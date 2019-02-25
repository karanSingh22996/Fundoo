//-----------------------------------------------------------------------
// <copyright file="AuthRepository.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Repository
{
    using System.Threading.Tasks;
    using Fundoo.API.Model;
    using Fundoo.API.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Authentication repository class will check authorization whether user is present in database or not
    /// </summary>
    /// <seealso cref="Fundoo.API.Repository.IAuthRepository" />
    public class AuthRepository : IAuthRepository
    {
        /// <summary>
        /// The instance of Data context class
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AuthRepository(DataContext context)
        {
            ////injecting data context to authentication repository
            this._context = context;
        }

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns> Task of user model</returns>
        public async Task<UserModel> Login(string username, string password)
        {
            ////user variable will check the occurence of username
            var user = await this._context.User.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            ////verify method will verify password and then encrypt
            if (!this.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        /// <summary>
        /// Verifies the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns>boolean true of false</returns>
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            ////hmac will store the encrypted password
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                ////computed hash will store encoded password
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>task of user model</returns>
        public async Task<UserModel> Register(UserModel user, string password)
        {
            byte[] passwordHash, passwordSalt;
            this.CreatePassword(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await this._context.User.AddAsync(user);
            await this._context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Creates the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Users the exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>task of user model</returns>
        public async Task<bool> UserExists(string username)
        {
            if (await this._context.User.AnyAsync(x => x.Username == username))
            {
                return true;
            }

            return false;
        }
    }
}