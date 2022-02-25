using System;
using System.Web;

namespace HTTPHandlers
{
    public class Handler5 : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.WriteFile("html/5.html");
            }
            else if (context.Request.HttpMethod == "POST")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                var X = context.Request.Form["X"];
                var Y = context.Request.Form["Y"];
                context.Response.Write($"Mul = {Int32.Parse(X) * Int32.Parse(Y)}");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
