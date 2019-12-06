using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.extensions
{
    public static class OleDbExtensions
    {
        public static Option<OleDbConnection> Connect(this OleDbConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (OleDbException exception)
            {
                return new None<OleDbConnection>("Error: Failed connection. " + exception.Message);
            }
            catch (InvalidOperationException exception) // Already connected.
            {
                return new None<OleDbConnection>("Warning: Already connected. " + exception.Message);
            }
            return new Some<OleDbConnection>(connection);
        }
        public static List<Object> GetValues(this OleDbDataReader reader, Boolean read = true)
        {
            if (read) reader.Read();
            return Enumerable.Range(0, reader.FieldCount)
                             .Select(it => reader.GetValue(it))
                             .Select(it => { Console.WriteLine(it); return it; })
                             .ToList();
        }
        public static List<List<Object>> GetLines(this OleDbDataReader reader)
        {
            var list = new List<List<Object>>();
            while (reader.Read())
            {
                list.Add(reader.GetValues(false));
            }
            return list;
        }
    }
}
