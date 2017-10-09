// Don't touch this file, it is just an example about how to host all the web services and how to use them.

using System;
using System.ServiceModel;
using Everest.Exercise.Contracts.Person;
using Everest.Exercise.Services.Person;
using Everest.Exercise.Services.Team;
using Everest.Exercise.Contracts.Team;

namespace Everest.Exercise.Runner
{
    internal class Program
    {
        private const string PersonServiceEndPoint = "http://localhost:1234";
        private const string TeamServiceEndPoint = "http://localhost:5678";

        private static void Main()
        {
            HostAllServices();
            GetDataExample();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void HostAllServices()
        {
            var personDataBase = new PersonDatabase();
            var personService = new PersonService(personDataBase);
            var personServiceHost = new ServiceHost(personService, new Uri(PersonServiceEndPoint));
            var personServiceHostBehaviour = personServiceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            personServiceHostBehaviour.InstanceContextMode = InstanceContextMode.Single;
            personServiceHost.Open();

            var teamDataBase = new TeamDatabase();
            var channelFactoryWrapper = new ChannelFactoryWrapper();
            var teamService = new TeamService(teamDataBase, channelFactoryWrapper);
            var teamServiceHost = new ServiceHost(teamService, new Uri(TeamServiceEndPoint));
            var teamServiceHostBehaviour = teamServiceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            teamServiceHostBehaviour.InstanceContextMode = InstanceContextMode.Single;
            teamServiceHost.Open();
        }

        private static void GetDataExample()
        {
            using (var svc =
                new ChannelFactory<IPersonService>(new BasicHttpBinding(),
                    new EndpointAddress(PersonServiceEndPoint)))
            {
                var persons = svc.CreateChannel().GetEverybody();

                foreach (var person in persons)
                    Console.WriteLine(person.Name);
            }
        }
    }
}