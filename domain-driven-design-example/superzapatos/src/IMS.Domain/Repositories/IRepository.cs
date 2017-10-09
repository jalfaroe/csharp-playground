using System.Collections.Generic;
using IMS.Domain.Entities;

namespace IMS.Domain.Repositories
{
    /// <summary>
    ///     This is not the best repository pattern implementation, personally,
    ///     I prefer to apply the Interface Segregation Principle instead of a single interface.
    ///     Also, we should implement a Unit Of Work if we want to manage transactions.
    ///     Unfortunately, I did not have more time for a better implementation.
    /// </summary>
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}