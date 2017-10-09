using System;

namespace Everest.Exercise.Services.Team
{
    public class TeamDatabaseHitException : ApplicationException
    {
        public TeamDatabaseHitException(string methodName)
            : base(string.Format("You hit the team database! {0}", methodName))
        {
        }
    }
}