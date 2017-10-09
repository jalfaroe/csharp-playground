using System.Collections.Generic;
using System.Linq;
using Everest.Exercise.Contracts.Person;
using Everest.Exercise.Contracts.Team;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace Everest.Exercise.Services.Team.Tests
{
    [TestClass]
    public class TeamServiceTests
    {
        private IFixture _fixture;
        private TeamService _sut;
        private ITeamDatabase _teamDatabase;
        private IPersonService _personService;
        private IChannelFactoryWrapper _channelFactoryWrapper;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _teamDatabase = _fixture.Freeze <ITeamDatabase>();
            _channelFactoryWrapper = _fixture.Freeze<IChannelFactoryWrapper>();
            _personService = _fixture.Freeze<IPersonService>();

            _sut = _fixture.Create<TeamService>();
        }
        
        [TestMethod]
        public void GetOneMember_WithValidId_IsNotNull()
        {
            // Arrange
            var id = _fixture.Create<int>();

            var oneMember = _fixture.Build<TeamMemberData>().With(x => x.PersonId, id).Create();
            _teamDatabase.GetOneMember(id).Returns(oneMember);

            var person = _fixture.Create<Person>();
            _personService.GetOnePerson(Arg.Any<int>()).Returns(person);

            _channelFactoryWrapper.GetPersonService().Returns(_personService);
            
            // Act
            var actual = _sut.GetOneMember(id);

            // Assert
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetOneMember_WithValidId_ReturnsExpectedElement()
        {
            // Arrange
            var id = _fixture.Create<int>();

            var teamMember = _fixture.Build<TeamMemberData>().With(x => x.PersonId, id).Create();
            _teamDatabase.GetOneMember(id).Returns(teamMember);

            var person = _fixture.Create<Person>();
            _personService.GetOnePerson(Arg.Any<int>()).Returns(person);

            var expected = new TeamMember
            {
                Name = person.Name,
                Age = person.Age,
                YearsOnTeam = teamMember.YearsOnTeam
            };

            _channelFactoryWrapper.GetPersonService().Returns(_personService);

            // Act
            var actual = _sut.GetOneMember(id);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetWholeTeam_ValidCall_IsNotNull()
        {
            // Arrange
            _fixture.RepeatCount = 10;

            var wholeTeamData = _fixture.CreateMany<TeamMemberData>().ToList();
            _teamDatabase.GetWholeTeam().Returns(wholeTeamData);

            foreach (var member in wholeTeamData )
            {
                var person = _fixture.Create<Person>();
                _personService.GetOnePerson(member.PersonId).Returns(person);
            }            

            _channelFactoryWrapper.GetPersonService().Returns(_personService);

            // Act
            var actual = _sut.GetWholeTeam();            

            // Assert
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetWholeTeam_ValidCall_ReturnsExpectedElementsNumber()
        {
            // Arrange
            _fixture.RepeatCount = 10;

            var wholeTeamData = _fixture.CreateMany<TeamMemberData>().ToList();
            _teamDatabase.GetWholeTeam().Returns(wholeTeamData);
            
            foreach (var member in wholeTeamData)
            {
                var person = _fixture.Create<Person>();
                _personService.GetOnePerson(member.PersonId).Returns(person);
            }

            _channelFactoryWrapper.GetPersonService().Returns(_personService);

            // Act
            var actual = _sut.GetWholeTeam();

            // Assert
            actual.Should().HaveCount(wholeTeamData.Count);
        }

        [TestMethod]
        public void GetWholeTeam_ValidCall_ReturnsExpectedElements()
        {
            // Arrange
            _fixture.RepeatCount = 10;

            var wholeTeamData = _fixture.CreateMany<TeamMemberData>().ToList();
            _teamDatabase.GetWholeTeam().Returns(wholeTeamData);

            var expectedList = new List<TeamMember>();
            foreach (var member in wholeTeamData)
            {
                var person = _fixture.Create<Person>();
                _personService.GetOnePerson(member.PersonId).Returns(person);
                expectedList.Add(new TeamMember
                {
                    Name = person.Name,
                    Age = person.Age,
                    YearsOnTeam = member.YearsOnTeam
                });
            }

            _channelFactoryWrapper.GetPersonService().Returns(_personService);

            // Act
            var actual = _sut.GetWholeTeam();

            // Assert
            actual.ShouldAllBeEquivalentTo(expectedList);
        }
    }
}