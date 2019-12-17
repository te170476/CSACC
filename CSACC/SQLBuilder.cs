using com.github.tcc170476.CSACC.SQLOperator;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC
{
    public class SQLConverter
    {
        private static SQLConverter instance = new SQLConverter();
        public static SQLConverter Instance { get => instance; }
        private SQLConverter() { }
        public String ToSQLKey(String value)
        {
            return $"`{value}`";
        }
        public String ToSQLValue(int value)
        {
            return $"{value}";
        }
        public String ToSQLValue(String value)
        {
            return $"'{value}'";
        }
        public String ToSQLValue(DateTime value)
        {
            return $"#{value}#";
        }
    }
    public class SQLBuilder
    {
        private static SQLConverter c = SQLConverter.Instance;
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
                var rows   = String.Join(", ", Dictionary.Keys.Select(it=> c.ToSQLKey(it)));
                var values = String.Join(", ", Dictionary.Values);
                var order = $"INSERT INTO {TableName}({rows}) VALUES ({values})";
                return new OleDbCommand(order, connection);
            }
            public Insert Add(String key, int value)
            {
                Dictionary.Add(key, c.ToSQLValue(value));
                return this;
            }
            public Insert Add(String key, String value)
            {
                Dictionary.Add(key, c.ToSQLValue(value));
                return this;
            }
            public Insert Add(String key, DateTime value)
            {
                Dictionary.Add(key, c.ToSQLValue(value));
                return this;
            }
        }
        public class Update
        {
            private String TableName;
            private Dictionary<String, String> SetDictionary = new Dictionary<string, string>();
            private List<ISQLOperation> Operations = new List<ISQLOperation>();
            public Update(String tableName)
            {
                TableName = tableName;
            }
            public OleDbCommand Build(OleDbConnection connection)
            {
                var sets  = String.Join(", ", SetDictionary.Select(it=> $"{c.ToSQLKey(it.Key)} = {it.Value}"));
                var where = String.Join("and", Operations.Select(it => it.ToString()));
                var order = $"UPDATE {TableName} SET {sets} WHERE {where}";
                return new OleDbCommand(order, connection);
            }
            public Update Set(String key, String value)
            {
                SetDictionary.Add(key, c.ToSQLValue(value));
                return this;
            }
            public Update Where(ISQLOperation operation)
            {
                Operations.Add(operation);
                return this;
            }
        }
    }
    namespace SQLOperator
    {
        public interface ISQLOperation { }
        public class Equal: ISQLOperation
        {
            private SQLConverter c = SQLConverter.Instance;
            private String Key;
            private String Value;
            public Equal(String key, String value)
            {
                Key   = key;
                Value = c.ToSQLValue(value);
            }
            public Equal(String key, int value)
            {
                Key   = key;
                Value = c.ToSQLValue(value);
            }
            public Equal(String key, DateTime value)
            {
                Key = key;
                Value = c.ToSQLValue(value);
            }
            public override string ToString()
            {
                return $"{c.ToSQLKey(Key)} = {Value}";
            }
        }
    }
}
