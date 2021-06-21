using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class DistributeCandyTest
    {
        private DistributeCandy _candy;

        [TestInitialize]
        public void TestInit()
        {
            _candy = new DistributeCandy();
        }

        [TestMethod]
        public void Test1()
        {
            var data = new[] {1, 1, 2, 2, 3, 3};

            var result = _candy.DistributeCandies(data);

            result.Should().Be(3);
        }

        [TestMethod]
        public void Test2()
        {
            var data = new[] {1, 1, 2, 3};

            var result = _candy.DistributeCandies(data);

            result.Should().Be(2);
        }

        [TestMethod]
        public void Test3()
        {
            var data = new[] {6, 6, 6, 6};

            var result = _candy.DistributeCandies(data);

            result.Should().Be(1);
        }
    }
}