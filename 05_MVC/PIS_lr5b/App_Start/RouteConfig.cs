using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace PIS_lr5b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "AResearch",
                url: "{controller}/{action}",
                defaults: new { controller = "AResearch", action = "AA" }
            );

            routes.MapRoute(
               name: "CHResearch",
               url: "{controller}/{action}",
               defaults: new { controller = "CHResearch", action = "AD" }
           );

        }
    }
}
