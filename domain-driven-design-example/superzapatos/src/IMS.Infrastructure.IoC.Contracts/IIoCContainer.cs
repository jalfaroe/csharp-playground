namespace IMS.Infrastructure.IoC.Contracts
{
    /// <summary>
    /// IoC container's abstraction to decouple the application of a specific dependency injector.
    /// </summary>
    public interface IIoCContainer
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterTypeSingleton<TFrom, TTo>() where TTo : TFrom;
    }
}