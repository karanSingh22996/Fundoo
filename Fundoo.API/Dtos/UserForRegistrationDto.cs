//-----------------------------------------------------------------------
// <copyright file="AnagramIn2D.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Dtos
{
    /// <summary>
    /// user for registration class is created  so that we do not need to pass username and password everywhere
    /// </summary>
    public class UserForRegistrationDto
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
}
