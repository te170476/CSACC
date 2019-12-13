using com.github.tcc170476.CSACC.extension;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.gateway
{
    class Connector
    {
        private OleDbConnection Connection;
        public Connector()
        {
            string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CSDB.accdb";
            Connection = new OleDbConnection(strAccessConn);
            Connection.Connect();
        }
        public OleDbTransaction GetTransaction()
        {
            return Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }
    }
}
