using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC
{
    public class SQLBuilder
    {
        public class Insert
        {
            private String TableName;
            private Dictionary<String, String> Dictionary = new Dictionary<string, string>();
            public Insert(String tableName)
            {
                TableName = tableName;
            }
            public OleDbCommand Build(OleDbConnection connection)
            {
                var rows   = String.Join(", ", Dictionary.Keys.Select(it=> $"`{it}`"));
                var values = String.Join(", ", Dictionary.Values);
                var order = $"INSERT INTO {TableName}({rows}) VALUES ({values})";
                return new OleDbCommand(order, connection);
            }
            public Insert Add(String key, int value)
            {
                Dictionary.Add(key, $"{value}");
                return this;
            }
            public Insert Add(String key, String value)
            {
                Dictionary.Add(key, $"'{value}'");
                return this;
            }
            public Insert Add(String key, DateTime value)
            {
                Dictionary.Add(key, $"#{value}#");
                return this;
            }
        }
    }
}
