using System;
using System.Collections.Generic;

namespace Everest.Exercise.Services.Team
{
    public interface ITeamDatabase : IDisposable
    {
        TeamMemberData GetOneMember(int id);
        List<TeamMemberData> GetWholeTeam();
    }
}
