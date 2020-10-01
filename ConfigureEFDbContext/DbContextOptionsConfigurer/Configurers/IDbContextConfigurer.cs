using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigureEFDbContext
{
    public interface IDbContextConfigurer
    {
        void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder builder);
    }
}
