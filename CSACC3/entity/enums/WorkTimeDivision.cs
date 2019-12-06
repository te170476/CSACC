using System.Collections.Generic;
using System.ComponentModel;

namespace CSACC3.document.enums
{
    enum WorkTimeDivision
    {
        [Description("午前")] AM = 1
       ,[Description("午後")] PM = 2
       ,[Description("１日")] DAY = AM + PM
    }
    class WorkTimeDivisionUtil
    {
        public static WorkTimeDivision[] GetDevided(WorkTimeDivision division)
        {
            if (division == WorkTimeDivision.DAY)
                return new WorkTimeDivision[]
                        {WorkTimeDivision.AM
                        ,WorkTimeDivision.PM};
            else
                return new WorkTimeDivision[]
                        {division};
        }
    }
}
