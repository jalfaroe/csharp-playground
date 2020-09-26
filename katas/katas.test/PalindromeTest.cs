using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class PalindromeTest
    {
        private Palindrome _palindrome;

        [TestInitialize]
        public void TestInit()
        {
            _palindrome = new Palindrome();
        }

        [TestMethod]
        public void IsPalindrome()
        {
            _palindrome.IsPalindrome("madam").Should().BeTrue();
            _palindrome.IsPalindrome("racecar").Should().BeTrue();
            _palindrome.IsPalindrome("today").Should().BeFalse();
        }
    }
}