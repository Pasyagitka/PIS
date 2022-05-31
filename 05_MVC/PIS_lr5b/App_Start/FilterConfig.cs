using System.Web;
using System.Web.Mvc;
using static PIS_lr5b.Controllers.AResearchController;

namespace PIS_lr5b
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {           
            filters.Add(new AEFilter());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
