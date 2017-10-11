using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class SumSequenceTest
    {
        private SumSequence _sut;

        [TestInitialize]
        public void TestInit()
        {
            _sut = new SumSequence();
        }
        
        [TestMethod]
        public void GetSumRegularSolution()
        {
            _sut.GetSumRegularSolution(1, 0).Should().Be(1);
            _sut.GetSumRegularSolution(1, 2).Should().Be(3);
            _sut.GetSumRegularSolution(0, 1).Should().Be(1);
            _sut.GetSumRegularSolution(1, 1).Should().Be(1);
            _sut.GetSumRegularSolution(-1, 0).Should().Be(-1);
            _sut.GetSumRegularSolution(-1, 2).Should().Be(2);
        }

        [TestMethod]
        public void GetSumLinqSolution()
        {
            _sut.GetSumLinqSolution(1, 0).Should().Be(1);
            _sut.GetSumLinqSolution(1, 2).Should().Be(3);
            _sut.GetSumLinqSolution(0, 1).Should().Be(1);
            _sut.GetSumLinqSolution(1, 1).Should().Be(1);
            _sut.GetSumLinqSolution(-1, 0).Should().Be(-1);
            _sut.GetSumLinqSolution(-1, 2).Should().Be(2);
        }

        [TestMethod]
        public void GetSumArithmeticSolution()
        {
            _sut.GetSumArithmeticSolution(1, 0).Should().Be(1);
            _sut.GetSumArithmeticSolution(1, 2).Should().Be(3);
            _sut.GetSumArithmeticSolution(0, 1).Should().Be(1);
            _sut.GetSumArithmeticSolution(1, 1).Should().Be(1);
            _sut.GetSumArithmeticSolution(-1, 0).Should().Be(-1);
            _sut.GetSumArithmeticSolution(-1, 2).Should().Be(2);
        }
    }
}