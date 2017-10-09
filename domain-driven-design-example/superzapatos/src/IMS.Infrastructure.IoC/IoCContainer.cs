using IMS.Infrastructure.IoC.Contracts;
using Microsoft.Practices.Unity;

namespace IMS.Infrastructure.IoC
{
    public class IoCContainer : IIoCContainer
    {
        private readonly IUnityContainer _container;

        public IoCContainer(IUnityContainer container)
        {
            _container = container;
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }

        public void RegisterTypeSingleton<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}