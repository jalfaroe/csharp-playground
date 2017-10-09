using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IMS.Web.IoC;

namespace IMS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityWebActivator.Start();
        }
    }
}