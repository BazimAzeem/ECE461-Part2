using System;
using System.Collections.Generic;
using Npgsql;

namespace PackageRegistry
{
    public class PackageRegistryDB : PostgreSQLDatabase
    {
        public PostgreSQLTable packageTable;
        public PackageRegistryDB(bool local = false) :
        base(
            local ? Environment.GetEnvironmentVariable("INSTANCE_UNIX_SOCKET_LOCAL") : Environment.GetEnvironmentVariable("INSTANCE_UNIX_SOCKET"),
            local ? Environment.GetEnvironmentVariable("DB_USER_LOCAL") : Environment.GetEnvironmentVariable("DB_USER"),
            local ? Environment.GetEnvironmentVariable("DB_PASS_LOCAL") : Environment.GetEnvironmentVariable("DB_PASS"),
            local ? Environment.GetEnvironmentVariable("DB_NAME_LOCAL") : Environment.GetEnvironmentVariable("DB_NAME")
        )
        {
            this.packageTable = new PostgreSQLTable(
                this.dataSource,
                "package",
                new Dictionary<string, string> {
                    {"id", "SERIAL PRIMARY KEY"},
                    {"name", "VARCHAR(214)"},
                    {"version_major", "INT"},
                    {"version_minor", "INT"},
                    {"version_patch", "INT"},
                    {"content", "TEXT"},
                    {"url", "TEXT"},
                    {"js_program", "TEXT"},
                    {"ramp_up_score", "FLOAT DEFAULT -1"},
                    {"correctness_score", "FLOAT DEFAULT -1"},
                    {"bus_factor_score", "FLOAT DEFAULT -1"},
                    {"responsive_maintainer_score", "FLOAT DEFAULT -1"},
                    {"license_score FLOAT", "DEFAULT -1"},
                    {"good_pinning_score", "FLOAT DEFAULT -1"},
                    {"pull_request_score", "FLOAT DEFAULT -1"},
                    {"net_score", "FLOAT DEFAULT -1"}
                },
                new List<string> {
                    "CHECK((ramp_up_score >= 0 AND ramp_up_score <= 1) OR ramp_up_score = -1)",
                    "CHECK((correctness_score >= 0 AND correctness_score <= 1) OR correctness_score = -1)",
                    "CHECK((bus_factor_score >= 0 AND bus_factor_score <= 1) OR bus_factor_score = -1)",
                    "CHECK((responsive_maintainer_score >= 0 AND responsive_maintainer_score <= 1) OR responsive_maintainer_score = -1)",
                    "CHECK((license_score >= 0 AND license_score <= 1) OR license_score = -1)",
                    "CHECK((good_pinning_score >= 0 AND good_pinning_score <= 1) OR good_pinning_score = -1)",
                    "CHECK((pull_request_score >= 0 AND pull_request_score <= 1) OR pull_request_score = -1)",
                    "CHECK((net_score >= 0 AND net_score <= 1) OR net_score = -1)",
                    "UNIQUE(name, version_major, version_minor, version_patch)"
                }
            );
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

        // TODO
        // public async Task InsertIntoPackage()
        // {
        //     await using var command = this.dataSource.CreateCommand("INSERT INTO package () VALUES");
        //     await command.ExecuteNonQueryAsync();
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


    }
}