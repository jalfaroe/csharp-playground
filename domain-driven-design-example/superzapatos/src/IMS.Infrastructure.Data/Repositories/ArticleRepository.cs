using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMS.Domain.Entities;
using IMS.Domain.Repositories;
using IMS.Infrastructure.Data.Context;

namespace IMS.Infrastructure.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IImsDbContext _context;

        public ArticleRepository(IImsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            var result = _context.Articles.Include(a => a.Store).ToList();

            return result;
        }

        public Article GetById(int id)
        {
            var result = _context.Articles.Find(id);

            return result;
        }

        public IEnumerable<Article> GetByStoreId(int storeId)
        {
            var result = _context.Articles.Where(p => p.StoreId == storeId);

            return result;
        }

        public void Add(Article entity)
        {
            _context.Articles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Article entity)
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