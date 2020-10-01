using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigureEFDbContext
{
    public class SqlServerDbContextConfigurer : DbContextConfigurer
    {
        public SqlServerDbContextConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) : base(dbProviderConnectionOptions, migrationsAssembly) { }

        public override void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder builder)
        {
            if (DbProviderConnectionOptions.UseConnectionString)
            {
                builder.UseSqlServer(
                    connectionString: DbProviderConnectionOptions.GetConnectionString(),
                    sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.MigrationsAssembly(MigrationsAssembly)
                );
            }
            else
            {
                builder.UseSqlServer(
                    connection: DbProviderConnectionOptions.GetConnection(),
                    sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.MigrationsAssembly(MigrationsAssembly)
                );
            }
        }
    }
}
