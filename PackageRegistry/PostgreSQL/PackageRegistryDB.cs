using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using PackageRegistry.Models;

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

        public async Task<Package> SelectFromPackage(int id)
        {
            var columns = new List<string> { "id", "name", "version_major", "version_minor", "version_patch", "content", "url", "js_program" };
            var where = new Dictionary<string, string> { { "id", id.ToString() } };
            var rows = await this.packageTable.Select(columns, where);

            Package package = new Package();
            package.Metadata.ID = rows[0]["id"].ToString();
            package.Metadata.Name = rows[0]["name"].ToString();
            package.Metadata.Version = new Version((int)rows[0]["version_major"], (int)rows[0]["version_minor"], (int)rows[0]["version_patch"]).ToString();
            package.Data.Content = rows[0]["content"].ToString();
            package.Data.URL = rows[0]["url"].ToString();
            package.Data.JSProgram = rows[0]["js_program"].ToString();
            return package;
        }

        public async Task<string> SelectURLFromPackage(int id)
        {
            var columns = new List<string> { "url" };
            var where = new Dictionary<string, string> { { "id", id.ToString() } };
            var rows = await this.packageTable.Select(columns, where);

            return rows[0]["url"].ToString();
        }


        public async Task<bool> ExistsInPackageTable(int id)
        {
            var columns = new List<string> { "id" };
            var where = new Dictionary<string, string> { { "id", id.ToString() } };
            var rows = await this.packageTable.Select(columns, where);
            return rows.Count == 0 ? false : true;
        }

        public async Task<bool> ExistsInPackageTable(PackageMetadata metadata)
        {
            var columns = new List<string> { "id" };
            Version version = new Version(metadata.Version);
            var where = new Dictionary<string, string> {
                { "id", metadata.ID},
                { "name", "'"+metadata.Name+"'"},
                {"version_major" , version.Major.ToString()},
                {"version_minor" , version.Minor.ToString()},
                {"version_patch" , version.Patch.ToString()},
            };
            var rows = await this.packageTable.Select(columns, where);
            return rows.Count == 0 ? false : true;
        }


        public async Task<int> InsertIntoPackageTable(Package package)
        {
            Version v = new Version(package.Metadata.Version);

            var item = new Dictionary<string, string> {
            {"name", "'"+package.Metadata.Name+"'"},
            {"version_major", v.Major.ToString()},
            {"version_minor", v.Minor.ToString()},
            {"version_patch", v.Patch.ToString()},
            {"content", "'"+package.Data.Content.Replace("'", "''")+"'"},
            {"url", "'"+package.Data.URL.Replace("'", "''")+"'"},
            {"js_program", "'"+package.Data.JSProgram.Replace("'", "''")+"'"},
        };

            int id = await this.packageTable.Insert(item);
            return id;
        }

        public async Task UpdatePackageTable(int id, PackageData data)
        {
            var set = new Dictionary<string, string> {
                {"content", data.Content},
                {"url", data.URL},
                {"js_program", data.JSProgram}
            };
            var where = new Dictionary<string, string> { { "id", id.ToString() } };
            await this.packageTable.Update(set, where);
        }


        public async Task ResetPackageTable()
        {
            await this.packageTable.Delete();
        }

        public async Task DeleteFromPackageTable(int id)
        {
            var where = new Dictionary<string, string> { { "id", id.ToString() } };
            await this.packageTable.Delete(where);
        }
    }
}