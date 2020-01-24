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
            // TODO:
            //   CsvLine
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
}
