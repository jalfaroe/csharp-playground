using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace IMS.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // for json: http://localhost:10853/services/stores?type=json
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            // for xml : http://localhost:10853/services/stores?type=xml
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
        }
    }
}