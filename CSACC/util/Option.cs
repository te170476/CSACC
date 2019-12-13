using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.tcc170476.CSACC.util
{
    public interface Option<T>
    {
        T get();
        Boolean isDefined();
        Boolean isEmpty();
    }
    public class Some<T> : Option<T>
    {
        private T Value;
        public Some(T value)
        {
            Value = value;
        }
        public new T get() { return Value; }

        public bool isDefined() { return true; }
        public bool isEmpty() { return !isDefined(); }
    }
    public class None<T> : Option<T>
    {
        private String Message;
        public None(String message = "")
        {
            Message = message;
        }
        public new T get() { throw new MissingFieldException("type None: has not Value."); }
        public bool isDefined() { return false; }
        public bool isEmpty() { return !isDefined(); }
        public String getMessage() { return Message; }
    }

    public interface Result
    {
        Boolean isSucceed();
        Boolean isFailure();
    }
    public class Success : Result
    {
        public bool isSucceed() { return true; }
        public bool isFailure() { return false; }
    }
    public class Failure : Result
    {
        public bool isSucceed() { return false; }
        public bool isFailure() { return true; }
    }
}
