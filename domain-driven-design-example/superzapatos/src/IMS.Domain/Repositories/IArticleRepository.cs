using System.Collections.Generic;
using IMS.Domain.Entities;

namespace IMS.Domain.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetByStoreId(int storeId);
    }
}