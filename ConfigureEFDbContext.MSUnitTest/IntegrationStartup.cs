using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigureEFDbContext.MSUnitTest
{
    public class IntegrationStartup : Startup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services
               .AddMvc()
               .AddApplicationPart(typeof(Startup).Assembly);
        }

        public IntegrationStartup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment) { }

        /*
         * ***************************************************************************************
         * We have to choose the correct Provider according to the settings that we put in 
         * the configuration 'integration-settings.json' file, Section 'EntityFrameworkOptions'
         * ***************************************************************************************
         */

        // FOR EntityFrameworkProviders.SQLite

        //protected override Startup AddEFProviderConnectionOptions(IServiceCollection services)
        //{
        //    services.AddSingleton<IEntityFrameworkProviderConnectionOptions, SqliteProviderConnectionOptions>();
        //    return this;
        //}

        // FOR EntityFrameworkProviders.SQLite but in memory db.
        //protected override Startup AddEFProviderConnectionOptions(IServiceCollection services)
        //{
        //    services.AddSingleton<IEntityFrameworkProviderConnectionOptions, SqliteInMemoryProviderConnectionOptions>();
        //    return this;
        //}

        // FOR EntityFrameworkProviders.InMemor
        protected override Startup AddEFProviderConnectionOptions(IServiceCollection services)
        {
            services.AddSingleton<IEntityFrameworkProviderConnectionOptions, InMemoryProviderConnectionOptions>();
            return this;
        }
    }
}
