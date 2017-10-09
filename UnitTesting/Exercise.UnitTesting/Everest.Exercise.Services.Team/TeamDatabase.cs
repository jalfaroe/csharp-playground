using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Everest.Exercise.Services.Team
{
    public class TeamDatabase : ITeamDatabase
    {
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
        }

        public TeamMemberData GetOneMember(int id)
        {
            throw new TeamDatabaseHitException(MethodBase.GetCurrentMethod().Name);
        }

        public List<TeamMemberData> GetWholeTeam()
        {
            throw new TeamDatabaseHitException(MethodBase.GetCurrentMethod().Name);
        }
    }
}