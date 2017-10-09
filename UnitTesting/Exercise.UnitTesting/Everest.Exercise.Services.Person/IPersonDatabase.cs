using System;
using System.Collections.Generic;

namespace Everest.Exercise.Services.Person
{
    public interface IPersonDatabase : IDisposable
    {
        PersonData GetOnePerson(int id);
        List<PersonData> GetEverybody();
    }
}