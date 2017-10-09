using System.Runtime.Serialization;

namespace Everest.Exercise.Contracts.Person
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}