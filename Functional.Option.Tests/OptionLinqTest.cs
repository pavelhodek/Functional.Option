using System;
using NUnit.Framework;

namespace Functional.Option.Tests
{
    public class OptionLinqTest
    {
        [Test]
        public void ShouldSupportLinqSelect()
        {
            var query = from a in 1.ToOption()
                        select a.ToString();

            Assert.AreEqual("1", query.Return());
        }

        [Test]
        public void ShouldComposeMoreOptions()
        {
            var query = from a in 1.ToOption()
                        from b in 2.ToOption()
                        select a + b;

            Assert.AreEqual(3, query.Return());
        }

        [Test]
        public void ShouldReturnNoneWhenValueDoesNotMatchFilter()
        {
            var query = from a in 1.ToOption()
                        where a == 0
                        select a;

            Assert.IsInstanceOf<None<int>>(query);
        }

        [Test]
        public void ShouldReturnSomethingWhenItMatchFilter()
        {
            var query = from a in 1.ToOption()
                        where a == 1
                        select a;

            Assert.AreEqual(1, query.Return());
        }
    }
}
