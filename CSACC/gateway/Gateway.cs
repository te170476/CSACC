using CSACC.extension;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.gateway
{
    class Gateway
    {
        private static String strAccessConn = $"Provider={Config.DbProvider};Data Source={Config.DbSource}";
        private OleDbConnection Connection = new OleDbConnection(strAccessConn);
        public Gateway()
        {
            Connection.Open();
        }

        public Option<int> Apply(Plan plan)
        {
            var transaction = Connection.BeginTransaction();
            Option<int> result = new None<int>();
            if (plan is Plan.Add)    result = Apply(plan as Plan.Add, transaction);
            if (plan is Plan.Update) result = Apply(plan as Plan.Update, transaction);
            if (plan is Plan.Delete) result = Apply(plan as Plan.Delete, transaction);
            transaction.Commit();
            return result;
        }
        public Option<int> Apply(Plan.Add addPlan, OleDbTransaction transaction)
        {
            var restPlanId = InsertRestPlan(transaction, addPlan.Rest);
            if (restPlanId.isEmpty()) return new None<int>();
            return InsertWorkPlan(transaction, addPlan.Work, restPlanId.get());
        }
        public Option<int> Apply(Plan.Update updatePlan, OleDbTransaction transaction)
        {
            var workPlanId = SelectPlanId(transaction, updatePlan.Work);
            if (workPlanId.isEmpty()) return new None<int>();
            var restPlanId = SelectPlanData(transaction, "rest_plan_id", $"`id` = {workPlanId.get()}");
            if (restPlanId.isEmpty()) return new None<int>();
            var updateResult = Update(transaction, restPlanId.get(), updatePlan.Rest);
            if (updateResult.isEmpty()) return new None<int>();
            return workPlanId;
        }
        public Option<int> Apply(Plan.Delete deletePlan, OleDbTransaction transaction)
        {
            var workPlanId = SelectPlanId(transaction, deletePlan.Work);
            if (workPlanId.isEmpty()) return new None<int>();
            var restPlanId = SelectPlanData(transaction, "rest_plan_id", $"`id` = {workPlanId.get()}");
            if (restPlanId.isEmpty()) return new None<int>();
            var workPlanDeleteResult = DeletePlanRecode(transaction, workPlanId.get());
            if (workPlanDeleteResult.isEmpty()) return new None<int>();
            var restPlanDeleteResult = DeletePlanRecode(transaction, restPlanId.get());
            if (restPlanDeleteResult.isEmpty()) return new None<int>();
            return workPlanId;
        }

        private Option<int> InsertWorkPlan(OleDbTransaction transaction, Plan.Recode workPlan, int restPlanId)
        {
            var tableName = "`plan`";
            var rows    = "`requester`, `date`, `time`, `type`, `rest_plan_id`";
            var values  = $"'{workPlan.Requester}', #{workPlan.Date}#, '{workPlan.Time}', 'work', {restPlanId}";
            var order   = $"INSERT INTO {tableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            var result = command.OptionalExecuteNonQuery();
            if (result.isLeft()) return new None<int>();
            return OleDbExtension.SelectIDENTITY(Connection, transaction);
        }
        private Option<int> InsertRestPlan(OleDbTransaction transaction, Plan.Recode restPlan)
        {
            var tableName = "`plan`";
            var rows    = "`requester`, `date`, `time`, `type`";
            var values  = $"'{restPlan.Requester}', #{restPlan.Date}#, '{restPlan.Time}', 'rest'";
            var order   = $"INSERT INTO {tableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            var result = command.OptionalExecuteNonQuery();
            if (result.isLeft()) return new None<int>();
            return OleDbExtension.SelectIDENTITY(Connection, transaction);
        }

        private Option<int> SelectPlanId(OleDbTransaction transaction, Plan.Recode plan)
        {
            var tableName = "`plan`";
            var where = $"`requester` = '{plan.Requester}' and `date` = #{plan.Date}# and `time` = '{plan.Time}'";
            var order = $"SELECT `id` FROM {tableName} WHERE {where}";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            Console.WriteLine(order);
            return command.OptionalExecuteScalar<int>().getOptRight();
        }
        private Option<int> SelectPlanData(OleDbTransaction transaction, String target, String where)
        {
            var tableName = "`plan`";
            var order = $"SELECT `{target}` FROM {tableName} WHERE {where}";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            return command.OptionalExecuteScalar<int>().getOptRight();
        }
        private Option<int> Update(OleDbTransaction transaction, int id, Plan.Recode recode)
        {
            var tableName = "`plan`";
            var orderText =
                  $" UPDATE {tableName}"
                + $" SET    `date` = #{recode.Date}#, `time` = '{recode.Time}'"
                + $" WHERE  `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            return command.OptionalExecuteNonQuery().getOptRight();
        }
        private Option<int> DeletePlanRecode(OleDbTransaction transaction, int id)
        {
            var tableName = "`plan`";
            var orderText =
                  $"DELETE FROM {tableName}"
                + $"WHERE `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            return command.OptionalExecuteNonQuery().getOptRight();
        }
    }
}
