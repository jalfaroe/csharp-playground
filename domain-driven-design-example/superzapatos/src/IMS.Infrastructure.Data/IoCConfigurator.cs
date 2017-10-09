using IMS.Domain.Repositories;
using IMS.Infrastructure.Data.Context;
using IMS.Infrastructure.Data.Repositories;
using IMS.Infrastructure.IoC.Contracts;

namespace IMS.Infrastructure.Data
{
    public class IoCConfigurator : IIoCConfigurator
    {
        public void Configure(IIoCContainer container)
        {
            container.RegisterType<IImsDbContext, ImsDbContext>();
            container.RegisterType<IStoreRepository, StoreRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
        }
    }
}