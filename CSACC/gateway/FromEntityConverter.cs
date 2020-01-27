using CSACC.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.gateway
{
    class FromEntityConverter
    {
        public Plan.Work FromRequest(Request request)
        {
            var restPlan = new Plan.Rest(request.Requester, request.RestDate.ToShortDateString(), request.RestTime.ToString());
            return new Plan.Work(request.Requester, request.WorkDate.ToShortDateString(), request.WorkTime.ToString(), restPlan);
        }
    }
}
