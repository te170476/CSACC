using System;
using System.Data.OleDb;
using jp.jc_21.No170476.CSACC.document.enums;
using jp.jc_21.No170476.CSACC.extensions;
using System.Linq;

namespace jp.jc_21.No170476.CSACC.document.entity
{
    class WeekdayRestPlan : WorkPlan
    {
        public WeekdayRestPlan(DateTime date, WorkTimeDivision time) : base(date, time) { }

        public override string ToString()
        {
            return $"weekday_rest_plan ( date = {Date.ToShortDateString()}, time = {Time} )";
        }

        public void Insert(OleDbConnection connection, int requestId)
        {
            var timeStr = Enum<WorkTimeDivision>.DescriptionValueDictionary[Time];
            var insertOrder = new SQLBuilder.Insert("weekday_rest_plan (`request_id`, `date`, `time`)")
                                            .add(requestId)
                                            .add(Date)
                                            .add(timeStr)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
        }

        public static class Factory
        {
            public static WeekdayRestPlan[] GenerateDevided(String _date, String _time)
            {
                if (_date == "") return Array.Empty<WeekdayRestPlan>();

                var date = DateTime.Parse(_date);
                var division = Enum<WorkTimeDivision>.DescriptionKeyDictionary[_time];
                var divisions = WorkTimeDivisionUtil.GetDevided(division);
                return divisions.Select(it => new WeekdayRestPlan(date, it)).ToArray();
            }
        }
    }
}
