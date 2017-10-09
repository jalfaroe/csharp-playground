using System.Data.Entity;
using IMS.Domain.Entities;
using System.Data.Entity.Infrastructure;

namespace IMS.Infrastructure.Data.Context
{
    public interface IImsDbContext
    {
        DbSet<Store> Stores { get; set; }
        DbSet<Article> Articles { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}