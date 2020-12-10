using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.Framework.Context
{
    /// <summary>
    /// BaseContext class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="ASC.Online.AuctionApp.Framework.Context.IContext{T}" />
    public class BaseContext<T> : DbContext, IContext<T> where T : class
    {
        #region Member Variables        
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;
        #endregion Member Variables

        #region Properties        
        /// <summary>
        /// Gets or sets the auction setup database set.
        /// </summary>
        /// <value>
        /// The auction setup database set.
        /// </value>
        public virtual DbSet<T> AuctionSetupDbSet { get; set; }
        #endregion Properties

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext{T}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="System.ArgumentNullException">configuration</exception>
        protected BaseContext(IConfiguration configuration) : base()
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext{T}"/> class.
        /// </summary>
        /// <param name="contextOptions">The context options.</param>
        protected BaseContext(DbContextOptions<BaseContext<T>> contextOptions):base(contextOptions)
        {

        }
        #endregion Constructor

        #region Protected Override methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]
                    , builder => builder.EnableRetryOnFailure());
            }
        }
        #endregion Protected Override methods

        #region Public Methods        
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Add(T entity)
        {
            AuctionSetupDbSet.Add(entity);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await AuctionSetupDbSet.ToListAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<T> GetAsync(long item)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await AuctionSetupDbSet.FindAsync(item);
        }

        /// <summary>
        /// Patches the update.
        /// </summary>
        public void PatchUpdate()
        {
            SaveChanges();
        }

        /// <summary>
        /// Puts the update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void PutUpdate(T entity)
        {
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Update(T entity)
        {
            Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        #endregion Public Methods
    }
}
