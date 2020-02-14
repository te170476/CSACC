using CSACC2.cleanarchitecture;
using CSACC2.usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.adapter
{
    class RequestPresenter : OutputBoundary<AddRequestOutput>
    {
        public void Output(AddRequestOutput output)
        {
            Console.WriteLine(output);
        }
    }
}
