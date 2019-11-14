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

        //private int GetId(OleDbConnection connection, RequestDivision requestDivision)
        //{
        //    var result = SelectId(connection);
        //    if (result.isEmpty)
        //        switch (requestDivision)
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
        //    var order = $"SELECT id FROM weekday_rest_plan WHERE date = #{Date.ToShortDateString()}# AND time = '{timeStr}'";
        //    Console.WriteLine("order: " + order);
        //    var command = new OleDbCommand(order, connection);
        //    var orderResult = command.ExecuteScalar();
        //    if (orderResult == null)
        //        return new Option<int>();

        //    return new Option<int>((int)orderResult);
        //}




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
