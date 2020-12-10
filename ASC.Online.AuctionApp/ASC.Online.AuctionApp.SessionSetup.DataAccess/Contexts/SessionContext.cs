using ASC.Online.AuctionApp.Framework.Context;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts.Interfaces;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts
{
    /// <summary>
    /// Act as the context class for Auction Session related operations
    /// </summary>
    /// <seealso cref="ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts.Interfaces.ISessionContext" />
    public class SessionContext : BaseContext<Sessions>, ISessionContext
    {
        #region Properties        
        /// <summary>
        /// Gets or sets the session setup database set.
        /// </summary>
        /// <value>
        /// The session setup database set.
        /// </value>
        public DbSet<Sessions> SessionSetupDbSet { get; set; }
        #endregion Properties

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SessionContext(IConfiguration configuration)
           : base(configuration)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SessionContext(DbContextOptions<BaseContext<Sessions>> options)
            : base(options)
        {
            
        }
        #endregion Constructor
    }
}
