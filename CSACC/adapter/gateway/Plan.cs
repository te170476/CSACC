using com.github.tcc170476.CSACC.SQLOperator;
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
            var builder = new SQLBuilder.Insert(TableName)
                .Add("requester", requester )
                .Add("date"     , date      )
                .Add("time"     , time      )
                .Add("action"   , action    );
            if (restplanId != "")
                builder.Add("restplan_id", restplanId);

            var command = builder.Build(Connection);
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
            , int id
            , String date
            , String time
            )
        {
            var command = new SQLBuilder.Update(TableName)
                .Set("date", date)
                .Set("time", time)
                .Where(new Equal("id", id))
                .Build(Connection);
            command.Transaction = transaction;
            try {
                command.ExecuteNonQuery();
                return new Success();
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
                return new Failure();
            }
        }
        public Result Delete(OleDbTransaction transaction, int id)
        {
            var command = new SQLBuilder.Delete(TableName)
                .Where(new Equal("id", id))
                .Build(Connection);
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
                var result = command.ExecuteScalar();
                if(result != null)
                    return new Some<int>(int.Parse(result.ToString()));
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
            }
            return new None<int>();
        }
        public Option<int> SelectRestPlanId(OleDbTransaction transaction, int id)
        {
            var orderText
                = $"SELECT restplan_id "
                + $"FROM {TableName} "
                + $"WHERE `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            try {
                var result = command.ExecuteScalar();
                if (result != null)
                    return new Some<int>(int.Parse(result.ToString()));
            } catch (OleDbException e) {
                Console.WriteLine(e.StackTrace);
            }
            return new None<int>();
        }
    }
}
