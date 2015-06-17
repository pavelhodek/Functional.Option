using System;

namespace Functional.Option
{
    public static class OptionLinqExtensions
    {
        public static Option<B> Select<A, B>(this Option<A> a, Func<A, B> func)
        {
            return a.Bind(x => func(x).ToOption());
        }

        public static Option<C> SelectMany<A, B, C>(this Option<A> a, Func<A, Option<B>> func, Func<A, B, C> select)
        {
            return a.Bind(aval => func(aval).Bind(bval => select(aval, bval).ToOption()));
        }

        public static Option<T> Where<T>(this Option<T> a, Func<T, bool> predicate)
        {
            return a.Bind(x => predicate(x) ? (Option<T>)a : None<T>.Instance);
        }
    }
}
