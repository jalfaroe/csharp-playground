using System.Net.Http.Headers;
using System.Web.Http;
using IMS.API.IoC;
using IMS.Infrastructure.IoC;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IMS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultRouting", "services/{controller}/{id}",
                new {id = RouteParameter.Optional}
                );

            /*
             * That makes sure you get json on most queries, but you can get xml when you send text/xml
             * 
             * http://localhost:10853/services/stores?type=json
             * http://localhost:10853/services/stores?type=xml
             */
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Json formatting
            config.Formatters.JsonFormatter.SerializerSettings.Formatting
                = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();

            // xml formatting
            config.Formatters.XmlFormatter.Indent = true;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            var iocContainer = new IoCContainer(container);
            var iocSetup = new IoCSetup();
            iocSetup.Setup(iocContainer);
        }
    }
}