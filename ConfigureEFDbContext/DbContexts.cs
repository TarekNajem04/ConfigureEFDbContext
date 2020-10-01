using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConfigureEFDbContext
{
    //  Interface Segregation Principle (ISP) or Encapsulation
    public interface IDbContext
    {
        /// <summary>
        /// Provides access to database related information and operations for this context.
        /// </summary>
        DatabaseFacade Database { get; }
    }

    public interface IDbContext_1 : IDbContext { }
    public interface IDbContext_2 : IDbContext { }
    public interface IDbContext_3 : IDbContext { }

    public class DbContext_1 : DbContext, IDbContext_1
    {
        public DbContext_1(DbContextOptions<DbContext_1> options) : base(options) { }
    }

    public class DbContext_2 : DbContext, IDbContext_2
    {
        public DbContext_2(DbContextOptions<DbContext_2> options) : base(options) { }
    }

    public class DbContext_3 : DbContext, IDbContext_3
    {
        public DbContext_3(DbContextOptions<DbContext_3> options) : base(options) { }
    }
}
