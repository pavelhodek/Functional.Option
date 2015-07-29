using System;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Functional.Option.Tests")]
namespace Functional.Option
{
    internal class Some<T> : Option<T>, IEquatable<Some<T>>
    {
        readonly T value;

        public Some(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Argument of Some constructor cannot be null.");
            }
            this.value = value;
        }

        public override Option<R> Bind<R>(Func<T, Option<R>> func)
        {
            return func(this.value);
        }

        public bool Equals(Some<T> other)
        {
            return other != null && this.value.Equals(other.value);
        }

        public override bool Equals(Option<T> other)
        {
            return Equals(other as Some<T>);
        }


        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override T Value
        {
            get { return this.value; }
        }

        public override T GetValueOrDefault()
        {
            return this.value;
        }

        public override T GetValueOrElse(T @default)
        {
            return this.value;
        }

        public override T GetValueOrElse(Func<T> @default)
        {
            return this.value;
        }

        public override bool IsNone
        {
            get { return !IsSome; }
        }

        public override bool IsSome
        {
            get { return true; }
        }
    }
}
