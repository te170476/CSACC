using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.gateway
{
    class Plan
    {
        public String Requester { get; protected set; }
        public String Date      { get; protected set; }
        public String Time      { get; protected set; }
        public override string ToString() { return $"{Requester},{Date},{Time}"; }

        public class Work : Plan
        {
            public Rest RestPlan { get; protected set; }
            public Work(
                  String    requester
                , String    date
                , String    time
                , Rest      restPlan
                )
            {
                Requester   = requester;
                Date        = date;
                Time        = time;
                RestPlan    = restPlan;
            }
            public override string ToString() { return $"work,{base.ToString()}|{RestPlan}"; }
        }
        public class Rest : Plan
        {
            public Rest(
                  String requester
                , String date
                , String time
                )
            {
                Requester   = requester;
                Date        = date;
                Time        = time;
            }
            public override string ToString() { return $"rest,{base.ToString()}"; }
        }
    }
}
