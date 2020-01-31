using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.entity
{
    enum RequestDivision
    {
         [Description("新規")] Add    = 1
       , [Description("変更")] Update = 2
       , [Description("取消")] Delete = 3
    }
}
