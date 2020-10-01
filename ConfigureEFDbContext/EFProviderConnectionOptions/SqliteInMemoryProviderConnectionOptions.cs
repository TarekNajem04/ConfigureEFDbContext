using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace ConfigureEFDbContext
{
    public class SqliteInMemoryProviderConnectionOptions : EntityFrameworkProviderConnectionOptions
    {
        private readonly DbConnection _connection;

        public SqliteInMemoryProviderConnectionOptions() => _connection = new SqliteConnection("Data Source=:memory:;Cache=Shared;");
        public override bool UseConnectionString => false;

        public override DbConnection GetConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }

        protected override void Dispose(bool disposing)
        {
            _connection.Dispose();
            base.Dispose(disposing);
        }
    }
}
