using IMS.Application.Articles;
using IMS.Application.Stores;
using IMS.Infrastructure.IoC.Contracts;

namespace IMS.Application
{
    public class IoCConfigurator : IIoCConfigurator
    {
        public void Configure(IIoCContainer container)
        {
            container.RegisterType<IStoreAppService, StoreAppService>();
            container.RegisterType<IArticleAppService, ArticleAppService>();
        }
    }
}