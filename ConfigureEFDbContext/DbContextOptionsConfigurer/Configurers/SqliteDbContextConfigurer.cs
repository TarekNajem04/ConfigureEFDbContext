using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigureEFDbContext
{
    public class SqliteDbContextConfigurer : DbContextConfigurer
    {
        public SqliteDbContextConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) : base(dbProviderConnectionOptions, migrationsAssembly) { }

        public override void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder builder)
        {
            if (DbProviderConnectionOptions.UseConnectionString)
            {
                builder.UseSqlite(
                    connectionString: DbProviderConnectionOptions.GetConnectionString(),
                    sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.MigrationsAssembly(MigrationsAssembly)
                );
            }
            else
            {
                builder.UseSqlite(
                    connection: DbProviderConnectionOptions.GetConnection(),
                    sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.MigrationsAssembly(MigrationsAssembly)
                );
            }
        }
    }
}
