using CSACC.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.input.fromCsv
{
    class ToEntityConverter
    {
        public List<Request> ToRequest(CsvLine csvLine)
        {
            var optRequestDivision = getRequestDivision(csvLine.RequestDivision);
            if(optRequestDivision.isEmpty())
                throw new ArgumentException("不正な申請区分の届出です。");
            var requestDivision = optRequestDivision.get();

            var workPlanList = ToDateAndTime(csvLine.WorkTimeDivision1, csvLine.HolidayWorkDate1, csvLine.Remarks1);
            workPlanList.AddRange(ToDateAndTime(csvLine.WorkTimeDivision2, csvLine.HolidayWorkDate2, csvLine.Remarks2));
            var restPlanList = ToDateAndTime(csvLine.RestTimeDivision1, csvLine.WeekdayRestDate1, csvLine.Remarks1);
            restPlanList.AddRange(ToDateAndTime(csvLine.RestTimeDivision2, csvLine.WeekdayRestDate2, csvLine.Remarks2));

            if (requestDivision != RequestDivision.Delete)
            {
                if (workPlanList.Count() != restPlanList.Count())
                    throw new ArgumentException("休日出勤届け出と振替休日届け出の分量が合いません。");
                if (workPlanList.Count() > 2)
                    throw new ArgumentException("一度の届け出において許可されるのは1日分までです。");
            }

            switch (requestDivision)
            {
                case RequestDivision.Add:
                    return workPlanList.Zip(restPlanList
                        , (work, rest) =>
                        new Request.Add(
                              csvLine.Requester
                            , work.Date
                            , work.Time
                            , rest.Date
                            , rest.Time
                            , work.Remarks)
                        ).ToList<Request>();
                case RequestDivision.Update:
                    return workPlanList.Zip(restPlanList
                        , (work, rest) =>
                        new Request.Update(
                              csvLine.Requester
                            , work.Date
                            , work.Time
                            , rest.Date
                            , rest.Time
                            , work.Remarks)
                        ).ToList<Request>();
                case RequestDivision.Delete:
                    return workPlanList.Select(
                        work =>
                        new Request.Delete(
                              csvLine.Requester
                            , work.Date
                            , work.Time
                            , work.Remarks)
                        ).ToList<Request>();
                default:
                    return new List<Request>();
            }
        }
        private List<DateAndTime> ToDateAndTime(String timeDivision, String _date, String remarks)
        {
            DateTime date;
            var success = DateTime.TryParse(_date, out date);
            if (!success) return new List<DateAndTime>();
            return getWorkTimeDivision(timeDivision).Select(it => new DateAndTime(it, date, remarks)).ToList();
        }
        private Option<RequestDivision> getRequestDivision(String str)
        {
            switch (str)
            {
                case "新規": return new Some<RequestDivision>(RequestDivision.Add);
                case "変更": return new Some<RequestDivision>(RequestDivision.Update);
                case "取消": return new Some<RequestDivision>(RequestDivision.Delete);
                default: return new None<RequestDivision>();
            }
        }
        private List<WorkTimeDivision> getWorkTimeDivision(String str)
        {
            switch (str)
            {
                case "午前": return new List<WorkTimeDivision>() { WorkTimeDivision.AM };
                case "午後": return new List<WorkTimeDivision>() { WorkTimeDivision.PM };
                case "１日": return new List<WorkTimeDivision>() { WorkTimeDivision.AM, WorkTimeDivision.PM };
                default: return new List<WorkTimeDivision>() { };
            }
        }
        private class DateAndTime
        {
            public WorkTimeDivision Time;
            public DateTime         Date;
            public String           Remarks;
            public DateAndTime(WorkTimeDivision timeDivision, DateTime date, String remarks)
            {
                Time    = timeDivision;
                Date    = date;
                Remarks = remarks;
            }
        }
    }
}
