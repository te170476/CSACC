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
        void OnSuccessAddWriter(int writerId);
        void OnFailureAddWriter();
        void OnSuccessGetWriterId(int writerId);
        void OnFailureGetWriterId();
        void OnSuccessAddDepartment(int departmentId);
        void OnFailureAddDepartment();
        void OnSuccessGetDepartmentId(int departmentId);
        void OnFailureGetDepartmentId();
        void OnSuccessAddRequester(int requesterId);
        void OnFailureAddRequester();
        void OnSuccessGetRequesterId(int requesterId);
        void OnFailureGetRequesterId();
        void OnSuccessAddRequest();
        void OnFailureAddRequest();
        void OnSuccessUpdateRequest();
        void OnFailureUpdateRequest();
        void OnSuccessDeleteRequest();
        void OnFailureDeleteRequest();
    }
}
