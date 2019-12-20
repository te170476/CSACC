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
        public void AddRequester(String name)
        {
            var transaction = Gateway.GetTransaction();
            var employeeId = Gateway.Employee.Insert(transaction, name);
            if (employeeId.isEmpty()) { failure(); }
            success();

            void success()
            {
                transaction.Commit();
                View.OnSuccessAddRequester(employeeId.get());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureAddRequester();
            }
        }
        public void GetRequesterId(String name)
        {
            var transaction = Gateway.GetTransaction();
            var employeeId = Gateway.Employee.SelectId(transaction, name);
            if (employeeId.isEmpty()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                View.OnSuccessGetRequesterId(employeeId.get());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureGetRequesterId();
            }
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
                View.OnSuccessAddRequest();
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureAddRequest();
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
                View.OnSuccessUpdateRequest();
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureUpdateRequest();
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
                View.OnSuccessDeleteRequest();
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureDeleteRequest();
            }
        }
    }
}
