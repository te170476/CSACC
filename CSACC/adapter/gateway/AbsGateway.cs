using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.gateway
{
    abstract class AbsGateway
    {
        protected OleDbConnection Connection;
        public AbsGateway(OleDbConnection connection)
        {
            Connection = connection;
        }
    }
}
