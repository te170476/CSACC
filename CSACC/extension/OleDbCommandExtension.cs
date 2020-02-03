using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.extension
{
    class OleDbExtension
    {
        public static Option<int> SelectIDENTITY(OleDbConnection connection, OleDbTransaction transaction)
        {
            var selectCommand = new OleDbCommand("SELECT @@IDENTITY", connection);
            selectCommand.Transaction = transaction;
            return selectCommand.OptionalExecuteScalar<int>().getOptRight();
        }
    }
    static class OleDbCommandExtension
    {
        public static Either<Exception, int> OptionalExecuteNonQuery(this OleDbCommand self)
        {
            try
            {
                return new Right<Exception, int>(self.ExecuteNonQuery());
            }
            catch (InvalidOperationException exception)
            {
                return new Left<Exception, int>(exception);
            }
        }
        public static Either<Exception, T> OptionalExecuteScalar<T>(this OleDbCommand self)
        {
            try
            {
                return new Right<Exception, T>(self.ExecuteScalar().OptionalCast<T>().get());
            }
            catch (InvalidOperationException exception)
            {
                return new Left<Exception, T>(exception);
            }
        }
    }
}
