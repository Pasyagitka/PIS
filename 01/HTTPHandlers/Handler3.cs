using System;
using System.Web;

namespace HTTPHandlers
{
    public class Handler3 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            var ParmA = context.Request.QueryString["ParmA"];
            var ParmB = context.Request.QueryString["ParmB"];
            context.Response.Write($"PUT-Http-ZEI:ParmA = {ParmA},ParmB = {ParmB}");
        }
    }
}
