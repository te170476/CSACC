using System;
using jp.jc_21.No170476.CSACC.document.enums;

namespace jp.jc_21.No170476.CSACC.document.entity
{
    class WorkPlan
    {
        public DateTime Date;
        public WorkTimeDivision Time;
        public WorkPlan(DateTime date, WorkTimeDivision time)
        {
            this.Date = date;
            this.Time = time;
        }
    }
}
