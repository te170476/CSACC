using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.gateway
{
    class GatewayConnector
    {
        private OleDbConnection Connection;
        public Employee Employee;
        public Department Department;
        public Request Request;

        public Log Log;
        public GatewayConnector(OleDbConnection connection)
        {
            Connection = connection;
            Employee = new Employee(connection);
            Department = new Department(connection);
            Request = new Request(connection);

            Log = new Log(connection);
        }
        public OleDbTransaction GetTransaction()
        {
            return Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }
    }
}
