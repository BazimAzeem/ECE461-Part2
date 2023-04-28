using System;
using Npgsql;

namespace PackageRegistry
{
    public class PackageRegistryDB : PostgreSQLDatabase
    {

        public PackageRegistryDB() :
        base(
            Environment.GetEnvironmentVariable("INSTANCE_UNIX_SOCKET"),
            Environment.GetEnvironmentVariable("DB_USER"),
            Environment.GetEnvironmentVariable("DB_PASS"),
            Environment.GetEnvironmentVariable("DB_NAME")
        )
        {

        }
        // Select all from package table
        // public async Task SelectFromPackage()
        // {
        //     await using var command = this.dataSource.CreateCommand("SELECT * FROM package");
        //     await using var reader = await command.ExecuteReaderAsync();

        //     // TODO
        //     while (await reader.ReadAsync())
        //     {
        //         object[] row = new object[reader.FieldCount];
        //     }
        // }

        // // Select package with given id
        // // TODO
        // public async Task SelectFromPackage(int id)
        // {
        //     await using var command = this.dataSource.CreateCommand("SELECT * FROM package");
        //     await using var reader = await command.ExecuteReaderAsync();

        //     while (await reader.ReadAsync())
        //     {
        //         object[] row = new object[reader.FieldCount];
        //         Console.WriteLine(reader.GetValues(row));
        //         for (int i = 0; i < reader.FieldCount; i++)
        //         {
        //             Console.WriteLine(row[i]);
        //         }
        //     }
        // }

        // // Delete all from package table
        // public async Task DeleteFromPackage()
        // {
        //     await using var command = this.dataSource.CreateCommand("DELETE FROM package");
        //     await command.ExecuteNonQueryAsync();
        // }

        // // Delete package with given id
        // public async Task DeleteFromPackage(int id)
        // {
        //     var connection = await this.dataSource.OpenConnectionAsync();
        //     await using var command = new NpgsqlCommand("DELETE FROM package WHERE id=($1)", connection)
        //     {
        //         Parameters =
        //         {
        //             new() { Value = id.ToString() },
        //         }
        //     };

        //     await command.ExecuteNonQueryAsync();
        // }

        // // TODO
        // public async Task InsertIntoPackage()
        // {
        //     await using var command = this.dataSource.CreateCommand("INSERT INTO package () VALUES");
        //     await command.ExecuteNonQueryAsync();
        // }

    }
}