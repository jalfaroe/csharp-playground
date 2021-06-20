using DataStructures.ArraySorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.ArraySorting
{
    [TestClass]
    public class ArraySortTests
    {
        [TestMethod]
        public void BubbleSortTest()
        {
            // Arrange
            var data = ArrayHelpers.CreateUnsortedArray();
            var sortAlgorithm = new BubbleSort<int>();

            // Act
            var result = sortAlgorithm.Sort(data);

            // Assert
            ArrayHelpers.CheckSorted(result).Should().BeTrue();
        }

        [TestMethod]
        public void InsertionSortTests()
        {
            // Arrange
            var data = ArrayHelpers.CreateUnsortedArray();
            var sortAlgorithm = new InsertionSort<int>();

            // Act
            var result = sortAlgorithm.Sort(data);

            // Assert
            ArrayHelpers.CheckSorted(result).Should().BeTrue();
        }

        [TestMethod]
        public void QuickSortTests()
        {
            // Arrange
            var data = ArrayHelpers.CreateUnsortedArray();
            var sortAlgorithm = new QuickSort<int>();

            // Act
            var result = sortAlgorithm.Sort(data);

            // Assert
            ArrayHelpers.CheckSorted(result).Should().BeTrue();
        }
    }
}