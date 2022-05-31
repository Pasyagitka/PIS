using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404; 
            ViewBag.path = Request.Url.ToString().Split(';')[1];
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}