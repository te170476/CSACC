using CSACC3.extensions;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.gateway
{
    class Request
    {
        private String TableName = "request";
        private OleDbConnection Connection;
        public Request(OleDbConnection connection)
        {
            Connection = connection;
        }
        public Option<int> Insert(
              OleDbTransaction transaction
            , EmployeeId requester
            , RequestDate restDate
            , RequestTime restTime
            , RequestAction action
            , int restplanId = 0
            )
        {
            var rows = "requester, `date`, `time`, `action`, `restplan_id`";
            var command = new SQLBuilder.Insert($"{TableName}({rows})")
                .add(requester.Value)
                .add(restDate.Value)
                .add(restTime.Value)
                .add(action.Value)
                .add(restplanId)
                .build(Connection);
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();

                var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
                selectCommand.Transaction = transaction;
                return new Some<int>((int)selectCommand.ExecuteScalar());
            }
            catch (OleDbException)
            {
                return new None<int>();
            }
        }
        public Result Update(
              OleDbTransaction transaction
            , int id
            //, EmployeeId requester
            , RequestDate date
            , RequestTime time
            )
        {
            var orderText =
                  $" UPDATE {TableName}"
                + $" SET    `date` = #{date.Value}#, `time` = '{time.Value}'"
                + $" WHERE  `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                return new Success();
            }
            catch (OleDbException e)
            {
                Console.WriteLine(orderText);
                Console.WriteLine(e.StackTrace);
                return new Failure();
            }
        }
        public Option<int> SelectId(
              OleDbTransaction transaction
            , EmployeeId requester
            , RequestDate date
            , RequestTime time
            )
        {
            var order = $"SELECT `id` FROM {TableName} WHERE requester = {requester.Value} and `date` = #{date.Value}# and `time` = '{time.Value}'";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            var result = command.ExecuteScalar();
            if (result != null)
            {
                return new Some<int>((int)result);
            }
            return new None<int>();
        }
        public Option<int> SelectRestPlanId(OleDbTransaction transaction, int id)
        {
            var order = $"SELECT `restplan_id` FROM {TableName} WHERE `id`={id}";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            var result = command.ExecuteScalar();
            if (result != null)
            {
                return new Some<int>((int)result);
            }
            return new None<int>();
        }
    }
}
