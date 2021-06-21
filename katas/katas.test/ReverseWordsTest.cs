using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class ReverseWordsTest
    {
        private ReverseWords _reverseWords;

        [TestInitialize]
        public void TestInit()
        {
            _reverseWords = new ReverseWords();
        }

        [TestMethod]
        public void ReverseTheWords()
        {
            _reverseWords.ReverseTheWords("the sky is blue").Should().Be("blue is sky the");
            _reverseWords.ReverseTheWords("  hello world  ").Should().Be("world hello");
            _reverseWords.ReverseTheWords("a good   example").Should().Be("example good a");
            _reverseWords.ReverseTheWords("  Bob    Loves  Alice   ").Should().Be("Alice Loves Bob");
        }
    }
}