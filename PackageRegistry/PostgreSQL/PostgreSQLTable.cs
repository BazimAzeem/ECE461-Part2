using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Npgsql;

namespace PackageRegistry
{
    public class PostgreSQLTable
    {
        private NpgsqlDataSource dataSource;
        private String name;
        private Dictionary<String, String> schema;
        private List<String> constraints;
        public PostgreSQLTable(NpgsqlDataSource dataSource, String name, Dictionary<String, String> schema, List<String> constraints = null)
        {
            this.dataSource = dataSource;
            this.name = name;
            this.schema = schema;
            this.constraints = constraints;

            this.Create();
        }

        private async void Create()
        {
            String schemaStr = String.Join(", ", this.schema.Select(x => x.Key + " " + x.Value).ToArray());
            if (this.constraints != null)
            {
                String constraintsStr = String.Join(", ", this.constraints);
                schemaStr += ", " + constraintsStr;
            }

            String query = String.Format("CREATE TABLE IF NOT EXISTS {0} ({1})", this.name, schemaStr);
            await using var command = this.dataSource.CreateCommand(query);
            await command.ExecuteNonQueryAsync();
        }

        public async void Select(List<String> columns, Dictionary<String, String> where = null)
        {

        }

        public async Task<int> Insert(Dictionary<String, String> item)
        {
            String columnsStr = String.Join(", ", item.Select(x => x.Key).ToArray());
            String valuesStr = String.Join(", ", item.Select(x => x.Value).ToArray());

            String query = String.Format("INSERT INTO {0} ({1}) VALUES ({2}) RETURNING id", this.name, columnsStr, valuesStr);
            await using var command = this.dataSource.CreateCommand(query);
            object id = await command.ExecuteScalarAsync();

            Console.WriteLine(query);
            if (id == null)
                Console.WriteLine("null");
            else
                Console.WriteLine("not null");

            return (int)id;
        }

        public async void Update(List<String> columns, Dictionary<String, String> where = null)
        {

        }
    }
}