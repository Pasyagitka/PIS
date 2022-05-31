using MVCApplication.NI;
using Ninject;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //подключение конфигурации 
            var kernel = new StandardKernel(new NIConfig());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
