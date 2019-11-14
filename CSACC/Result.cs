using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.jc_21.No170476.CSACC
{
    public class Result
    {
        public String Message = "";
        public Result() { }
        public Result(String message)
        {
            Message = message;
        }
    }
    class Success : Result
    {
        public Success() : base() { }
        public Success(String message) : base(message) { }
    }
    class Failure : Result
    {
        public Failure() : base() { }
        public Failure(String message) : base(message) { }
    }
}
