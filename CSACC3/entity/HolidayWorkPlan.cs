using CSACC3.document.enums;
using System;
using System.Data.OleDb;
using System.Linq;

namespace CSACC3.document.entity
{
    class HolidayWorkPlan
    {
        public DateTime Date;
        public WorkTimeDivision Time;
        public String Remarks;
        public HolidayWorkPlan(DateTime date, WorkTimeDivision time, String remarks)
        {
            this.Date = date;
            this.Time = time;
            this.Remarks = remarks;
        }

        public override string ToString()
        {
            return $"holiday_work_plan ({Date.ToShortDateString()}, {Time}, {Remarks})";
        }
    }
}
