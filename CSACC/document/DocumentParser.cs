using System;
using System.Collections.Generic;
using System.Linq;
using jp.jc_21.No170476.CSACC.document.entity;
using jp.jc_21.No170476.CSACC.document.enums;
using jp.jc_21.No170476.CSACC.extensions;

namespace jp.jc_21.No170476.CSACC.document
{
    class DocumentParser
    {
        public RequestDocument parse(String[] cells)
        {
            var writerStr     = cells[(int)FormIndex.Writer];
            var writer        = new Employee(writerStr);
            var departmentStr = cells[(int)FormIndex.Department];
            var department    = new Department(departmentStr);
            var answerDateStr = cells[(int)FormIndex.AnswerDateAndTime];
            var answerDate    = DateTime.Parse(answerDateStr);
            var requests = GetRequests(cells);

            return new RequestDocument(writer, department, answerDate, requests);
        }
        private List<Request> GetRequests(String[] cells)
        {
            var requesterStr       = cells[(int)FormIndex.Name];
            var requester          = new Employee(requesterStr);
            var requestDivisionStr = cells[(int)FormIndex.RequestDivision];
            var requestDivision    = Enum<RequestDivision>.DescriptionKeyDictionary[requestDivisionStr];

            var holidayWorkPlan = GetHolidayWorkPlan(cells);
            if (holidayWorkPlan.Count() > 2)
                throw new FormatException("休日出勤日の割り当て総数が過多です。");

            var weekdayRestPlan = GetWeekdayRestPlan(cells);
            if (weekdayRestPlan.Count() != holidayWorkPlan.Count())
                throw new FormatException("休日出勤日に対して、振替休日の分量が一致しません。");

            return Enumerable.Range(0, holidayWorkPlan.Count()).Select(index =>
                        new Request(requester, requestDivision, holidayWorkPlan[index], weekdayRestPlan[index])
                   ).ToList();
        }
        private List<HolidayWorkPlan> GetHolidayWorkPlan(String[] cells)
        {
            String dateStr1 = cells[(int)FormIndex.HolidayWorkDate1];
            String divisionStr1 = cells[(int)FormIndex.WorkTimeDivision1];
            String remarks1 = cells[(int)FormIndex.Remarks1];
            HolidayWorkPlan[] holidayWorkPlan1 = HolidayWorkPlan.Factory.GenerateDevided(dateStr1, divisionStr1, remarks1);
            String dateStr2 = cells[(int)FormIndex.HolidayWorkDate2];
            String divisionStr2 = cells[(int)FormIndex.WorkTimeDivision2];
            String remarks2 = cells[(int)FormIndex.Remarks2];
            HolidayWorkPlan[] holidayWorkPlan2 = HolidayWorkPlan.Factory.GenerateDevided(dateStr2, divisionStr2, remarks2);

            return holidayWorkPlan1.Concat(holidayWorkPlan2).ToList();
        }
        private List<WeekdayRestPlan> GetWeekdayRestPlan(String[] cells)
        {
            String dateStr1 = cells[(int)FormIndex.WeekdayRestDate1];
            String divisionStr1 = cells[(int)FormIndex.RestTimeDivision1];
            WeekdayRestPlan[] weekdayRestPlan1 = WeekdayRestPlan.Factory.GenerateDevided(dateStr1, divisionStr1);
            String dateStr2 = cells[(int)FormIndex.WeekdayRestDate2];
            String divisionStr2 = cells[(int)FormIndex.RestTimeDivision2];
            WeekdayRestPlan[] weekdayRestPlan2 = WeekdayRestPlan.Factory.GenerateDevided(dateStr2, divisionStr2);

            return weekdayRestPlan1.Concat(weekdayRestPlan2).ToList();
        }
    }
}
