using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Option
{
    public static class Factories
    {
        public static Option<T> ToOption<T>(this T value)
        {
            return ((object)value == null)
                ? None<T>.Instance
                : new Some<T>(value);
        }

        public static Option<T> ToOption<T>(this T? value) where T : struct
        {
            return (value.HasValue)
                ? new Some<T>(value.Value)
                : None<T>.Instance;
        }

        public static Option<T> ToOption<T>(this Option<T> value)
        {
            return value ?? None<T>.Instance;
        }

        public static Option<T> ToOption<T>(this IEnumerable<T> collection)
        {
            //return collection != null 
            //    ? collection.FirstOrDefault().ToOption() 
            //    : None<T>.Instance;

            return collection != null
                ? collection.FirstOrDefault().ToOption()
                : None<T>.Instance;

        }
    }
}
