using CSACC.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.gateway
{
    public class Plan
    {
        public static List<Plan> FromRequest(Request request)
        {
            return new List<Plan>()
                {
                      new Plan.Work(request.Requester, request.WorkDate.ToShortDateString(), request.WorkTime.ToString())
                    , new Plan.Rest(request.Requester, request.RestDate.ToShortDateString(), request.RestTime.ToString())
                };
        }
        private Plan() { }
        public String Requester { get; protected set; }
        public String Date { get; protected set; }
        public String Time { get; protected set; }
        public override string ToString() { return $"{Requester},{Date},{Time}"; }

        public class Work : Plan
        {
            public Work(
                  String requester
                , String date
                , String time
                )
            {
                Requester = requester;
                Date = date;
                Time = time;
            }
            public override string ToString() { return $"work,{base.ToString()}"; }
        }
        public class Rest : Plan
        {
            public Rest(
                  String requester
                , String date
                , String time
                )
            {
                Requester = requester;
                Date = date;
                Time = time;
            }
            public override string ToString() { return $"rest,{base.ToString()}"; }
        }
    }
}
