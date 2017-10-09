using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Everest.Exercise.Services.Team.Tests
{
    [TestClass]
    public class TeamDatabaseTests
    {
        private Fixture _fixture;
        private TeamDatabase _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new TeamDatabase();
            _fixture = new Fixture();
        }
        
        [TestMethod]
        public void GetOneMember_WithValidId_ThrowsTeamDatabaseHitException()
        {
            // Arrange
            var id = _fixture.Create<int>();

            // Act
            Action action = () => _sut.GetOneMember(id);

            // Assert            
            action
                .ShouldThrow<TeamDatabaseHitException>()
                .WithMessage("You hit the team database! GetOneMember");
        }

        [TestMethod]
        public void GetWholeTeam_ValidCall_ThrowsTeamDatabaseHitException()
        {
            // Arrange


            // Act
            Action action = () => _sut.GetWholeTeam();

            // Assert            
            action
                .ShouldThrow<TeamDatabaseHitException>()
                .WithMessage("You hit the team database! GetWholeTeam");
        }
    }
}