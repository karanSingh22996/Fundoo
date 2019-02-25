//-----------------------------------------------------------------------
// <copyright file="DataContext.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Fundoo.API.Data
{
    using Fundoo.API.Model;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Data context is class which extends database context of entity framework
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">The options of database context options.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public DbSet<Value> Values { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DbSet<UserModel> User { get; set; }
    }
}
