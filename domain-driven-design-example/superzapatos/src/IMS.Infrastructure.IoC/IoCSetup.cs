using IMS.Application;
using IMS.Infrastructure.Crosscutting.Core;
using IMS.Infrastructure.IoC.Contracts;

namespace IMS.Infrastructure.IoC
{
    public class IoCSetup
    {
        public void Setup(IIoCContainer container)
        {
            container.RegisterTypeSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            var iocApplicationConfigurator = new IoCConfigurator();
            var iocDataConfigurator = new Data.IoCConfigurator();

            iocApplicationConfigurator.Configure(container);
            iocDataConfigurator.Configure(container);
        }
    }
}