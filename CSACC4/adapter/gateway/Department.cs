using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.gateway
{
    class Department : AbsGateway
    {
        private String TableName = "department";
        public Department(OleDbConnection connection) : base(connection) { }

        public Option<int> Insert(
              OleDbTransaction transaction
            , String name
            )
        {
            var command = new SQLBuilder.Insert(TableName)
                .Add("name", name)
                .Build(Connection);
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();

                var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
                selectCommand.Transaction = transaction;
                var result = (int)selectCommand.ExecuteScalar();
                return new Some<int>(result);
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.StackTrace);
                return new None<int>();
            }
        }
        public Option<int> SelectId(
              OleDbTransaction transaction
            , String name
            )
        {
            var orderText
                = $"SELECT `id` "
                + $"FROM   {TableName} "
                + $"WHERE  `name` = '{name}'";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try
            {
                var result = command.ExecuteScalar();
                if (result != null)
                    return new Some<int>(int.Parse(result.ToString()));
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return new None<int>();
        }
    }
}
