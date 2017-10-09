using System.Collections.Generic;
using System.ServiceModel;

namespace Everest.Exercise.Contracts.Team
{
    [ServiceContract]
    public interface ITeamService
    {
        [OperationContract]
        TeamMember GetOneMember(int id);

        [OperationContract]
        List<TeamMember> GetWholeTeam();
    }
}