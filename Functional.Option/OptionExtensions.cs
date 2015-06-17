using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Option
{
    public static class OptionExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Option<T> value)
        {
            if (IsNone(value))
                return Enumerable.Empty<T>();
            return new[] { value.Return() }.AsEnumerable();
        }

        public static T Return<T>(this Option<T> value, T @default)
        {
            return FromOption(value, @default);
        }

        public static IEnumerable<T> Return<T>(this IEnumerable<Option<T>> collection)
        {
            return CatOption(collection);
        }

        private static bool IsSome<T>(Option<T> value)
        {
            return value is Some<T>;
        }

        private static bool IsNone<T>(Option<T> value)
        {
            return !IsSome(value);
        }

        private static T FromOption<T>(Option<T> value, T @default)
        {
            return IsSome(value) ? value.Return() : @default;
        }

        private static IEnumerable<T> CatOption<T>(IEnumerable<Option<T>> collection)
        {
            return collection.Where(IsSome).Select(x => x.Return());
        }
    }
}
