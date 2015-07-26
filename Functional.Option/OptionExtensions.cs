using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Option
{
    public static class OptionExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Option<T> value)
        {
            if (value.IsNone)
                return Enumerable.Empty<T>();
            return new[] { value.Value }.AsEnumerable();
        }

        //public static T Return<T>(this Option<T> value, T @default)
        //{
        //    return FromOption(value, @default);
        //}

        //public static IEnumerable<T> Return<T>(this IEnumerable<Option<T>> collection)
        //{
        //    return CatOption(collection);
        //}

        //private static bool IsSome<T>(Option<T> value)
        //{
        //    return value is Some<T>;
        //}

        //private static bool IsNone<T>(Option<T> value)
        //{
        //    return !IsSome(value);
        //}

        //private static T FromOption<T>(Option<T> value, T @default)
        //{
        //    return value.IsSome() ? value.Get() : @default;
        //}

        private static IEnumerable<T> CatOption<T>(this IEnumerable<Option<T>> collection)
        {
            return collection.Where(x => x.IsSome).Select(x => x.Value);
        }
    }
}
