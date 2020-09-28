using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class IsogramTest
    {
        private Isogram _isogram;

        [TestInitialize]
        public void TestInit()
        {
            _isogram = new Isogram();
        }

        [TestMethod]
        public void IsIsogram()
        {
            _isogram.IsIsogram("Dermatoglyphics").Should().BeTrue();
            _isogram.IsIsogram("aba").Should().BeFalse();
            _isogram.IsIsogram("moOse").Should().BeFalse();
        }

        [TestMethod]
        public void IsIsogram2()
        {
            _isogram.IsIsogram2("Dermatoglyphics").Should().BeTrue();
            _isogram.IsIsogram2("aba").Should().BeFalse();
            _isogram.IsIsogram2("moOse").Should().BeFalse();
        }
    }
}