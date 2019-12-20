using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter
{
    interface IView
    {
        void OnSuccessAddRequester(int employeeId);
        void OnFailureAddRequester();
        void OnSuccessGetRequesterId(int employeeId);
        void OnFailureGetRequesterId();
        void OnSuccessAddRequest();
        void OnFailureAddRequest();
        void OnSuccessUpdateRequest();
        void OnFailureUpdateRequest();
        void OnSuccessDeleteRequest();
        void OnFailureDeleteRequest();
    }
}
