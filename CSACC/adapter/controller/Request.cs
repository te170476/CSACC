using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.adapter.controller
{
    class Request
    {
        public String Writer;
        public String Department;
        public String Division;
        public String Requester;
        public String WorkDate;
        public String WorkTime;
        public String RestDate;
        public String RestTime;

        public Request(
             String writer
            ,String department
            ,String division
            ,String requester
            ,String workDate
            ,String workTime
            ,String restDate
            ,String restTime)
        {
            Writer     = writer;
            Department = department;
            Division  = division;
            Requester = requester;
            WorkDate = workDate;
            WorkTime = workTime;
            RestDate = restDate;
            RestTime = restTime;
        }
    }
}
