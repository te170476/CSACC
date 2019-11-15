using System;
using System.Data.OleDb;
using jp.jc_21.No170476.CSACC.document.enums;
using jp.jc_21.No170476.CSACC.extensions;
using System.Linq;

namespace jp.jc_21.No170476.CSACC.document.entity
{
    class HolidayWorkPlan : WorkPlan
    {
        public String Remarks;
        public HolidayWorkPlan(DateTime date, WorkTimeDivision time, String remarks) : base(date, time)
        {
            this.Remarks = remarks;
        }

        public override string ToString()
        {
            return $"holiday_work_plan ( date = {Date.ToShortDateString()}, time = {Time}, remarks = {Remarks} )";
        }

        public void Insert(OleDbConnection connection, int requestId)
        {
            var timeStr = Enum<WorkTimeDivision>.DescriptionValueDictionary[Time];
            var insertCommand = new SQLBuilder.Insert("holiday_work_plan (`request_id`, `date`, `time`, `remarks`)")
                                            .add(requestId)
                                            .add(Date)
                                            .add(timeStr)
                                            .add(Remarks)
                                            .build(connection);
            insertCommand.ExecuteNonQuery();
        }


        public static class Factory
        {
            public static HolidayWorkPlan[] GenerateDevided(String _date, String _time, String remarks)
            {
                if (_date == "") return Array.Empty<HolidayWorkPlan>();

                var date = DateTime.Parse(_date);
                var division = Enum<WorkTimeDivision>.DescriptionKeyDictionary[_time];
                var divisions = WorkTimeDivisionUtil.GetDevided(division);
                return divisions.Select(it => new HolidayWorkPlan(date, it, remarks)).ToArray();
            }
        }
    }
}
