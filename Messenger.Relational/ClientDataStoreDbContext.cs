using Messenger.Core;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Relational
{

	public class ClientDataStoreDbContext : DbContext
    {
		#region DbSets 

        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        #endregion

        #region Constructor

        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }

        #endregion

        #region Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);
            
            // TODO: Set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);
        }

        #endregion
    	}
}