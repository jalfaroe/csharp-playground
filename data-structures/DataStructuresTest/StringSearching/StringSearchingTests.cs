using System.Linq;
using DataStructures.StringSearching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTest.StringSearching
{
    [TestClass]
    public class StringSearchingTests
    {
        [TestMethod]
        public void NaiveStringSearch_SearchForMissingMatch()
        {
            // Arrange
            IStringSearchAlgorithm algorithm = new NaiveStringSearch();
            var toFind = "missing data";
            var toSearch = "this string does not contain the missing string data";

            // Act
            var matches = algorithm.Search(toFind, toSearch).ToArray();

            // Assert
            matches.Should().BeEmpty();
        }

        [TestMethod]
        public void NaiveStringSearch_EmptySourceString()
        {
            // Arrange
            IStringSearchAlgorithm algorithm = new NaiveStringSearch();
            var toFind = string.Empty;
            var toSearch = "this string does not contain the missing string data";

            // Act
            var matches = algorithm.Search(toFind, toSearch).ToArray();

            // Assert
            matches.Should().BeEmpty();
        }


        [TestMethod]
        public void NaiveStringSearch_MultipleMatchesLeadingJunk()
        {
            // Arrange
            IStringSearchAlgorithm algorithm = new NaiveStringSearch();
            var toFind = "found";
            var toSearch = "leadingfoundfound";

            // Act
            var matches = algorithm.Search(toFind, toSearch).ToArray();

            // Assert
            matches.Should().HaveCount(2);
            matches[0].Start.Should().Be(7);
            matches[0].Length.Should().Be(toFind.Length);
            matches[1].Start.Should().Be(12);
            matches[1].Length.Should().Be(toFind.Length);
        }

        [TestMethod]
        public void NaiveStringSearch_MultipleMatchesMiddleString()
        {
            // Arrange
            IStringSearchAlgorithm algorithm = new NaiveStringSearch();
            var toFind = "found";
            var toSearch = "found and found";

            // Act
            var matches = algorithm.Search(toFind, toSearch).ToArray();

            // Assert
            matches.Should().HaveCount(2);
            matches[0].Start.Should().Be(0);
            matches[0].Length.Should().Be(toFind.Length);
            matches[1].Start.Should().Be(10);
            matches[1].Length.Should().Be(toFind.Length);
        }
    }
}