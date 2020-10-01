using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext.Options
{
    public static class EntityFrameworkProviders
    {
        public static string SqlServer = "SQL-SERVER";
        public static string SQLite = "SQLITE";
        public static string InMemor = "IN-MEMOR";
    }

    /*
     * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options
     * Options pattern in ASP.NET Core
     * The options pattern uses classes to represent groups of related settings.
     * When configuration settings are isolated by scenario into separate classes,
     * the app adheres to two important software engineering principles:

     *  • The Interface Segregation Principle (ISP) or Encapsulation – Scenarios (classes) that depend on configuration settings depend only on the configuration settings that they use.
     *  • Separation of Concerns – Settings for different parts of the app aren't dependent or coupled to one another.
     * Options also provide a mechanism to validate configuration data.
     */
    public class EntityFrameworkOptions : IOptions<EntityFrameworkOptions>
    {
        public const string KEY_NAME = "EntityFrameworkOptions";
        public EntityFrameworkOptions() : this(EntityFrameworkProviders.SqlServer, true) { }
        public EntityFrameworkOptions(string provider, bool canMigrate)
        {
            Provider = provider;
            CanMigrate = canMigrate;
        }

        public string Provider { get; set; }
        /// <summary>
        /// In some providers, we must not execute migration
        /// </summary>
        public bool CanMigrate { get; set; }

        EntityFrameworkOptions IOptions<EntityFrameworkOptions>.Value => this;
    }
}
