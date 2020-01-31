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
        public Plan FromRequest(Request request)
        {
            if (request is Request.Add)    return FromRequest(request as Request.Add);
            if (request is Request.Update) return FromRequest(request as Request.Update);
            if (request is Request.Delete) return FromRequest(request as Request.Delete);
            throw new Exception(); // TODO: Option<Plan>
        }
        public Plan.Add FromRequest(Request.Add request)
        {
            var workPlan = new Plan.Recode(request.Requester, request.WorkDate.ToShortDateString(), request.WorkTime.ToString());
            var restPlan = new Plan.Recode(request.Requester, request.RestDate.ToShortDateString(), request.RestTime.ToString());
            return new Plan.Add(workPlan, restPlan);
        }
        public Plan.Update FromRequest(Request.Update request)
        {
            var workPlan = new Plan.Recode(request.Requester, request.WorkDate.ToShortDateString(), request.WorkTime.ToString());
            var restPlan = new Plan.Recode(request.Requester, request.RestDate.ToShortDateString(), request.RestTime.ToString());
            return new Plan.Update(workPlan, restPlan);
        }
        public Plan.Delete FromRequest(Request.Delete request)
        {
            var workPlan = new Plan.Recode(request.Requester, request.WorkDate.ToShortDateString(), request.WorkTime.ToString());
            return new Plan.Delete(workPlan);
        }
    }
}
