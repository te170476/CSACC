using System.ComponentModel;

namespace jp.jc_21.No170476.CSACC.document.enums
{
    enum RequestDivision
    {
        [Description("新規")] New    = 0
       ,[Description("更新")] Update = 1
       ,[Description("取り消し")] Delete = 2
    }
}
