using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Everest.Exercise.Services.Person
{
    public class PersonDatabase : IPersonDatabase
    {
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
        }

        public PersonData GetOnePerson(int id)
        {
            throw new PersonDatabaseHitException(MethodBase.GetCurrentMethod().Name);
        }

        public List<PersonData> GetEverybody()
        {
            var persons = new List<PersonData>
            {
                new PersonData {Age = 20, Name = "Carlos"},
                new PersonData {Age = 30, Name = "Juan"}
            };

            return persons;
        }
    }
}