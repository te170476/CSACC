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

        public Option<int> AddWriter(String name)
        {
            var transaction = Gateway.GetTransaction();
            var writerId = Gateway.Employee.Insert(transaction, name);
            if (writerId.isEmpty()) { return failure(); }
            return success();

            Option<int> success()
            {
                transaction.Commit();
                View.OnSuccessGetWriterId(writerId.get());
                return new Some<int>(writerId.get());
            }
            Option<int> failure()
            {
                transaction.Rollback();
                View.OnFailureGetWriterId();
                return new None<int>();
            }
        }
        public Option<int> GetWriterId(String name)
        {
            var transaction = Gateway.GetTransaction();
            var writerId = Gateway.Employee.SelectId(transaction, name);
            if (writerId.isEmpty()) { return failure(); }
            return success();

            Option<int> success()
            {
                transaction.Commit();
                View.OnSuccessGetWriterId(writerId.get());
                return new Some<int>(writerId.get());
            }
            Option<int> failure()
            {
                transaction.Rollback();
                View.OnFailureGetWriterId();
                return new None<int>();
            }
        }
        public void AddDepartment(String name)
        {
            var transaction = Gateway.GetTransaction();
            var departmentId = Gateway.Department.Insert(transaction, name);
            if (departmentId.isEmpty()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                View.OnSuccessAddDepartment(departmentId.get());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureAddDepartment();
            }
        }
        public Option<int> GetDepartmentId(String name)
        {
            var transaction = Gateway.GetTransaction();
            var departmentId = Gateway.Department.SelectId(transaction, name);
            if (departmentId.isEmpty()) { return failure(); }
            return success();

            Option<int> success()
            {
                transaction.Commit();
                View.OnSuccessGetDepartmentId(departmentId.get());
                return new Some<int>(departmentId.get());
            }
            Option<int> failure()
            {
                transaction.Rollback();
                View.OnFailureGetDepartmentId();
                return new None<int>();
            }
        }
        public void AddRequester(String name)
        {
            var transaction = Gateway.GetTransaction();
            var requesterId = Gateway.Employee.Insert(transaction, name);
            if (requesterId.isEmpty()) { failure(); return; }
            success();

            void success()
            {
                transaction.Commit();
                View.OnSuccessAddRequester(requesterId.get());
            }
            void failure()
            {
                transaction.Rollback();
                View.OnFailureAddRequester();
            }
        }
        public Option<int> GetRequesterId(String name)
        {
            var transaction = Gateway.GetTransaction();
            var requesterId = Gateway.Employee.SelectId(transaction, name);
            if (requesterId.isEmpty()) { return failure(); }
            return success();

            Option<int> success()
            {
                transaction.Commit();
                View.OnSuccessGetRequesterId(requesterId.get());
                return new Some<int>(requesterId.get());
            }
            Option<int> failure()
            {
                transaction.Rollback();
                View.OnFailureGetRequesterId();
                return new None<int>();
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
