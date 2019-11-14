using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.jc_21.No170476.CSACC.document.entity
{
    class Department
    {
        public String Name;
        public Department(String name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"department( name = {Name} )";
        }

        public int GetId(OleDbConnection connection)
        {
            var order = $"SELECT id FROM department WHERE name = '{Name}'";
            var command = new OleDbCommand(order, connection);
            var orderResult = command.ExecuteScalar();
            if (orderResult == null)
            {
                Insert(connection);
                return GetId(connection);
            }
            return (int)orderResult;
        }
        private void Insert(OleDbConnection connection)
        {
            var insertOrder = new SQLBuilder.Insert("department (name)")
                                            .add(Name)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
        }
    }
}
