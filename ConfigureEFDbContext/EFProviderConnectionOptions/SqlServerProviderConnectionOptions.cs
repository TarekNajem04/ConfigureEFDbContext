using ConfigureEFDbContext.Options;
using Microsoft.Extensions.Options;

namespace ConfigureEFDbContext
{
    public class SqlServerProviderConnectionOptions : EntityFrameworkProviderConnectionOptions
    {
        private readonly ConnectionStringsOptions _options;

        public SqlServerProviderConnectionOptions(IOptions<ConnectionStringsOptions> options) => _options = options.Value;
        public override bool UseConnectionString => true;

        public override string GetConnectionString() => $"Server={_options.ServerName};Database={_options.DatabaseName};User Id={_options.UserId};Password={_options.Password};MultipleActiveResultSets=True";

        // Or
        //public string GetConnectionString() {
        //    var connectionStringBuilder = new SqlConnectionStringBuilder();
        //    connectionStringBuilder.DataSource = _options.ServerName;
        //    connectionStringBuilder.DataSource = _options.DatabaseName;
        //    connectionStringBuilder.UserID = _options.UserId;
        //    connectionStringBuilder.Password = _options.Password;
        //    connectionStringBuilder.MultipleActiveResultSets = true;

        //    return connectionStringBuilder.ConnectionString;
        //}
    }
}
