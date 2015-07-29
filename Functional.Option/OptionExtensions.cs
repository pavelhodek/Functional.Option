using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Option
{
    public static class OptionExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Option<T> option)
        {
            if (option.IsNone)
                return Enumerable.Empty<T>();
            return new[] { option.Value }.AsEnumerable();
        }

        private static IEnumerable<T> CatOption<T>(this IEnumerable<Option<T>> collection)
        {
            return collection.Where(x => x.IsSome).Select(x => x.Value);
        }
    }
}
