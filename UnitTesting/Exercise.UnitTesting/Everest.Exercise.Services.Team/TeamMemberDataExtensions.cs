using Everest.Exercise.Contracts.Person;
using Everest.Exercise.Contracts.Team;

namespace Everest.Exercise.Services.Team
{
    public static class TeamMemberDataExtensions
    {
        public static TeamMember ToTeamMember(this TeamMemberData teamMemberData, Person person)
        {
            var teamMember = new TeamMember
            {
                Age = person.Age,
                Name = person.Name,
                YearsOnTeam = teamMemberData.YearsOnTeam
            };

            return teamMember;
        }
    }
}
