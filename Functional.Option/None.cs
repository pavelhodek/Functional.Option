using System;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Functional.Option.Tests")]
namespace Functional.Option
{
    internal class None<T> : Option<T>, IEquatable<None<T>>
    {
        private static Option<T> sharedInstance = new None<T>();

        private None()
        {
        }

        internal static Option<T> Instance
        {
            get
            {
                return sharedInstance;
            }
        }


        public override Option<R> Bind<R>(Func<T, Option<R>> func)
        {
            return new None<R>();
        }

        public bool Equals(None<T> other)
        {
            return other != null;
        }

        public override bool Equals(Option<T> other)
        {
            return other is None<T>;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override T Value
        {
            get { throw new ArgumentException(); }
        }

        public override T GetValueOrDefault()
        {
            return default(T);
        }

        public override T GetValueOrElse(T @default)
        {
            return @default;
        }

        public override T GetValueOrElse(Func<T> @default)
        {
            return @default();
        }

        public override bool IsNone
        {
            get { return true; }
        }

        public override bool IsSome
        {
            get { return !IsNone; }
        }


        public override string ToString()
        {
            return "[None]";
        }

    }
}
