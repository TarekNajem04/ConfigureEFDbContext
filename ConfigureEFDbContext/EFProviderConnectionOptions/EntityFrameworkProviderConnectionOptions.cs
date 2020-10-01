using System.Data.Common;
using ConfigureEFDbContext.Common;

namespace ConfigureEFDbContext
{
    public abstract class EntityFrameworkProviderConnectionOptions : DisposableObject, IEntityFrameworkProviderConnectionOptions
    {
        public abstract bool UseConnectionString { get; }

        public virtual DbConnection GetConnection() => null;
        public virtual string GetConnectionString() => null;
    }
}
