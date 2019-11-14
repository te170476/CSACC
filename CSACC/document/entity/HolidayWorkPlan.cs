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
            var insertOrder = new SQLBuilder.Insert("holiday_work_plan (`request_id`, `date`, `time`, `remarks`)")
                                            .add(requestId)
                                            .add(Date)
                                            .add(timeStr)
                                            .add(Remarks)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
            //try / catch => throw new FormatException($"不正な休日出勤届[新規]: 既に存在する申請です。(date = {Date.ToShortDateString()}, time = {Time} )");
        }
        //private int GetId(OleDbConnection connection, RequestDivision requestDivision)
        //{
        //    var result = SelectId(connection);
        //    if (result.isEmpty)
        //        switch(requestDivision)
        //        {
        //            case RequestDivision.New:
        //                Insert(connection);
        //                GetId(connection, requestDivision);
        //                break;
        //            case RequestDivision.Update: throw new InvalidOperationException($"不正な休日出勤届[更新]: 存在しない申請です。(date = {Date.ToShortDateString()}, time = {Time} )");
        //            case RequestDivision.Delete: throw new InvalidOperationException($"不正な休日出勤届[取り消し]: 存在しない申請です。(date = {Date.ToShortDateString()}, time = {Time} )");
        //        }
        //    else
        //        if (requestDivision == RequestDivision.New)
        //            throw new InvalidOperationException($"不正な休日出勤届[新規]: 申請の追加に失敗しました。(date = {Date.ToShortDateString()}, time = {Time} )");
        //    return result.Get;
        //}
        //private Option<int> SelectId(OleDbConnection connection)
        //{
        //    var timeStr = Enum<WorkTimeDivision>.DescriptionValueDictionary[Time];
        //    var order = $"SELECT id FROM holiday_work_plan WHERE date = #{Date.ToShortDateString()}# AND time = '{timeStr}'";
        //    var command = new OleDbCommand(order, connection);
        //    var orderResult = command.ExecuteScalar();
        //    if (orderResult == null)
        //        return new Option<int>();

        //    return new Option<int>((int)orderResult);
        //}


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
