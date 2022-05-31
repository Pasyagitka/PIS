using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr5a.Controllers
{
    public class MResearchController : Controller
    {
        [HttpGet]
        public string M01()
        {
            return "GET:M01";
        }

        [HttpGet]
        public string M02()
        {
            return "GET:M02";
        }

        [HttpGet]
        public string M03()
        {
            return "GET:M03";
        }

        [HttpGet]
        public string MXX()
        {
            return Request.Url.Query.Split('/').Last();
        }

    }
}