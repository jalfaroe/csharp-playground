using Everest.Exercise.Contracts.Person;

namespace Everest.Exercise.Services.Team
{
    public interface IChannelFactoryWrapper
    {
        IPersonService GetPersonService();
    }
}