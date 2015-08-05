using System;
using NUnit.Framework;
using Functional.Option;

namespace Functional.Option.Tests
{
    public class OptionTest
    {
        [Test]
        public void NullToOptionShouldBeNone()
        {
            string x = null;
            Assert.IsTrue(x.ToOption().IsNone);
        }

        [Test]
        public void NullToOptionShouldNotBeSome()
        {
            string x = null;
            Assert.IsFalse(x.ToOption().IsSome);
        }


        [Test]
        public void SomethingToOptionShouldBeSome()
        {
            string something = "something";
            Assert.IsTrue(something.ToOption().IsSome);
            Assert.IsFalse(something.ToOption().IsNone);
        }

        [Test]
        public void SomeShouldReturnItsValue()
        {
            var something = "something".ToOption();
            Assert.AreEqual("something", something.Value);
        }

        [Test]
        public void NullToOptionShouldReturnDefaultValue()
        {
            string nullString = null;
            var nothing = nullString.ToOption();
            Assert.Null(nothing.GetValueOrDefault());
        }

        [Test]
        public void NullToOptionShouldReturnDefaultValue2()
        {
            var nothing = Option.Of<string>(null);
            Assert.Null(nothing.GetValueOrDefault());
        }

        [Test]
        public void NoneShouldBindToNone()
        {
            var none = ((string)null).ToOption();
            Assert.True(none.Bind(x => (x + "abc").ToOption()).IsNone);
        }

        [Test]
        public void NoneShouldBindToNone2()
        {
            var none = Option.Of((string)null);
            Assert.True(none.Bind(x => Option.Of(x + "abc")).IsNone);
        }

        [Test]
        public void NoneShouldBindToNone3()
        {
            var none = Option.None();
            Assert.True(none.Bind(x => Option.Of(x + "abc")).IsNone);
        }


        [Test]
        public void SomeShouldBind()
        {
            var something = 1.ToOption();
            Assert.AreEqual("1", something.Bind(x => x.ToString().ToOption()).Value);
        }

        [Test]
        public void SomeShouldBind2()
        {
            var something = Option.Of(1);
            Assert.AreEqual("1", something.Bind(x => Option.Of(x.ToString())).Value);
        }


        [Test]
        public void SomeShouldBindCorrectly()
        {
            var something = 1.ToOption();
            Assert.AreEqual(3, something.Bind(x => (x + 2).ToOption()).Value);
        }

        [Test]
        public void NoneToStringShouldReturnNoneString()
        {
            Assert.AreEqual("[None]",  ((string)null).ToOption().ToString());
        }

        [Test]
        public void SomeToStringShouldReturnCorrectStringValue()
        {
            Assert.AreEqual("1", 1.ToOption().ToString());
        }

        [Test]
        public void NoneShouldNotEqualToNull()
        {
            Assert.AreNotEqual(((string)null).ToOption(), null);
        }

        [Test]
        public void SomeShouldNotEqualToNull()
        {
            Assert.AreNotEqual(1.ToOption(), null);
        }

        [Test]
        public void SomeShoudlEqualSomeWhenPrimitiveValuesAreEqual()
        {
            Assert.AreEqual(1.ToOption(), 1.ToOption());
        }

        [Test]
        public void SomeShoudlEqualSomeWhenStructValuesAreEqual()
        {
            Assert.AreEqual(new DateTime(2015, 6, 17).ToOption(), new DateTime(2015, 6, 17).ToOption());
        }

        [Test]
        public void SomeShouldNotEqualSomeWhenValuesAreNotEqual()
        {
            Assert.AreNotEqual(1.ToOption(), 2.ToOption());
        }

        [Test]
        public void SomeShouldEqualSomeWhenValueReferencesAreSame()
        {
            var x = "test";
            Assert.AreEqual(x.ToOption(), x.ToOption());
        }

        [Test]
        public void SomeShouldNotEqualToNone()
        {
            Assert.AreNotEqual("".ToOption(), ((string)null).ToOption());
        }

        [Test]
        public void SameOptionValuesShouldBeEqual()
        {
            Assert.AreEqual("".ToOption(), "".ToOption());
        }

        [Test]
        public void OptionEqualityOperatorShouldReturnTrueForPrimitiveSameOptions()
        {
            Assert.True(1.ToOption() == 1.ToOption());
        }

        [Test]
        public void OptionEqualityOperatorShouldReturnTrueForSameOptions()
        {
            Assert.True("a".ToOption() == "a".ToOption());
        }

        [Test]
        public void OptionInequalityOperatorShouldReturnTrueForDifferentOptions()
        {
            Assert.True(1.ToOption() != 2.ToOption());
        }

        [Test]
        public void NoneOfSameTypeShouldEqual()
        {
            Assert.True(((int?)null).ToOption() == ((int?)null).ToOption());
        }

        [Test]
        public void NullableToOptionShouldReturnOptionOfUnderlyingType()
        {
            var x = default(int?);
            Assert.IsInstanceOf<Option<int>>(x.ToOption());
        }

        [Test]
        public void NullableWithValueToOptionShouldReturnSomeValue()
        {
            int? x = 0;
            Assert.AreEqual(0.ToOption(), x.ToOption());
        }

        [Test]
        public void OptionToOptionShouldBeOption()
        {
            var x = 0.ToOption();
            Assert.IsInstanceOf<Option<int>>(x.ToOption());
        }

        [Test]
        public void NullOptionToOptionShouldBeNone()
        {
            Option<int> x = null;
            Assert.IsTrue(x.ToOption().IsNone);
        }

    }
}
