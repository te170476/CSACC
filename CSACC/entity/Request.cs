using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.entity
{
    class Request
    {
        public String           Requester   { get; protected set; }
        public DateTime         WorkDate    { get; protected set; }
        public WorkTimeDivision WorkTime    { get; protected set; }
        public DateTime         RestDate    { get; protected set; }
        public WorkTimeDivision RestTime    { get; protected set; }
        public String           Remarks     { get; protected set; }

        public Request(
              String            requester
            , DateTime          workDate
            , WorkTimeDivision  workTime
            , DateTime          restDate
            , WorkTimeDivision  restTime
            , String            remarks
            )
        {
            Requester   = requester;
            WorkDate    = workDate;
            WorkTime    = workTime;
            RestDate    = restDate;
            RestTime    = restTime;
            Remarks     = remarks;
        }
        public override string ToString()
        {
            return $"{Requester},{WorkDate.ToShortDateString()},{WorkTime}"
                            + $",{RestDate.ToShortDateString()},{RestTime}"
                            + $",{Remarks}";
        }
    }
}
