using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.cleanarchitecture
{
    interface OutputBoundary<OutputType>
    {
        void Output(OutputType output);
    }
}
