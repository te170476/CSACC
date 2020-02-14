using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.gateway
{
    class Log
    {
        String TableName = "log";
        private OleDbConnection Connection;
        public Log(OleDbConnection connection)
        {
            Connection = connection;
        }
        public int Insert(
              EmployeeId writer
            , DepartmentId department
            , String requestDivision
            , EmployeeId requester
            , RequestDate workDate
            , RequestTime workTime
            , RequestDate restDate
            , RequestTime restTime)
        {
            var x = "writer, department, request_division, requester, workdate, worktime, restdate, resttime";
            var command = new SQLBuilder.Insert($"`{TableName}`({x})")
                .add(writer.Value)
                .add(department.Value)
                .add(requestDivision)
                .add(requester.Value)
                .add(workDate.Value)
                .add(workTime.Value)
                .add(restDate.Value)
                .add(restTime.Value)
                .build(Connection);
            command.ExecuteNonQuery();

            var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
            return (int)selectCommand.ExecuteScalar();
        }
    }
}
