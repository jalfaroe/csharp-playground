using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class SearchInOrderedArrayTest
    {
        private readonly int[] _array = {30, 40, 50, 70, 85, 90, 100};
        private SearchInOrderedArray _searchInOrderedArray;

        [TestInitialize]
        public void TestInit()
        {
            _searchInOrderedArray = new SearchInOrderedArray();
        }

        [TestMethod]
        public void BinarySearch()
        {
            _searchInOrderedArray.BinarySearch(_array, 40).Should().Be(1);
            _searchInOrderedArray.BinarySearch(_array, 85).Should().Be(4);
            _searchInOrderedArray.BinarySearch(_array, 90).Should().Be(5);
        }

        [TestMethod]
        public void SearchWithNetFramework()
        {
            _searchInOrderedArray.SearchWithNetFramework(_array, 40).Should().Be(1);
            _searchInOrderedArray.SearchWithNetFramework(_array, 85).Should().Be(4);
            _searchInOrderedArray.SearchWithNetFramework(_array, 90).Should().Be(5);
        }
    }
}