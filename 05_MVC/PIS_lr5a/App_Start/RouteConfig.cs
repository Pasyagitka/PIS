using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PIS_lr5a
{
    public class RouteConfig
    {
        //парсит URL, помещает в RouteValueDictionary. Ключи = имена параметров URL, значения: сегменты URL. 
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //M02 - /V2, V2/MResearch, V2/MResearch/M02, /MResearch/M02, V3/MResearch/X/M02
            routes.MapRoute(
                name: "V2",
                url: "V2/{controller}/{action}",
                defaults: new { 
                    controller = "MResearch", 
                    action = "M02"
                },
                constraints: new { 
                    action = @"M0[1|2]" 
                }
            );

            //M03 - /V3, V3/MResearch/X, V3/MResearch/X/M03
            routes.MapRoute(
                name: "V3",
                url: "V3/{controller}/{id}/{action}",
                defaults: new { 
                    controller = "MResearch", 
                    action = "M03", 
                    id = UrlParameter.Optional //если он не указан в строке запроса, он не будет учитываться и передаваться в словарь параметров RouteValueDictionary. 
                }
            );

            // /MResearch/M01/1, /MResearch/M01/1, /MResearch/M01/1, /, V2/MResearch/M01, V3/MResearch/X/M01
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "MResearch", 
                    action = "M01", 
                    id = UrlParameter.Optional 
                },
                constraints: new {
                    action = @"M0[1|2]" 
                }
            );

            //MapRoute - сопоставление маршрута запросу
            routes.MapRoute(
               name: "CResearch",
               url: "CResearch/{action}",
               defaults: new { 
                   controller = "CResearch", 
                   action = "C01" 
               }
           );

            //MXX
            routes.MapRoute(
                name: "err",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "MResearch", 
                    action = "MXX", 
                    id = UrlParameter.Optional 
                }
            );

        }
    }
}
