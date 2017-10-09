using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using Everest.Exercise.Contracts.Person;

namespace Everest.Exercise.Services.Team
{
    [ExcludeFromCodeCoverage]
    public class ChannelFactoryWrapper : IChannelFactoryWrapper
    {
        public IPersonService GetPersonService()
        {
            using (var cf = new ChannelFactory<IPersonService>())
            {
                return cf.CreateChannel();
            }
        }
    }
}