using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC2.cleanarchitecture
{
    abstract class Interactor<InputType, OutputType>: InputBoundary<InputType>
    {
        private OutputBoundary<OutputType> Presenter;
        public Interactor(OutputBoundary<OutputType> presenter)
        {
            Presenter = presenter;
        }
        void InputBoundary<InputType>.Input(InputType data) { Presenter.Output(Handle(data)); }

        protected abstract OutputType Handle(InputType input);

    }
}
