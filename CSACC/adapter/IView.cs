﻿using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter
{
    interface IView
    {
        void OnAddRequest(Result result);
        void OnUpdateRequest(Result result);
    }
}
