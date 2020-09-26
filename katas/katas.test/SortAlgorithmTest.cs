using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class SortAlgorithmTest
    {
        private readonly int[] _array = {90, 60, 50, 80, 70, 100};
        private SortAlgorithm _sortAlgorithm;

        [TestInitialize]
        public void TestInit()
        {
            _sortAlgorithm = new SortAlgorithm();
        }

        [TestMethod]
        public void Bubble()
        {
            _sortAlgorithm.Bubble(_array);
            _array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public void QuickSort()
        {
            _sortAlgorithm.QuickSort(_array);
            _array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public void SortWithNetFramework()
        {
            _sortAlgorithm.SortWithNetFramework(_array);
            _array.Should().BeInAscendingOrder();
        }
    }
}