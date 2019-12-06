using CSACC3.extensions;
using CSACC3.gateway;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3
{
    class Adapter
    {
        Form1 Form;
        GatewayConnector Gateway;
        public Adapter(Form1 form)
        {
            string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CSDB.accdb";
            OleDbConnection connection = new OleDbConnection(strAccessConn);
            connection.Connect();
            Gateway = new GatewayConnector(connection);
            Form = form;
        }

        public void AddRequest(
              int writer
            , int department
            , int requester
            , DateTime workDate
            , String workTime
            , DateTime restDate
            , String restTime
            )
        {
            Gateway.Request.Insert(
                  new EmployeeId(requester)
                , new RequestDate(workDate)
                , new RequestTime(workTime)
                , new RequestAction("work")
                );
            Gateway.Request.Insert(
                  new EmployeeId(requester)
                , new RequestDate(restDate)
                , new RequestTime(restTime)
                , new RequestAction("rest")
                );
        }
        public void GetWriterIdFromName(String name)
        {
            var ids = Gateway.Employee.Search(new EmployeeName(name));
            Form.SetWriterIds(ids.Select(it => it.ToString()).ToList());
        }
        public void AddWriter(String name)
        {
            var id = Gateway.Employee.Insert(new EmployeeName(name));
            Form.SetWriterIds(new List<String>() { id.ToString() });
        }

        public void GetDepartmentIdFromName(String name)
        {
            var ids = Gateway.Department.Search(new DepartmentName(name));
            Form.SetDepartmentIds(ids.Select(it => it.ToString()).ToList());
        }
        public void AddDepartment(String name)
        {
            var id = Gateway.Department.Insert(new DepartmentName(name));
            Form.SetDepartmentIds(new List<String>() { id.ToString() });
        }


        public void GetRequesterIdFromName(String name)
        {
            var ids = Gateway.Employee.Search(new EmployeeName(name));
            Form.SetRequesterIds(ids.Select(it => it.ToString()).ToList());
        }
        public void AddRequester(String name)
        {
            var id = Gateway.Employee.Insert(new EmployeeName(name));
            Form.SetRequesterIds(new List<String>() { id.ToString() });
        }
    }
    

}
