using System.Collections.Generic;
using System.ServiceModel;

namespace Everest.Exercise.Contracts.Person
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        Person GetOnePerson(int id);

        [OperationContract]
        List<Person> GetEverybody();
    }
}