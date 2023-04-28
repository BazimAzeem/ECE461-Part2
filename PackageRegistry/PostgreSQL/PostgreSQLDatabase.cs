using System;
using Npgsql;

namespace PackageRegistry
{
    public class PostgreSQLDatabase
    {
        private NpgsqlConnectionStringBuilder connectionString;
        NpgsqlDataSource dataSource;

        public PostgreSQLDatabase(string host, string dbUser, string dbPasswd, string dbName)
        {
            this.connectionString = GetPostgreSqlUnixSocketConnectionString(host, dbUser, dbPasswd, dbName);
            this.dataSource = NpgsqlDataSource.Create(this.connectionString);
        }

        private static NpgsqlConnectionStringBuilder GetPostgreSqlUnixSocketConnectionString(string host, string dbUser, string dbPasswd, string dbName)
        {
            // Equivalent connection string:
            // "Server=<INSTANCE_UNIX_SOCKET>;Uid=<DB_USER>;Pwd=<DB_PASS>;Database=<DB_NAME>"
            var connectionString = new NpgsqlConnectionStringBuilder()
            {
                // The Cloud SQL proxy provides encryption between the proxy and instance.
                SslMode = SslMode.Disable,

                // Note: Saving credentials in environment variables is convenient, but not
                // secure - consider a more secure solution such as
                // Cloud Secret Manager (https://cloud.google.com/secret-manager) to help
                // keep secrets safe.
                Host = host, // e.g. '/cloudsql/project:region:instance'
                Username = dbUser, // e.g. 'my-db-user
                Password = dbPasswd, // e.g. 'my-db-password'
                Database = dbName, // e.g. 'my-database'
            };
            connectionString.Pooling = true;
            // Specify additional properties here.

            return connectionString;
        }

    }
}