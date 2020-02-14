using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.extension
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
    }
}
