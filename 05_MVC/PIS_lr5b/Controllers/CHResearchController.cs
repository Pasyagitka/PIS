using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr5b.Controllers
{
    public class CHResearchController : Controller
    {
        //https://localhost:44311/CHResearch/AD
        [HttpGet, OutputCache(Duration = 5)]
        public ActionResult AD()
        {
            return Content($"GET:/AD:{DateTime.Now}");
        }

        //https://localhost:44311/CHResearch/AP?x=1&y=3
        [HttpPost, OutputCache(Duration = 7, VaryByParam = "x;y")]
        public ActionResult AP(int x, int y)
        {
            return Content($"GET:/AP:{DateTime.Now}:{x}:{y}");
        }
    }
}