using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.usecase
{
    class AddRequestInput
    {
        public String Employee;
        public String Division;
        public String WorkPlan;
        public String RestPlan;
        public AddRequestInput(String employee, String division, String workPlan, String restPlan)
        {
            this.Employee = employee;
            this.Division = division;
            this.WorkPlan = workPlan;
            this.RestPlan = restPlan;
        }
    }
}
