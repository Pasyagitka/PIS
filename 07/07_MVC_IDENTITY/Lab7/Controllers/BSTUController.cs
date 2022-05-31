using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class BSTUController : Controller
    {
        // GET: BSTU
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.IsAuth = this.HttpContext.User.Identity.IsAuthenticated;
            ViewBag.UserName = this.HttpContext.User.Identity.Name;
            ViewBag.IsAdmin = this.HttpContext.User.IsInRole("Administrator");
            ViewBag.IsEmployer = this.HttpContext.User.IsInRole("Employer");

            return View();
        }

        [Authorize(Roles ="Administrator")]
        public ActionResult Config()
        {
            return View();
        }
    }
}