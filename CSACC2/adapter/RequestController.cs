using CSACC2.cleanarchitecture;
using CSACC2.usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.adapter
{
    public class RequestController
    {
        InputBoundary<AddRequestInput> add = new AddRequest(new RequestPresenter());
        public void Add(String employee, String division, String workPlan, String restPlan)
        {
            var inputData = new AddRequestInput(employee, division, workPlan, restPlan);
            add.Input(inputData);
        }
    }
}
