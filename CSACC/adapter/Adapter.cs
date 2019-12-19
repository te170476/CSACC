using com.github.tcc170476.CSACC.adapter;
using com.github.tcc170476.CSACC.adapter.controller;
using com.github.tcc170476.CSACC.adapter.gateway;
using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC
{
    class Adapter
    {
        IView View;
        Connector Gateway = new Connector();
        public Adapter(IView view)
        {
            View = view;
        }
        public void Request(AddRequest request)
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
                View.OnAddRequest(new Success());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnAddRequest(new Failure());
            }
        }
        public void Request(UpdateRequest request)
        {
            var transaction = Gateway.GetTransaction();
            var workPlanId = Gateway.Plan.SelectId(
                  transaction
                , request.Requester
                , request.WorkDate
                , request.WorkTime
                );
            if (workPlanId.isEmpty()) { failure(); return; }

            var restPlanId = Gateway.Plan.SelectRestPlanId(transaction, workPlanId.get());
            if (restPlanId.isEmpty()) { failure(); return; }

            var result = Gateway.Plan.Update(
                transaction
              , restPlanId.get()
              , request.RestDate
              , request.RestTime
              );
            if (result.isFailure()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                View.OnUpdateRequest(new Success());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnUpdateRequest(new Failure());
            }
        }
        public void Request(DeleteRequest request)
        {
            var transaction = Gateway.GetTransaction();
            var workPlanId = Gateway.Plan.SelectId(
                  transaction
                , request.Requester
                , request.WorkDate
                , request.WorkTime
                );
            if (workPlanId.isEmpty()) { failure(); return; }

            var restPlanId = Gateway.Plan.SelectRestPlanId(transaction, workPlanId.get());
            if (restPlanId.isEmpty()) { failure(); return; }

            var restPlanDeleteResult = Gateway.Plan.Delete(transaction, restPlanId.get());
            if (restPlanDeleteResult.isFailure()) { failure(); return; }

            var workPlanDeleteResult = Gateway.Plan.Delete(transaction, workPlanId.get());
            if (workPlanDeleteResult.isFailure()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                View.OnDeleteRequest(new Success());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnDeleteRequest(new Failure());
            }
        }
    }
}
