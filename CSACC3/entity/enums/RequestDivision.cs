using System.ComponentModel;

namespace CSACC3.document.enums
{
    enum RequestDivision
    {
        [Description("新規")] New    = 0
       ,[Description("更新")] Update = 1
       ,[Description("取り消し")] Delete = 2
    }
}
