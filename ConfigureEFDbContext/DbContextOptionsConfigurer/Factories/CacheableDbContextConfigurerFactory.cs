using ConfigureEFDbContext.Options;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext
{
    public class CacheableDbContextConfigurerFactory : DbContextConfigurerFactory
    {
        protected IDbContextConfigurer _sqlServerConfigurer;
        protected IDbContextConfigurer _sqliteConfigurer;
        protected IDbContextConfigurer _inMemoryConfigurer;

        public CacheableDbContextConfigurerFactory(IOptions<EntityFrameworkOptions> options, IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions) : base(options, dbProviderConnectionOptions) { }

        protected override IDbContextConfigurer CreateSqlServerConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => _sqlServerConfigurer ??= base.CreateSqlServerConfigurer(dbProviderConnectionOptions, migrationsAssembly);
        protected override IDbContextConfigurer CreateSqliteConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => _sqliteConfigurer ??= base.CreateSqliteConfigurer(dbProviderConnectionOptions, migrationsAssembly);
        protected override IDbContextConfigurer CreateInMemoryConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => _inMemoryConfigurer ??= base.CreateInMemoryConfigurer(dbProviderConnectionOptions, migrationsAssembly);
    }
}
