using System;
using System.Collections.Generic;
using System.Reflection;
using ConfigureEFDbContext.Options;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext
{
    public class DbContextConfigurerFactory : IDbContextConfigurerFactory
    {
        public DbContextConfigurerFactory(IOptions<EntityFrameworkOptions> options, IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions)
        {
            EntityFrameworkOptions = options.Value;
            Factories = new Dictionary<string, Func<string, IDbContextConfigurer>>() {
                {EntityFrameworkProviders.SqlServer, (migrationsAssembly) =>    CreateSqlServerConfigurer(dbProviderConnectionOptions, migrationsAssembly)},
                {EntityFrameworkProviders.SQLite, (migrationsAssembly) =>       CreateSqliteConfigurer(dbProviderConnectionOptions, migrationsAssembly)},
                {EntityFrameworkProviders.InMemor, (migrationsAssembly) =>      CreateInMemoryConfigurer(dbProviderConnectionOptions, migrationsAssembly)},
            };
        }

        protected EntityFrameworkOptions EntityFrameworkOptions { get; }
        protected Dictionary<string, Func<string, IDbContextConfigurer>> Factories { get; }

        public virtual IDbContextConfigurer GetConfigurer(string migrationsAssembly = null) => Factories.ContainsKey(EntityFrameworkOptions.Provider)
            ? Factories[EntityFrameworkOptions.Provider](migrationsAssembly ?? Assembly.GetCallingAssembly().GetName().Name)
            : default;

        protected virtual IDbContextConfigurer CreateSqlServerConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => new SqlServerDbContextConfigurer(dbProviderConnectionOptions, migrationsAssembly);
        protected virtual IDbContextConfigurer CreateSqliteConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => new SqliteDbContextConfigurer(dbProviderConnectionOptions, migrationsAssembly);
        protected virtual IDbContextConfigurer CreateInMemoryConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) => new InMemoryDbContextConfigurer(dbProviderConnectionOptions, migrationsAssembly);
    }
}
