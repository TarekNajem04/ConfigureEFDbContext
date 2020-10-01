using System.Data.Common;
using ConfigureEFDbContext.Common;

namespace ConfigureEFDbContext
{
    public interface IEntityFrameworkProviderConnectionOptions : IDisposableObject
    {
        bool UseConnectionString { get; }
        string GetConnectionString();
        DbConnection GetConnection();
    }
}
