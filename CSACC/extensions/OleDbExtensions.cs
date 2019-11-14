using System;
using System.Data.OleDb;
using System.Linq;

namespace jp.jc_21.No170476.CSACC.extensions
{

    static public class OleDbExtensions
    {
        public static Result Connect(this OleDbConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (OleDbException exception)
            {
                return new Failure("Error: Failed connection. " + exception.Message);
            }
            catch (InvalidOperationException exception) // Already connected.
            {
                return new Success("Warning: Already connected. " + exception.Message);
            }
            return new Success();
        }

        public static String[] GetValues(this OleDbDataReader reader)
        {
            return Enumerable.Range(0, reader.FieldCount)
                             .Select(it => reader.GetValue(it).ToString())
                             .ToArray();
        }
    }
}
