using Messenger.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Relational
{
    public class ClientDataStore : IClientDataStore
    {
        #region Protected Members

        protected ClientDataStoreDbContext mDbContext;

        #endregion

        #region Constructor

        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set local member
            mDbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }

        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.LoginCredentials.FirstOrDefault());
        }

        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Clear all entries
            mDbContext.LoginCredentials.RemoveRange(mDbContext.LoginCredentials);

            // Add new one
            mDbContext.LoginCredentials.Add(loginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
