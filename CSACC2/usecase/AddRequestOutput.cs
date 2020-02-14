using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.usecase
{
    class AddRequestOutput
    {
        public String Employee;
        public String Division;
        public String WorkPlan;
        public String RestPlan;
        public AddRequestOutput(String employee, String division, String workPlan, String restPlan)
        {
            this.Employee = employee;
            this.Division = division;
            this.WorkPlan = workPlan;
            this.RestPlan = restPlan;
        }
        public override string ToString()
        {
            return $"request( employee = {Employee}, division = {Division}, work_plan = {WorkPlan}, rest_plan = {RestPlan} )";
        }
    }
}
