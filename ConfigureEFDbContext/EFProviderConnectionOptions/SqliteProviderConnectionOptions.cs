using ConfigureEFDbContext.Options;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext
{
    public class SqliteProviderConnectionOptions : EntityFrameworkProviderConnectionOptions
    {
        private readonly ConnectionStringsOptions _options;

        public SqliteProviderConnectionOptions(IOptions<ConnectionStringsOptions> options) => _options = options.Value;
        public override bool UseConnectionString => true;

        //If _options.InMemory then Data Source=InMemorySample;Mode=Memory;Cache=Shared
        public override string GetConnectionString() => $"Data Source={_options.DatabaseName};Cache=Shared;";
    }
}
