using System.Collections.Generic;
using Everest.Exercise.Contracts.Person;

namespace Everest.Exercise.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDatabase _personDatabase;

        public PersonService(IPersonDatabase db)
        {
            _personDatabase = db;
        }

        public Contracts.Person.Person GetOnePerson(int id)
        {
            using (_personDatabase)
            {
                var personData = _personDatabase.GetOnePerson(id);

                return personData.ToPerson();
            }
        }

        public List<Contracts.Person.Person> GetEverybody()
        {
            using (_personDatabase)
            {
                var data = _personDatabase.GetEverybody();

                return data.ToPerson();
            }
        }
    }
}