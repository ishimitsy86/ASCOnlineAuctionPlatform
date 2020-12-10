using ASC.Online.AuctionApp.SessionSetup.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASC.Online.AuctionApp.MockDataSeed.Contexts
{
    /// <summary>
    /// Initial Data Migration Context class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AuctionContext: DbContext
    {
        #region DBSet
        public DbSet<Sessions> Sessions { get; set; }
        #endregion DBSet

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The database context options.</param>
        public AuctionContext(DbContextOptions<AuctionContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion Constructor

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessions>()
                  .HasData(
                new Sessions
                {
                    Id = 1,
                    SessionName = "Mistory Hunt",
                    SessionDescription = "This session is being held as a tribute to santa!!!",
                    SessionStartDate = new DateTime(2020, 12, 22),
                    SessionEndDate = new DateTime(2020, 12, 25),
                    NumberOfItems = 2,
                    SessionStatus = "Pending",
                    CreatedMemberId = 1,
                    CreatedBy = "Jaimy Solovin",
                    CreatedDate = new DateTime(2020, 12, 08),
                    ModifiedMemberId = 1,
                    ModifiedBy = "Jaimy Solovin",
                    ModifiedDate = new DateTime(2020, 12, 08)
                });

            base.OnModelCreating(modelBuilder);
        }
        #endregion Protected Methods
    }
}
