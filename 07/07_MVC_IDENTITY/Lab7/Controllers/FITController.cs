using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class FITController : Controller
    {
        // GET: FIT
        [Authorize(Roles ="Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_IS()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_PI()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_ID()
        {
            return View();
        }
    }
}