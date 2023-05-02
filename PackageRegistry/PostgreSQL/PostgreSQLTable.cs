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

        private void Create()
        {
            String schemaStr = String.Join(", ", this.schema.Select(x => x.Key + " " + x.Value).ToArray());
            if (this.constraints != null)
            {
                String constraintsStr = String.Join(", ", this.constraints);
                schemaStr += ", " + constraintsStr;
            }

            String query = String.Format("CREATE TABLE IF NOT EXISTS {0} ({1})", this.name, schemaStr);
            using var command = this.dataSource.CreateCommand(query);
            command.ExecuteNonQuery();
        }

        public async Task<List<Dictionary<string, object>>> Select(List<String> columns, Dictionary<String, String> where = null)
        {
            String columnsStr = String.Join(", ", columns);
            String query = String.Format("SELECT {0} FROM {1}", columnsStr, this.name);
            if (where != null)
            {
                String whereStr = String.Join(" AND ", where.Select(x => x.Key + "=" + x.Value).ToArray());
                query += " WHERE " + whereStr;
            }

            using var command = this.dataSource.CreateCommand(query);
            await using var reader = await command.ExecuteReaderAsync();

            // Convert from [val1, val2, val3] to { col1: val1, col2: val2, col3: val3 }
            var rows = new List<Dictionary<string, object>> { };
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object> { };
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(columns[i], reader.GetValue(i));
                }
                rows.Add(row);
            }

            return rows;
        }

        public async Task<int> Insert(Dictionary<String, String> item)
        {
            String columnsStr = String.Join(", ", item.Select(x => x.Key).ToArray());
            String valuesStr = String.Join(", ", item.Select(x => x.Value).ToArray());

            String query = String.Format("INSERT INTO {0} ({1}) VALUES ({2}) RETURNING id", this.name, columnsStr, valuesStr);
            await using var command = this.dataSource.CreateCommand(query);
            object id = await command.ExecuteScalarAsync();

            return (int)id;
        }

        public async void Update(List<String> columns, Dictionary<String, String> where = null)
        {

        }

        public async Task Delete(Dictionary<String, String> where = null)
        {
            String query = String.Format("DELETE FROM {0}", this.name);
            if (where != null)
            {
                String whereStr = String.Join(" AND ", where.Select(x => x.Key + "=" + x.Value).ToArray());
                query += " WHERE " + whereStr;
            }

            using var command = this.dataSource.CreateCommand(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}