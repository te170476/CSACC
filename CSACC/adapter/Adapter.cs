using com.github.tcc170476.CSACC.adapter;
using com.github.tcc170476.CSACC.adapter.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC
{
    class Adapter
    {
        IView View;
        Connector Gateway = new Connector();
        public Adapter(IView view)
        {
            View = view;
        }
    }
}
