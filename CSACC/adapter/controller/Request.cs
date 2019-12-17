using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.controller
{
    abstract class Request
    {
        public String Writer;
        public String Department;
        public String Requester;

        public Request(
             String writer
            ,String department
            ,String requester)
        {
            Writer     = writer;
            Department = department;
            Requester = requester;
        }
    }
    class AddRequest : Request
    {
        public String WorkDate;
        public String WorkTime;
        public String RestDate;
        public String RestTime;

        public AddRequest(
              String writer
            , String department
            , String requester
            , String workDate
            , String workTime
            , String restDate
            , String restTime) : base(writer, department, requester)
        {
            WorkDate = workDate;
            WorkTime = workTime;
            RestDate = restDate;
            RestTime = restTime;
        }
    }
    class UpdateRequest : Request
    {
        public String WorkDate;
        public String WorkTime;
        public String RestDate;
        public String RestTime;

        public UpdateRequest(
              String writer
            , String department
            , String requester
            , String workDate
            , String workTime
            , String restDate
            , String restTime) : base(writer, department, requester)
        {
            WorkDate = workDate;
            WorkTime = workTime;
            RestDate = restDate;
            RestTime = restTime;
        }
    }
    class DeleteRequest : Request
    {
        public String WorkDate;
        public String WorkTime;

        public DeleteRequest(
              String writer
            , String department
            , String requester
            , String workDate
            , String workTime) : base(writer, department, requester)
        {
            WorkDate = workDate;
            WorkTime = workTime;
        }
    }
}
