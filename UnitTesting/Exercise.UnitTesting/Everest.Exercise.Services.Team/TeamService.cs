using System.Collections.Generic;
using Everest.Exercise.Contracts.Person;
using Everest.Exercise.Contracts.Team;

namespace Everest.Exercise.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ITeamDatabase _teamDatabase;
        private readonly IChannelFactoryWrapper _channelFactoryWrapper;

        public TeamService(ITeamDatabase teamDatabase, IChannelFactoryWrapper channelFactoryWrapper)
        {
            _teamDatabase = teamDatabase;
            _channelFactoryWrapper = channelFactoryWrapper;
        }

        public TeamMember GetOneMember(int id)
        {            
            TeamMemberData memberData = GetMemberData(id);
            Person person = GetPerson(memberData);
            TeamMember teamMember = memberData.ToTeamMember(person);

            return teamMember;
        }

        public List<TeamMember> GetWholeTeam()
        {            
            List<TeamMemberData> teamData = GetWholeTeamData();

            var teamMembers = teamData.ConvertAll(memberData =>
            {            
                Person person = GetPerson(memberData);
                TeamMember teamMember = memberData.ToTeamMember(person);

                return teamMember;
            });

            return teamMembers;
        }

        private Person GetPerson(TeamMemberData memberData)
        {
            return _channelFactoryWrapper.GetPersonService().GetOnePerson(memberData.PersonId);
        }

        private TeamMemberData GetMemberData(int id)
        {
            using (_teamDatabase)
            {
                return _teamDatabase.GetOneMember(id);
            }           
        }

        private List<TeamMemberData> GetWholeTeamData()
        {
            using (_teamDatabase)
            {
                return _teamDatabase.GetWholeTeam();
            }          
        }
    }
}