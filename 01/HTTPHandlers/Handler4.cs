using System;
using System.Web;

namespace HTTPHandlers
{
    public class Handler4 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            var X = context.Request.Form["X"];
            var Y = context.Request.Form["Y"];
            context.Response.Write($"Sum = {Int32.Parse(X) + Int32.Parse(Y)}");
        }
    }
}
