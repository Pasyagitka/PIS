using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {

        [HttpGet, Route("{n:int}/{str}")]
        public string M01(int n, string str)
        {
            return $"GET:M01/{n}/{str}";
        }

        [AcceptVerbs("get", "post"), Route("{b:bool}/{letters:alpha}")]
        public string M02(bool b, string letters)
        {
            return $"{Request.HttpMethod}:M02/{b}/{letters}";
        }

        [AcceptVerbs("get", "delete"), Route("{f:float}/{str:length(2, 5)}")]
        public string M03(float f, string str)
        {
            return $"{Request.HttpMethod}:M03/{f}/{str}";
        }

        [HttpPut, Route("{letters:alpha:length(3, 4)}/{n:range(100, 200)}")]
        public string M04(string letters, int n)
        {
            return $"PUT:M04/{letters}/{n}";
        }

        [HttpPost, Route(@"{mail:regex(^[a-zA-Z]+@[a-zA-Z0-9]+[.][a-zA-Z]+$)}")]
        public string M05(string mail)
        {
            return $"POST:{mail}";
        }
    }
}