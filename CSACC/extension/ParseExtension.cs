using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.extension
{
    public static class ParseExtension
    {
        public static Option<O> OptionalCast<I, O>(this Option<I> source)
        {
            try
            {
                return source.get().OptionalCast<O>();
            }
            catch (Exception exception)
            {
                return new None<O>();
            }
        }
        public static Option<T> OptionalCast<T>(this Object source)
        {
            try
            {
                return new Some<T>((T)source);
            }
            catch (Exception exception)
            {
                return new None<T>();
            }
            //if(source is T)
            //    return new Some<T>((T)source);
            //return new None<T>();
        }
    }
}
