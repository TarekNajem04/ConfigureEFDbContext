using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConfigureEFDbContext.MSUnitTest.Fixtures
{
    public class IntegrationWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder() => WebHost.CreateDefaultBuilder<IntegrationStartup>(null);

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var contentRoot = Helper.GetParentProjectPath();

            builder
                .ConfigureAppConfiguration(config =>
                {
                    var projectDir = Directory.GetCurrentDirectory();
                    var integrationSettingsPath = Path.Combine(projectDir, "integration-settings.json");
                    var integrationConfig = new ConfigurationBuilder()
                            .SetBasePath(contentRoot)
                            .AddJsonFile(integrationSettingsPath, false)
                            .Build();

                    config.AddConfiguration(integrationConfig);
                })
                .UseContentRoot(contentRoot)
                .UseEnvironment("Development")
                .UseStartup<IntegrationStartup>();

            // Here we can also write our own settings
            // this called after the 'ConfigureServices' from the Startup
            // But this is not desirable because we will hide the dependencies and break the Single Responsibility Principle (SRP).
            //builder.ConfigureServices(services => {});
            // Or
            builder.ConfigureTestServices(services =>
            {
                //services
                //   .AddMvc()
                //   .AddApplicationPart(typeof(Startup).Assembly);
            });

            base.ConfigureWebHost(builder);
        }
    }
}