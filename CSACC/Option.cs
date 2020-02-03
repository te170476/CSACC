using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC
{
    public class Nothing { }
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
        public T get() { return Value; }

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
        public T get() { throw new MissingFieldException("type None: has not Value."); }
        public bool isDefined() { return false; }
        public bool isEmpty() { return !isDefined(); }
        public String getMessage() { return Message; }
    }

    public interface Either<L, R>
    {
        R getRight();
        L getLeft();
        bool isRight();
        bool isLeft();
    }
    public class Left<L, R> : Either<L, R>
    {
        private L Value;
        public Left(L value)
        {
            Value = value;
        }
        public R getRight() { throw new MissingFieldException("type Left: has not Right."); }
        public L getLeft() { return Value; }
        public bool isRight() { return false; }
        public bool isLeft() { return true; }
    }
    public class Right<L, R> : Either<L, R>
    {
        private R Value;
        public Right(R value)
        {
            Value = value;
        }
        public R getRight() { return Value; }
        public L getLeft() { throw new MissingFieldException("type Right: has not Left."); }
        public bool isRight() { return true; }
        public bool isLeft() { return false; }
    }
}
