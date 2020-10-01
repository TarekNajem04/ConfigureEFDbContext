using System.Collections.Generic;
using ConfigureEFDbContext.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsPatternController : ControllerBase
    {
        private readonly EntityFrameworkOptions _entityFrameworkOptions;
        private readonly ConnectionStringsOptions _connectionStringsOptions;

        public OptionsPatternController(IOptions<EntityFrameworkOptions> entityFrameworkOptions, IOptions<ConnectionStringsOptions> connectionStringsOptions)
        {
            _entityFrameworkOptions = entityFrameworkOptions.Value;
            _connectionStringsOptions = connectionStringsOptions.Value;
        }

        [HttpGet]
        public IEnumerable<string> Get() => new[] { _entityFrameworkOptions.Provider, _connectionStringsOptions.DatabaseName };
    }
}
