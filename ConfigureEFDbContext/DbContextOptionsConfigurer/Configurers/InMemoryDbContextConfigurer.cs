using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigureEFDbContext
{
    public class InMemoryDbContextConfigurer : DbContextConfigurer
    {
        public InMemoryDbContextConfigurer(IEntityFrameworkProviderConnectionOptions dbProviderConnectionOptions, string migrationsAssembly) : base(dbProviderConnectionOptions, migrationsAssembly) { }

        public override void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder builder) => builder.UseInMemoryDatabase(DbProviderConnectionOptions.GetConnectionString());
    }
}
