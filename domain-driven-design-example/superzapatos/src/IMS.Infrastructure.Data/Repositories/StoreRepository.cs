using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMS.Domain.Entities;
using IMS.Domain.Repositories;
using IMS.Infrastructure.Data.Context;

namespace IMS.Infrastructure.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IImsDbContext _context;

        public StoreRepository(IImsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Store> GetAll()
        {
            var result = _context.Stores.ToList();

            return result;
        }

        public Store GetById(int id)
        {
            var result = _context.Stores.Find(id);

            return result;
        }

        public void Add(Store entity)
        {
            _context.Stores.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Store entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}