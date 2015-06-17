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
            Assert.IsInstanceOf<None<string>>(x.ToOption());
        }

        [Test]
        public void SomethingToOptionShouldBeSome()
        {
            var something = "something";
            Assert.IsInstanceOf<Some<string>>(something.ToOption());
        }

        [Test]
        public void SomeShouldReturnItsValue()
        {
            var something = new Some<string>("something");
            Assert.AreEqual("something", something.Return());
        }

        [Test]
        public void NoneOfReferenceTypeShouldReturnDefaultValue()
        {
            var nothing = None<string>.Instance;
            Assert.Null(nothing.Return());
        }

        [Test]
        public void NoneOfPrimitiveTypeShouldReturnDefaultValue()
        {
            var nothing = None<int>.Instance;
            Assert.AreEqual(0, nothing.Return());
        }

        [Test]
        public void NoneShouldBindToNone()
        {
            var nothing = None<int>.Instance;
            Assert.IsInstanceOf<None<int>>(nothing.Bind(x => (x + 1).ToOption()));
        }

        [Test]
        public void SomeShouldBind()
        {
            var something = 1.ToOption();
            Assert.AreEqual("1", something.Bind(x => x.ToString().ToOption()).Return());
        }

        [Test]
        public void SomeShouldBindCorrectly()
        {
            var something = 1.ToOption();
            Assert.AreEqual(3, something.Bind(x => (x + 2).ToOption()).Return());
        }

        [Test]
        public void NoneToStringShouldReturnNone()
        {
            Assert.AreEqual("[None]", None<string>.Instance.ToString());
        }

        [Test]
        public void SomeToStringShouldReturnStringOfTheValue()
        {
            Assert.AreEqual("1", 1.ToOption().ToString());
        }

        [Test]
        public void NoneShouldNotEqualToNull()
        {
            Assert.AreNotEqual(None<int>.Instance, null);
        }

        [Test]
        public void NoneOfTheSamePrimitivesShouldEqual()
        {
            Assert.AreEqual(None<int>.Instance, None<int>.Instance);
        }

        [Test]
        public void NonesOfTheSameStructsShouldEqual()
        {
            Assert.AreEqual(None<DateTime>.Instance, None<DateTime>.Instance);
        }

        [Test]
        public void SomeShouldNotEqualToNull()
        {
            Assert.AreNotEqual(new Some<int>(1), null);
        }

        [Test]
        public void SomeShoudlEqualSomeWhenPrimitiveValuesAreEqual()
        {
            Assert.AreEqual(new Some<int>(1), new Some<int>(1));
        }

        [Test]
        public void SomeShoudlEqualSomeWhenStructValuesAreEqual()
        {
            Assert.AreEqual(new Some<DateTime>(new DateTime(2015, 6, 17)), new Some<DateTime>(new DateTime(2015, 6, 17)));
        }

        [Test]
        public void SomeShouldNotEqualSomeWhenValuesAreNotEqual()
        {
            Assert.AreNotEqual(new Some<int>(1), new Some<int>(2));
        }

        [Test]
        public void SomeShouldEqualSomeWhenValueReferencesAreSame()
        {
            var x = "test";
            Assert.AreEqual(new Some<string>(x), new Some<string>(x));
        }

        [Test]
        public void SomeShouldNotEqualToNone()
        {
            Assert.AreNotEqual(1.ToOption(), None<int>.Instance);
        }

        [Test]
        public void SameOptionValuesShouldBeEqual()
        {
            Assert.AreEqual(1.ToOption(), 1.ToOption());
        }

        [Test]
        public void OptionEqualityOperatorShouldReturnTrueForSameOptions()
        {
            Assert.True(1.ToOption() == 1.ToOption());
        }

        [Test]
        public void OptionEqualityOperatorShouldReturnTrueForSomeSameOptions()
        {
            Assert.True(1.ToOption() == new Some<int>(1));
        }

        [Test]
        public void OptionInequalityOperatorShouldReturnTrueForDifferentOptions()
        {
            Assert.True(1.ToOption() != 2.ToOption());
        }

        [Test]
        public void NoneOfSameTypeShouldEqual()
        {
            Assert.True(None<int>.Instance == None<int>.Instance);
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
            Assert.IsInstanceOf<None<int>>(x.ToOption());
        }

    }
}
