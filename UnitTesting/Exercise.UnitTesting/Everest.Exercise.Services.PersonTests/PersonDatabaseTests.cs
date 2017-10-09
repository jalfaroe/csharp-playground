using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace Everest.Exercise.Services.Person.Tests
{
    [TestClass]
    public class PersonDatabaseTests
    {
        private IFixture _fixture;
        private PersonDatabase _sut;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _sut = _fixture.Create<PersonDatabase>();
        }

        [TestMethod]
        public void GetOnePerson_WithValidId_ThrowsPersonDatabaseHitException()
        {
            // Arrange
            var id = _fixture.Create<int>();

            // Act
            Action action = () => _sut.GetOnePerson(id);

            // Assert            
            action
                .ShouldThrow<PersonDatabaseHitException>()
                .WithMessage("You hit the person database! GetOnePerson");
        }

        [TestMethod]
        public void GetEverybody_ValidCall_IsNotNull()
        {
            // Arrange

            // Act
            var actual = _sut.GetEverybody();

            // Assert            
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetEverybody_ValidCall_ReturnsExpectedElementsNumber()
        {
            // Arrange
            var expected = new List<PersonData>
            {
                new PersonData {Age = 20, Name = "Carlos"},
                new PersonData {Age = 30, Name = "Juan"}
            };

            // Act
            var actual = _sut.GetEverybody();

            // Assert
            actual.Should().HaveCount(expected.Count);
        }

        [TestMethod]
        public void GetEverybody_ValidCall_ReturnsExpectedElements()
        {
            // Arrange
            var expected = new List<PersonData>
            {
                new PersonData {Age = 20, Name = "Carlos"},
                new PersonData {Age = 30, Name = "Juan"}
            };

            // Act
            var actual = _sut.GetEverybody();

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}