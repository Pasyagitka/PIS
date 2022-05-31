using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr5b.Controllers
{
    [AEFilter]
    public class AResearchController : Controller
    {
        //AA, AR, AE
        [AAFilter]
        public ActionResult AA()
        {
            return Content("<p>AA</p>");
        }

        [ARFilter]
        public ActionResult AR()
        {
            return Content("<p>AR</p>");
        }

      
        public ActionResult AE()
        {
            throw new Exception("From-E");
            return Content("<p>AE</p>"); ;
        }

        //фильтр акции
        // входной контекст запроса при доступе к действию, а также выполнить определенные действия по завершению работы метода действий.
        //https://localhost:44311/AResearch/AA
        public class AAFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)  //до
            {
                filterContext.HttpContext.Response.Write("<p>AA: OnActionExecuting</p>");
            }
            public override void OnActionExecuted(ActionExecutedContext filterContext)  //после
            {
                filterContext.HttpContext.Response.Write("<p>AA: OnActionExecuted</p>");
            }
        }

        //фильтр результата
        //как до возвращения результата действия, так и после. 
        //https://localhost:44311/AResearch/AR
        public class ARFilter : FilterAttribute, IResultFilter
        {
            public void OnResultExecuting(ResultExecutingContext filterContext) //перед тем, как метод действия начнет возвращать результат действия.
            {
                filterContext.HttpContext.Response.Write("<p>AR: OnResultExecuting</p>");
            }
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AR: OnResultExecuted</p>");
            }
        }

        //фильтр исключений
        //https://localhost:44311/AResearch/AE
        public class AEFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AE: OnException</p>");
                ViewResult vr = new ViewResult();
                vr.ViewName = "Error";
                filterContext.Result = vr;
                filterContext.ExceptionHandled = false;
            }
        }
    }
}