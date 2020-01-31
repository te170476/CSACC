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

        public int Apply(Plan plan)
        {
            if (plan is Plan.Add)    return Apply(plan as Plan.Add);
            if (plan is Plan.Update) return Apply(plan as Plan.Update);
            if (plan is Plan.Delete) return Apply(plan as Plan.Delete);
            throw new Exception(); // TODO: Option<int>
        }
        public int Apply(Plan.Add addPlan)
        {
            var transaction = Connection.BeginTransaction();
            var restPlanId = InsertRestPlan(transaction, addPlan.Rest);
            var workPlanId = InsertWorkPlan(transaction, addPlan.Work, restPlanId);
            transaction.Commit();
            return workPlanId;
        }
        public int Apply(Plan.Update updatePlan)
        {
            var transaction = Connection.BeginTransaction();
            var workPlanId = SelectPlanId(transaction, updatePlan.Work);
            var restPlanId = SelectPlanData(transaction, "rest_plan_id", $"`id` = {workPlanId}");
            Update(transaction, restPlanId, updatePlan.Rest);
            transaction.Commit();
            return workPlanId;
        }
        public int Apply(Plan.Delete deletePlan)
        {
            var transaction = Connection.BeginTransaction();
            var workPlanId = SelectPlanId(transaction, deletePlan.Work);
            var restPlanId = SelectPlanData(transaction, "rest_plan_id", $"`id` = {workPlanId}");
            DeletePlanRecode(transaction, workPlanId);
            DeletePlanRecode(transaction, restPlanId);
            transaction.Commit();
            return workPlanId;
        }

        private int InsertWorkPlan(OleDbTransaction transaction, Plan.Recode workPlan, int restPlanId)
        {
            var tableName = "`plan`";
            var rows    = "`requester`, `date`, `time`, `type`, `rest_plan_id`";
            var values  = $"'{workPlan.Requester}', #{workPlan.Date}#, '{workPlan.Time}', 'work', {restPlanId}";
            var order   = $"INSERT INTO {tableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
            selectCommand.Transaction = transaction;
            return (int)selectCommand.ExecuteScalar();
        }
        private int InsertRestPlan(OleDbTransaction transaction, Plan.Recode restPlan)
        {
            var tableName = "`plan`";
            var rows    = "`requester`, `date`, `time`, `type`";
            var values  = $"'{restPlan.Requester}', #{restPlan.Date}#, '{restPlan.Time}', 'rest'";
            var order   = $"INSERT INTO {tableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
            selectCommand.Transaction = transaction;
            return (int)selectCommand.ExecuteScalar();
        }

        private int SelectPlanId(OleDbTransaction transaction, Plan.Recode plan)
        {
            var tableName = "`plan`";
            var where = $"`requester` = '{plan.Requester}' and `date` = #{plan.Date}# and `time` = '{plan.Time}'";
            var order = $"SELECT `id` FROM {tableName} WHERE {where}";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            Console.WriteLine(order);
            return (int)command.ExecuteScalar();
        }
        private int SelectPlanData(OleDbTransaction transaction, String target, String where)
        {
            var tableName = "`plan`";
            var order = $"SELECT `{target}` FROM {tableName} WHERE {where}";
            var command = new OleDbCommand(order, Connection);
            command.Transaction = transaction;
            return (int)command.ExecuteScalar();
        }
        private void Update(OleDbTransaction transaction, int id, Plan.Recode recode)
        {
            var tableName = "`plan`";
            var orderText =
                  $" UPDATE {tableName}"
                + $" SET    `date` = #{recode.Date}#, `time` = '{recode.Time}'"
                + $" WHERE  `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }
        private void DeletePlanRecode(OleDbTransaction transaction, int id)
        {
            var tableName = "`plan`";
            var orderText =
                  $"DELETE FROM {tableName}"
                + $"WHERE `id` = {id}";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }
    }
}
