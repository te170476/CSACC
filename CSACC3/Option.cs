﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3
{
    public interface Option<T>
    {
        T get();
        Boolean isDefined();
        Boolean isEmpty();
    }
    public class Some<T>: Option<T>
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
    public class None<T>: Option<T>
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
}