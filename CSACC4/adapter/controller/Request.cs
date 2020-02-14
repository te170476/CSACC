using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.controller
{
    public class Request
    {
        public abstract class Base
        {
            public String Writer;
            public String Department;
            public String Requester;

            public Base(
                  String writer
                , String department
                , String requester)
            {
                Writer = writer;
                Department = department;
                Requester = requester;
            }
        }

        public class Add : Base
        {
            public String WorkDate;
            public String WorkTime;
            public String RestDate;
            public String RestTime;

            public Add(
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
        public class Update : Base
        {
            public String WorkDate;
            public String WorkTime;
            public String RestDate;
            public String RestTime;

            public Update(
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
        public class Delete : Base
        {
            public String WorkDate;
            public String WorkTime;

            public Delete(
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
}
