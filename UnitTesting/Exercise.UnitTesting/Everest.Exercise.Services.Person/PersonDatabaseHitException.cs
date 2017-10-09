using System;

namespace Everest.Exercise.Services.Person
{
    public class PersonDatabaseHitException : ApplicationException
    {
        public PersonDatabaseHitException(string methodName)
            : base(string.Format("You hit the person database! {0}", methodName))
        {
        }
    }
}