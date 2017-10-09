using System.Collections.Generic;

namespace Everest.Exercise.Services.Person
{
    public static class PersonDataExtensions
    {
        public static Contracts.Person.Person ToPerson(this PersonData person)
        {
            return new Contracts.Person.Person
            {
                Age = person.Age,
                Name = person.Name
            };
        }

        public static List<Contracts.Person.Person> ToPerson(this List<PersonData> person)
        {
            return person.ConvertAll(personData => personData.ToPerson());
        }
    }
}
