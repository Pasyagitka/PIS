using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr5a.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("get", "post")]
        public string C01()
        {
            string body;
            string query_parameters = "";
            foreach (string key in Request.QueryString.AllKeys)
            {
                query_parameters += $"{key}:{Request.QueryString[key]}; ";
            }

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            return $"метод запроса: {Request.HttpMethod}, query-параметры: {query_parameters}, uri: {Request.Url.AbsoluteUri}, заголовки: {Request.Headers}, тело: {body}; ";
        }

        [AcceptVerbs("get", "post")]
        public string C02()
        {
            string body;

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            return  $"статус ответа: {HttpContext.Response.StatusCode}, заголовки: {Request.Headers}, тело: {body}";
        }
    }
}