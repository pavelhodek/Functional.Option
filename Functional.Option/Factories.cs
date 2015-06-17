using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Option
{
    public static class Factories
    {
        public static Option<T> ToOption<T>(this T value)
        {
            if (value == null)
                return None<T>.Instance;

            return new Some<T>(value);
        }

        public static Option<T> ToOption<T>(this T? value) where T : struct
        {
            if (value == null)
                return None<T>.Instance;

            return value.Value.ToOption();
        }

        public static Option<T> ToOption<T>(this Option<T> value)
        {
            return value ?? None<T>.Instance;
        }

        public static Option<T> ToOption<T>(this IEnumerable<T> collection)
        {
            if (collection != null && collection.Any())
                return collection.First().ToOption();

            return None<T>.Instance;
        }
    }
}
