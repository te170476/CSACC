using com.github.tcc170476.CSACC.adapter.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter
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
        public List<Request> toRequest()
        {

            return new List<Request>()
            {
                
            };
        }
    }
    class Plan
    {
        public Plan(
                  String workDate
                , String workTime
                , String restDate
                , String restTime)
        {

        }
    }
    class FromCSV
    {
        public void add(String path)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.Default);
            foreach (String line in lines)
            {
                var columns = line.Split(',');
                var csvLine = new CSVLine(columns);
                var writerId = csvLine.Writer;

                switch (csvLine.RequestDivision)
                {
                    case "新規":
                        {
                            var request = new Request.Add(
                                  csvLine.Writer
                                , csvLine.Department
                                , csvLine.Requester
                                , csvLine.w
                                , workTimeComboBox.Text
                                , restDatePicker.Text
                                , restTimeComboBox.Text);
                            Adapter.Request(request);
                        }
                        break;
                    case "変更":
                        {
                            var request = new Request.Update(
                                  writerId
                                , departmentId
                                , requesterId
                                , workDatePicker.Text
                                , workTimeComboBox.Text
                                , restDatePicker.Text
                                , restTimeComboBox.Text);
                            Adapter.Request(request);
                        }
                        break;
                    case "取消":
                        {
                            var request = new Request.Delete(
                                  writerId
                                , departmentId
                                , requesterId
                                , workDatePicker.Text
                                , workTimeComboBox.Text);
                            Adapter.Request(request);
                        }
                        break;
                }
            }
        }
    }
}
