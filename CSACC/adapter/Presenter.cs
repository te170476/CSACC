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
    }
    class Presenter : IView
    {
        private Adapter Adapter;
        public Presenter()
        {
            Adapter = new Adapter(this);
        }
        public void InsertCsvLine(CSVLine csvLine)
        {
            Adapter.GetWriterId(    csvLine.Writer      );
            Adapter.GetDepartmentId(csvLine.Department  );
            Adapter.GetRequesterId( csvLine.Requester   );
        }

        public void OnFailureAddWriter() { }
        public void OnFailureGetWriterId() { }
        public void OnFailureAddDepartment() { }
        public void OnFailureGetDepartmentId() { }
        public void OnFailureAddRequester() { }
        public void OnFailureGetRequesterId() { }

        public void OnFailureAddRequest() { }
        public void OnFailureDeleteRequest() { }
        public void OnFailureUpdateRequest() { }



        public void OnSuccessAddWriter(int writerId) { }
        public void OnSuccessGetWriterId(int writerId) { }
        public void OnSuccessAddDepartment(int departmentId) { }
        public void OnSuccessGetDepartmentId(int departmentId) { }
        public void OnSuccessAddRequester(int requesterId) { }
        public void OnSuccessGetRequesterId(int requesterId) { }

        public void OnSuccessAddRequest() { }
        public void OnSuccessDeleteRequest() { }
        public void OnSuccessUpdateRequest() { }
    }
}
