//-----------------------------------------------------------------------
// <copyright file="AuthController.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Fundoo.API.Dtos;
    using Fundoo.API.Model;
    using Fundoo.API.Repository;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// authentication controller class is use to authenticate the user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// instance of interface i authentication repository
        /// </summary>
        private readonly IAuthRepository _repo;

        /// <summary>
        /// constructor of authentication controller 
        /// </summary>
        /// <param name="repo">passing an interface of i authentication</param>
        public AuthController(IAuthRepository repo)
        {
            ////injecting
            this._repo = repo;
        }

        /// <summary>
        /// register method will check all the valid data are provided by user or not 
        /// </summary>
        /// <param name="userForRegistration">User for registration class</param>
        /// <returns>task of i action result</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            try
            {
                userForRegistration.Username = userForRegistration.Username.ToLower();
                if (await this._repo.UserExists(userForRegistration.Username))
                {
                    return this.BadRequest("Username already exists");
                }
            
                var userToCreate = new UserModel
                {
                    Username = userForRegistration.Username
                };
                var createdUser = await this._repo.Register(userToCreate, userForRegistration.Password);
                return this.StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}