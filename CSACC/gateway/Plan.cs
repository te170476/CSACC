using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.gateway
{
    class Plan
    {
        public class Recode
        {
            public String Requester { get; protected set; }
            public String Date { get; protected set; }
            public String Time { get; protected set; }
            public Recode(
                  String requester
                , String date
                , String time
                )
            {
                Requester = requester;
                Date = date;
                Time = time;
            }
            public override string ToString() { return $"{Requester},{Date},{Time}"; }
        }

        public class Add : Plan
        {
            public Recode Work { get; protected set; }
            public Recode Rest { get; protected set; }
            public Add(Recode work, Recode rest)
            {
                Work = work;
                Rest = rest;
            }
        }
        public class Update : Plan
        {
            public Recode Work { get; protected set; }
            public Recode Rest { get; protected set; }
            public Update(Recode work, Recode rest)
            {
                Work = work;
                Rest = rest;
            }
        }
        public class Delete : Plan
        {
            public Recode Work { get; protected set; }
            public Delete(Recode work)
            {
                Work = work;
            }
        }
    }
    
}
