using System.Runtime.Serialization;

namespace Everest.Exercise.Contracts.Team
{
    [DataContract]
    public class TeamMember
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public decimal YearsOnTeam { get; set; }
    }
}