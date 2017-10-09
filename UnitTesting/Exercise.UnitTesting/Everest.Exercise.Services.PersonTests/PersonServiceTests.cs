using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace Everest.Exercise.Services.Person.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        private IFixture _fixture;
        private PersonService _sut;
        private IPersonDatabase _personDatabase;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _personDatabase = _fixture.Freeze<IPersonDatabase>();
            _sut = _fixture.Create<PersonService>();
        }

        [TestMethod]
        public void GetOnePerson_WithValidId_IsNotNull()
        {
            // Arrange
            var id = _fixture.Create<int>();

            var onePerson = _fixture.Create<PersonData>();
            _personDatabase.GetOnePerson(id).Returns(onePerson);

            // Act
            var actual = _sut.GetOnePerson(id);

            // Assert            
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetOnePerson_WithValidId_ReturnsExpectedElement()
        {
            // Arrange
            var id = _fixture.Create<int>();

            var expected = _fixture.Create<PersonData>();
            _personDatabase.GetOnePerson(id).Returns(expected);

            // Act
            var actual = _sut.GetOnePerson(id);

            // Assert            
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetOnePerson_WithValidId_CallsPersonDatabase()
        {
            // Arrange
            var id = _fixture.Create<int>();

            var expected = _fixture.Create<PersonData>();
            _personDatabase.GetOnePerson(id).Returns(expected);

            // Act
            _sut.GetOnePerson(id);

            // Assert            
            _personDatabase.Received().GetOnePerson(id);
        }

        [TestMethod]
        public void GetEverybody_ValidCall_IsNotNull()
        {
            // Arrange
            var expectedList = _fixture.CreateMany<PersonData>().ToList();
            _personDatabase.GetEverybody().Returns(expectedList);

            // Act
            var actual = _sut.GetEverybody();

            // Assert            
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetEverybody_ValidCall_ReturnsExpectedElementsNumber()
        {
            // Arrange
            var expectedList = _fixture.CreateMany<PersonData>().ToList();
            _personDatabase.GetEverybody().Returns(expectedList);

            // Act
            var actual = _sut.GetEverybody();

            // Assert            
            actual.Should().HaveCount(expectedList.Count);
        }

        [TestMethod]
        public void GetEverybody_ValidCall_ReturnsExpectedElements()
        {
            // Arrange
            var expectedList = _fixture.CreateMany<PersonData>().ToList();
            _personDatabase.GetEverybody().Returns(expectedList);

            // Act
            var actual = _sut.GetEverybody();

            // Assert            
            actual.ShouldAllBeEquivalentTo(expectedList);
        }

        [TestMethod]
        public void GetEverybody_ValidCall_CallsPersonDatabase()
        {
            // Arrange
            var expectedList = _fixture.CreateMany<PersonData>().ToList();
            _personDatabase.GetEverybody().Returns(expectedList);

            // Act
            _sut.GetEverybody();

            // Assert            
            _personDatabase.Received().GetEverybody();
        }
    }
}