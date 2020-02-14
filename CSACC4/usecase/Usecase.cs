using com.github.tcc170476.CSACC.adapter.controller;
using com.github.tcc170476.CSACC.adapter.gateway;
using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.usecase
{
    class Usecase
    {
        //IView View;
        Connector Gateway = new Connector();
        //public Usecase(IView view)
        //{
        //    View = view;
        //}
        public void Request(Request.Add request)
        {
            var transaction = Gateway.GetTransaction();
            var restPlanId = Gateway.Plan.Insert(
                  transaction
                , request.Requester
                , request.RestDate
                , request.RestTime
                , "rest"
                , new None<int>()
                );
            if (restPlanId.isEmpty()) { failure(); return; }
            var workPlanId = Gateway.Plan.Insert(
                  transaction
                , request.Requester
                , request.WorkDate
                , request.WorkTime
                , "work"
                , new Some<int>(restPlanId.get())
                );
            if (workPlanId.isEmpty()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                //View.OnSuccessAddRequest();
            }
            void failure()
            {
                transaction.Rollback();
                //View.OnFailureAddRequest();
            }
        }
    }
}
