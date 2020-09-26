using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class StringReverseTest
    {
        private StringReverse _stringReverse;

        [TestInitialize]
        public void TestInit()
        {
            _stringReverse = new StringReverse();
        }

        [TestMethod]
        public void Reverse()
        {
            _stringReverse.Reverse("Reverse of the string").Should().Be("gnirts eht fo esreveR");
        }
    }
}