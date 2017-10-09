using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Runtime.CompilerServices;
using IMS.Domain.Entities;
using IMS.Infrastructure.Crosscutting.Core;

namespace IMS.Infrastructure.Data.Context
{
    public class ImsDbContext : DbContext, IImsDbContext
    {
        public ImsDbContext(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider.GetConnectionString())
        {
            // This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}