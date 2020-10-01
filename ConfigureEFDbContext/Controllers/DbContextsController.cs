using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ConfigureEFDbContext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbContextsController : ControllerBase
    {
        private readonly IDbContext_1 _dbContext_1;
        private readonly IDbContext_2 _dbContext_2;
        private readonly IDbContext_3 _dbContext_3;

        public DbContextsController(IDbContext_1 dbContext_1, IDbContext_2 dbContext_2, IDbContext_3 dbContext_3)
        {
            _dbContext_1 = dbContext_1;
            _dbContext_2 = dbContext_2;
            _dbContext_3 = dbContext_3;
        }

        [HttpGet]
        public IEnumerable<string> Get() => new[] {
            _dbContext_1.Database.ProviderName,
            _dbContext_2.Database.ProviderName,
            _dbContext_3.Database.ProviderName
        };
    }
}
