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
        public Employee Employee;
        public Department Department;
        public Request Request;
        public GatewayConnector(OleDbConnection connection)
        {
            Employee = new Employee(connection);
            Department = new Department(connection);
            Request = new Request(connection);
        }
    }
}
