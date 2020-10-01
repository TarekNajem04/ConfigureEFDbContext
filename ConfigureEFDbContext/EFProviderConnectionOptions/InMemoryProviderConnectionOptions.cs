using ConfigureEFDbContext.Options;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext
{
    public class InMemoryProviderConnectionOptions : EntityFrameworkProviderConnectionOptions
    {
        private readonly ConnectionStringsOptions _options;

        public InMemoryProviderConnectionOptions(IOptions<ConnectionStringsOptions> options) => _options = options.Value;
        public override bool UseConnectionString => true;

        public override string GetConnectionString() => _options.DatabaseName;
    }
}
