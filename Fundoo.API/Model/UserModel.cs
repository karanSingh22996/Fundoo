//-----------------------------------------------------------------------
// <copyright file="UserModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Model
{
    /// <summary>
    /// user model is model class for login and for encrypting password 
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>
        /// The password salt.
        /// </value>
        public byte[] PasswordSalt { get; set; }
    }
}