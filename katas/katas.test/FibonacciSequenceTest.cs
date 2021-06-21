using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class FibonacciSequenceTest
    {
        private FibonacciSequence _fibonacci;

        [TestInitialize]
        public void TestInit()
        {
            _fibonacci = new FibonacciSequence();
        }

        [TestMethod]
        public void ThirtyRandomTests()
        {
            var rand = new Random();

            for (var i = 0; i < 30; i++)
            {
                var num = rand.Next(1, 30);
                var answer = 1;
                var temp1 = 1;
                var temp2 = 1;
                for (var j = 3; j <= num; j++)
                {
                    answer = temp1 + temp2;
                    temp1 = temp2;
                    temp2 = answer;
                }

                Assert.AreEqual(answer, _fibonacci.Fib(num));
            }
        }

        [TestMethod]
        public void AnotherTest()
        {
            Assert.AreEqual(832040, _fibonacci.Fib(30));
            Assert.AreEqual(610, _fibonacci.Fib(15));
            Assert.AreEqual(6765, _fibonacci.Fib(20));
        }

        [TestMethod]
        public void MyTest()
        {
            Assert.AreEqual(5, _fibonacci.Fib(5));
            Assert.AreEqual(55, _fibonacci.Fib(10));
        }
    }
}