using CSACC3.document.enums;
using System;
using System.Data.OleDb;
using System.Linq;

namespace CSACC3.document.entity
{
    class WeekdayRestPlan
    {
        public DateTime Date;
        public WorkTimeDivision Time;
        public WeekdayRestPlan(DateTime date, WorkTimeDivision time)
        {
            this.Date = date;
            this.Time = time;
        }

        public override string ToString()
        {
            return $"weekday_rest_plan({Date.ToShortDateString()}, {Time})";
        }
    }
}
