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

        // Select all from package table
        public async Task SelectFromPackage() 
        {
            await using var command = this.dataSource.CreateCommand("SELECT * FROM package");
            await using var reader = await command.ExecuteReaderAsync();

            // TODO
            while (await reader.ReadAsync())
            {
                object[] row = new object[reader.FieldCount];
            }
        }

        // Select package with given id
        // TODO
        public async Task SelectFromPackage(int id) 
        {
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

        // Delete all from package table
        public async Task DeleteFromPackage() 
        {
            await using var command = this.dataSource.CreateCommand("DELETE FROM package");
            await command.ExecuteNonQueryAsync();
        }

        // Delete package with given id
        public async Task DeleteFromPackage(int id) 
        {
            var connection = await this.dataSource.OpenConnectionAsync();
            await using var command = new NpgsqlCommand("DELETE FROM package WHERE id=($1)", connection)
            {
                Parameters =
                {
                    new() { Value = id.ToString() },
                }
            };

            await command.ExecuteNonQueryAsync();
        }

        // TODO
        public async Task InsertIntoPackage() 
        {
            await using var command = this.dataSource.CreateCommand("INSERT INTO package () VALUES");
            await command.ExecuteNonQueryAsync();
        }
    }
}