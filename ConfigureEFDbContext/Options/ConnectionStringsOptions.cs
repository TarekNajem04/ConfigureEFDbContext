using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext.Options
{
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
    public class ConnectionStringsOptions : IOptions<ConnectionStringsOptions>
    {
        public const string KEY_NAME = "ConnectionStringsOptions";
        public ConnectionStringsOptions() : this(null, null, null, null) { }
        public ConnectionStringsOptions(string serverName, string databaseName, string userId, string password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            UserId = userId;
            Password = password;
        }

        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        ConnectionStringsOptions IOptions<ConnectionStringsOptions>.Value => this;
    }
}
