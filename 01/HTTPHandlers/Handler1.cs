using System;
using System.Web;

namespace HTTPHandlers
{
    public class Handler1 : IHttpHandler
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
            context.Response.Write($"GET-Http-ZEI:ParmA = {ParmA},ParmB = {ParmB}");
        }
    }
}
