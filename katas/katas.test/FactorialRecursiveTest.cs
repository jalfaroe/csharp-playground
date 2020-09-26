using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class FactorialRecursiveTest
    {
        private FactorialRecursive _factorial;

        [TestInitialize]
        public void TestInit()
        {
            _factorial = new FactorialRecursive();
        }

        [TestMethod]
        public void GetFactorial()
        {
            _factorial.GetFactorial(4).Should().Be(24);
            _factorial.GetFactorial(8).Should().Be(40320);
            _factorial.GetFactorial(16).Should().Be(20922789888000);
        }
    }
}