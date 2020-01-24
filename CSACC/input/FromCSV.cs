using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.input.FromCSV
{
    public class CsvReader
    {
        public List<CsvLine> read(String path)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.Default);
            var csvLines
                = lines.Skip(1)
                    .Select(line =>
                    {
                        var columns = line.Split(',');
                        return new CsvLine(columns);
                    });
            return csvLines.ToList();
        }
    }
    public class CsvLine
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

        public CsvLine(String[] cells)
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
    }
}
