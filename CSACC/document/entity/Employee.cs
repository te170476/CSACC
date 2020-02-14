using System;
using System.Data.OleDb;

namespace jp.jc_21.No170476.CSACC.document.entity
{
    class Employee
    {
        public String Name;
        public Employee(String name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"employee( name = {Name} )";
        }

        public int GetId(OleDbConnection connection)
        {
            var order = $"SELECT id FROM employee WHERE name = '{Name}'";
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
            var insertOrder = new SQLBuilder.Insert("employee (name)")
                                            .add(Name)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
        }
    }
}
