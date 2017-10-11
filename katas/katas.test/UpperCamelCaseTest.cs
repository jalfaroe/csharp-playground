using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace katas.test
{
    [TestClass]
    public class UpperCamelCaseTest
    {
        private UpperCamelCase _upperCamelCase;

        [TestInitialize]
        public void TestInit()
        {
            _upperCamelCase = new UpperCamelCase();
        }

        [TestMethod]
        public void ConvertToUpperCamelCase()
        {
            _upperCamelCase.ConvertToUpperCamelCase("How can mirrors be real if our eyes aren't real")
                .Should().Be("How Can Mirrors Be Real If Our Eyes Aren't Real");
        }
    }
}
