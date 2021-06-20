using DataStructures.ArraySearching;
using DataStructures.ArraySorting;
using DataStructuresTest.ArraySorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.ArraySearching
{
    [TestClass]
    public class ArraySearchTests
    {
        [TestMethod]
        public void LinearSearchTest()
        {
            // Arrange
            var data = ArrayHelpers.CreateUnsortedArray();
            var searchAlgorithm = new ArraySearch();

            // Act
            var result = searchAlgorithm.LinearSearch(data, 9);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            // Arrange
            var data = ArrayHelpers.CreateUnsortedArray();
            var sortAlgorithm = new QuickSort<int>();
            var searchAlgorithm = new ArraySearch();
            data = sortAlgorithm.Sort(data);

            // Act
            var result = searchAlgorithm.BinarySearch(data, 9);

            // Assert
            result.Should().BeTrue();
        }
    }
}