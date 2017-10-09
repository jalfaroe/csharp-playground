namespace IMS.Infrastructure.IoC.Contracts
{
    /// <summary>
    /// IoC container's abstraction to decouple the application of a specific dependency injector.
    /// </summary>
    public interface IIoCConfigurator
    {
        void Configure(IIoCContainer container);
    }
}