using CSACC.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.input.FromCSV
{
    public class CSVLine
    {
        public String Writer            { get; private set; }
        public String Department        { get; private set; }
        public String AnswerDateAndTime { get; private set; }
        public String Requester         { get; private set; }
        public String RequestDivision   { get; private set; }
        public String HolidayWorkDate1  { get; private set; }
        public String WorkTimeDivision1 { get; private set; }
        public String Remarks1          { get; private set; }
        public String HolidayWorkDate2  { get; private set; }
        public String WorkTimeDivision2 { get; private set; }
        public String Remarks2          { get; private set; }
        public String WeekdayRestDate1  { get; private set; }
        public String RestTimeDivision1 { get; private set; }
        public String WeekdayRestDate2  { get; private set; }
        public String RestTimeDivision2 { get; private set; }

        public CSVLine(String[] cells)
        {
            Writer              = cells[ 0];
            Department          = cells[ 1];
            AnswerDateAndTime   = cells[ 2];
            Requester           = cells[ 3];
            RequestDivision     = cells[ 4];
            HolidayWorkDate1    = cells[ 5];
            WorkTimeDivision1   = cells[ 6];
            Remarks1            = cells[ 7];
            HolidayWorkDate2    = cells[ 8];
            WorkTimeDivision2   = cells[ 9];
            Remarks2            = cells[10];
            WeekdayRestDate1    = cells[11];
            RestTimeDivision1   = cells[12];
            WeekdayRestDate2    = cells[13];
            RestTimeDivision2   = cells[14];
        }
        public override string ToString()
        {
            return $"{Writer},{Department},{AnswerDateAndTime},{Requester},{RequestDivision}"
                 + $",{HolidayWorkDate1},{WorkTimeDivision1},{Remarks1}"
                 + $",{HolidayWorkDate2},{WorkTimeDivision2},{Remarks2}"
                 + $",{WeekdayRestDate1},{RestTimeDivision1}"
                 + $",{WeekdayRestDate2},{RestTimeDivision2}"
                 ;
        }
        public List<Request> ToRequest()
        {
            var workPlanList = ToPlan(WorkTimeDivision1, HolidayWorkDate1);
            workPlanList.AddRange(ToPlan(WorkTimeDivision2, HolidayWorkDate2));
            var workPlanAmount = workPlanList.Count();

            var restPlanList = ToPlan(RestTimeDivision1, WeekdayRestDate1);
            restPlanList.AddRange(ToPlan(RestTimeDivision2, WeekdayRestDate2));
            var restTimeAmount = restPlanList.Count();

            if (workPlanAmount != restTimeAmount)
                throw new ArgumentException("休日出勤届け出と振替休日届け出の分量が合いません。");
            if (workPlanAmount > 2)
                throw new ArgumentException("一度の届け出において許可されるのは1日分までです。");

            return workPlanList.Zip(restPlanList
                , (work, rest) =>
                    new Request(
                          Requester
                        , work.Date
                        , work.Time
                        , rest.Date
                        , rest.Time)
                ).ToList();
        }
        private List<DateAndTime> ToPlan(String timeDivision, String _date)
        {
            DateTime date;
            var success = DateTime.TryParse(_date, out date);
            if (!success) return new List<DateAndTime>();
            return getWorkTimeDivision(timeDivision).Select(it => new DateAndTime(it, date)).ToList();
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
    }
    public class DateAndTime
    {
        public WorkTimeDivision Time;
        public DateTime Date;
        public DateAndTime(WorkTimeDivision timeDivision, DateTime date)
        {
            Time = timeDivision;
            Date = date;
        }
    }
}
