using System;

namespace Functional.Option
{
    public abstract class Option<T> : IEquatable<Option<T>>
    {
        public abstract Option<R> Bind<R>(Func<T, Option<R>> func);
        public abstract bool Equals(Option<T> other);

        public abstract override int GetHashCode();

        public abstract T Value { get; }
        public abstract T GetValueOrDefault();
        public abstract T GetValueOrElse(T @default);
        public abstract T GetValueOrElse(Func<T> @default);

        public abstract bool IsSome { get; }
        public abstract bool IsNone { get; }

        public override bool Equals(object other)
        {
            return Equals(other as Option<T>);
        }

        public static bool operator ==(Option<T> a, Option<T> b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Option<T> a, Option<T> b)
        {
            return !(a == b);
        }
    }


    public static class Option
    {
        public static Option<T> Of<T>(T value)
        {
            return value.ToOption();
        }

        public static Option<object> None()
        {
            return None<object>.Instance;
        }

        public static Option<T> Some<T>(T value) where T: struct
        {
            return new Some<T>(value);
        }
    }

}
