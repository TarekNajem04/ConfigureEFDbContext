using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigureEFDbContext
{
    public abstract class DbContextConfigurer : IDbContextConfigurer
    {
        protected DbContextConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly)
        {
            DbProviderConnectionOptions = dbProviderConnectionOptions;
            MigrationsAssembly = migrationsAssembly;
        }

        public IEntityFrameworkProviderConnectionOptions DbProviderConnectionOptions { get; }
        public string MigrationsAssembly { get; }

        public abstract void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder builder);
    }
}
