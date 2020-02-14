using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.jc_21.No170476.CSACC
{
    public class SQLBuilder
    {
        public class Insert
        {
            String table;
            private List<Object> order = new List<object>();
            public Insert(String table)
            {
                this.table = table;
            }
            public Insert add(String value)
            {
                order.Add($"'{value}'");
                return this;
            }
            public Insert add(int value)
            {
                order.Add(value);
                return this;
            }
            public Insert add(DateTime value)
            {
                order.Add($"#{value}#");
                return this;
            }
            public OleDbCommand build(OleDbConnection connection)
            {
                var orderText = "INSERT INTO " + table + " VALUES (" + orderListToSQL() + ")";
                return new OleDbCommand(orderText, connection);
            }
            private String orderListToSQL()
            {
                var strOrders = order.Select(it =>
                {
                    var str = it.ToString();
                    return str;
                });
                return String.Join(", ", strOrders);
            }
        }
    }
}
