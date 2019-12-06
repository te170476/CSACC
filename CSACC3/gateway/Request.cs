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
        private String TableName = "request_state";
        private OleDbConnection Connection;
        public Request(OleDbConnection connection)
        {
            Connection = connection;
        }
        public void Insert(
              EmployeeId requester
            , RequestDate restDate
            , RequestTime restTime
            , RequestAction action
            )
        {
            var command = new SQLBuilder.Insert(TableName)
                .add(requester.Value)
                .add(restDate.Value)
                .add(restTime.Value)
                .add(action.Value)
                .build(Connection);

            command.ExecuteNonQuery();

        }
    }
}
