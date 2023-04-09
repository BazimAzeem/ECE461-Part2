using System;
using System.Threading.Tasks;
using Npgsql;

namespace PackageRegistry
{
    public class PostgreSQLClient
    {
        private NpgsqlConnectionStringBuilder connectionString;
        private NpgsqlDataSource dataSource;

        public PostgreSQLClient() 
        {
            this.connectionString = getPostgreSqlUnixSocketConnectionString();
            this.dataSource = NpgsqlDataSource.Create(this.connectionString);
        }

        private static NpgsqlConnectionStringBuilder getPostgreSqlUnixSocketConnectionString()
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
                Host = Environment.GetEnvironmentVariable("INSTANCE_UNIX_SOCKET"), // e.g. '/cloudsql/project:region:instance'
                Username = Environment.GetEnvironmentVariable("DB_USER"), // e.g. 'my-db-user
                Password = Environment.GetEnvironmentVariable("DB_PASS"), // e.g. 'my-db-password'
                Database = Environment.GetEnvironmentVariable("DB_NAME"), // e.g. 'my-database'
            };
            connectionString.Pooling = true;
            // Specify additional properties here.

            return connectionString;
        }

        public async Task SelectAllPackages() {
            await using var command = this.dataSource.CreateCommand("SELECT * FROM package");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                object[] row = new object[reader.FieldCount];
                Console.WriteLine(reader.GetValues(row));
                for (int i = 0; i < reader.FieldCount; i++) {
                    Console.WriteLine(row[i]);
                }
            }
        }

        public async Task DeleteAllPackages() {
            await using var command = this.dataSource.CreateCommand("DELETE FROM package");
            await command.ExecuteReaderAsync();
        }
    }
}