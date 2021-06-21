using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class AnagramTest
    {
        private Anagram _anagram;

        [TestInitialize]
        public void TestInit()
        {
            _anagram = new Anagram();
        }

        [TestMethod]
        public void IsPalindrome()
        {
            // Arrange
            var input = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
            IList<IList<string>> expectation = new List<IList<string>>
            {
                new List<string> {"bat"},
                new List<string> {"nat", "tan"},
                new List<string> {"ate", "eat", "tea"}
            };

            // Act
            var groupAnagrams = _anagram.GroupAnagrams(input);

            // Assert
            groupAnagrams.Should().BeEquivalentTo(expectation);
        }
    }
}