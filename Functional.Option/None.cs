using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Functional.Option.Tests")]
namespace Functional.Option
{
    internal class None<T> : Option<T>, IEquatable<None<T>>
    {
        private static Option<T> sharedInstance = new None<T>();

        private None()
        {
        }

        public static Option<T> Instance
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

        public override T Return()
        {
            return default(T);
        }

        public override string ToString()
        {
            return "[None]";
        }
    }
}
