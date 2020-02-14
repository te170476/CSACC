using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSACC2.cleanarchitecture;
using CSACC2.entity;

namespace CSACC2.usecase
{
    class AddRequest: Interactor<AddRequestInput, AddRequestOutput>
    {
        public AddRequest(OutputBoundary<AddRequestOutput> presenter) : base(presenter) { }
        
        protected override AddRequestOutput Handle(AddRequestInput input)
        {
            var request = new Request(
                 input.Employee
                ,input.Division
                ,input.WorkPlan
                ,input.RestPlan);
            return new AddRequestOutput(
                 input.Employee
                ,input.Division
                ,input.WorkPlan
                ,input.RestPlan);
        }
    }
}
