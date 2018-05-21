using Dna;
using Messenger.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Relational
{

    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction UseClientDataStore(this FrameworkConstruction construction)
        {
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            });

            construction.Services.AddScoped<IClientDataStore>(
                provider => new ClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            // Return framework for chaining
            return construction;
        }
    }
}