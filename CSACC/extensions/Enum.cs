using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace jp.jc_21.No170476.CSACC.extensions
{
    class Enum<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        public static Dictionary<String, T> DescriptionKeyDictionary
        {
            get => DescriptionPair.ToDictionary(it => it.Key, it => it.Value);
        }
        public static Dictionary<T, String> DescriptionValueDictionary
        {
            get => DescriptionPair.ToDictionary(it => it.Value, it => it.Key);
        }
        private static IEnumerable<KeyValuePair<String, T>> DescriptionPair
        {
            get
            {
                var type = typeof(T);
                if (!type.IsEnum) throw new ArgumentException();
                var fields = type.GetFields();
                return fields.Where(field => field.GetCustomAttributes(typeof(DescriptionAttribute), false).Count() != 0)
                            .Select(field => {
                                var description
                                    = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                           .Select(it => (it as DescriptionAttribute).Description)
                                           .FirstOrDefault();
                                return new KeyValuePair<String, T>(description, (T)field.GetRawConstantValue());
                            });
            }
        }
    }
}
