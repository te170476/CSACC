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

        public void Insert(
              OleDbTransaction transaction
            , String requester
            , String date
            , String time
            , String action
            , String restplanId
            )
        {
            var rows = "requester, `date`, `time`, `action`, restplan_id";
            var values = $"'{requester}', '{date}', '{time}', '{action}', '{restplanId}'";
            var orderText = $"INSERT INTO {TableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(orderText, Connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }
    }
}
