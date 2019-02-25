//-----------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Controllers
{
    using System.Threading.Tasks;
    using Fundoo.API.Data;
    using Fundoo.API.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Values controller class will do all the crud operation in database
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// The context of data context class
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ValuesController(DataContext context)
        {
            ////injecting data conetxt in values controller class
            this._context = context;
        }

        /// <summary>
        /// get value method will retrieve all the data from the database
        /// </summary>
        /// <returns>task of i action result</returns>
        //// GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await this._context.Values.ToListAsync();
            return this.Ok(values);           
        }

        /// <summary>
        /// this method will result specific data from the database
        /// </summary>
        /// <param name="id">integer id</param>
        /// <returns>task of action result</returns>
        //// GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetValues(int id)
        {
            var value = await this._context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return this.Ok(value);
        }

        /// <summary>
        /// post method will add data inside the database
        /// </summary>
        /// <param name="value">value class</param>
        //// POST api/values
        [HttpPost]
        public void Post([FromBody] Value value)
        {
            this._context.Values.Add(value);
            this._context.SaveChanges();
        }

        /// <summary>
        /// put method will update the data inside the database
        /// </summary>
        /// <param name="value">value class</param>
        /// <param name="id">integer id</param>
        //// PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] Value value, int id)
        {
            this._context.Values.Update(this._context.Values.Find(id));
            this._context.SaveChanges();
        }

        /// <summary>
        /// delete method will delete the specific data
        /// </summary>
        /// <param name="value">value class</param>
        /// <param name="id">integer id</param>
        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] Value value, int id)
        {
            this._context.Values.Remove(this._context.Values.Find(id));
            this._context.SaveChanges();
        }
    }
}
