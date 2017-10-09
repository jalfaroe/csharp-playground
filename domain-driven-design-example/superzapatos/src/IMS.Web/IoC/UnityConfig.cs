using System;
using IMS.Infrastructure.IoC;
using Microsoft.Practices.Unity;

namespace IMS.Web.IoC
{
    public class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var iocContainer = new IoCContainer(container);
            var iocSetup = new IoCSetup();
            iocSetup.Setup(iocContainer);
        }

        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });
    }
}