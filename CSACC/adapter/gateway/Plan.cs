using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.gateway
{
    class Plan: AbsGateway
    {
        private String TableName = "plan";
        public Plan(OleDbConnection connection) : base(connection) { }

        public Option<int> Insert(
              OleDbTransaction transaction
            , String requester
            , String date
            , String time
            , String action
            , String restplanId
            )
        {
            var rows   = "requester, `date`, `time`, `action`, restplan_id";
            var values = $"'{requester}', '{date}', '{time}', '{action}', '{restplanId}'";
            var orderText = $"INSERT INTO {TableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                command.ExecuteNonQuery();

                var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
                selectCommand.Transaction = transaction;
                var result = (int)selectCommand.ExecuteScalar();
                return new Some<int>(result);
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new None<int>();
            }
        }
        public Result Update(
              OleDbTransaction transaction
            , String id
            , String date
            , String time
            )
        {
            var orderText
                = $" UPDATE {TableName}"
                + $" SET    `date` = '{date}', `time` = '{time}'"
                + $" WHERE  `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                command.ExecuteNonQuery();
                return new Success();
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new Failure();
            }
        }
        public Result Delete(
              OleDbTransaction transaction
            , String id
            )
        {
            var orderText
                = $" DELETE FROM {TableName}"
                + $" WHERE  `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                command.ExecuteNonQuery();
                return new Success();
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new Failure();
            }
        }

        public Option<int> SelectId(
              OleDbTransaction transaction
            , String requester
            , String date
            , String time
            )
        {
            var orderText
                = $"SELECT `id` "
                + $"FROM {TableName} "
                + $"WHERE requester = '{requester}' and `date` = '{date}' and `time` = '{time}'";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                var result = int.Parse(command.ExecuteScalar().ToString()); // TODO: Error.
                return new Some<int>(result);
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new None<int>();
            }
        }
        public Option<int> SelectRestPlanId(
              OleDbTransaction transaction
            , String id
            )
        {
            var orderText
                = $"SELECT restplan_id "
                + $"FROM {TableName} "
                + $"WHERE `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                var result = int.Parse(command.ExecuteScalar().ToString());
                return new Some<int>(result);
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new None<int>();
            }
        }
    }
}
