using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Helpers
{
    public static class FormHelper
    {
        public static MvcHtmlString AddForm(this HtmlHelper html)
        {
            TagBuilder outerDivTag = new TagBuilder("div");
            TagBuilder divTag = new TagBuilder("div");
            TagBuilder inputRecord = new TagBuilder("input");
            TagBuilder inputSubmit = new TagBuilder("input");
            inputRecord.Attributes.Add("type", "text");
            inputSubmit.Attributes.Add("type", "submit");
            inputRecord.Attributes.Add("name", "record");
            inputRecord.Attributes.Add("placeholder", "Фамилия, имя, отчество. Телефон");
            inputRecord.Attributes.Add("value", "");
            inputSubmit.Attributes.Add("value", "Create");
            inputRecord.AddCssClass("form-control");
            inputSubmit.AddCssClass("btn add-button");
            divTag.AddCssClass("add-field");
            divTag.InnerHtml += inputRecord.ToString();
            outerDivTag.InnerHtml += divTag;
            outerDivTag.InnerHtml += inputSubmit.ToString();
            return new MvcHtmlString(outerDivTag.ToString());
        }

        public static MvcHtmlString UpdateForm(this HtmlHelper html, string name, string number)
        {

            TagBuilder outerDivTag = new TagBuilder("div");
            TagBuilder divTag = new TagBuilder("div");
            TagBuilder inputRecord = new TagBuilder("input");
            TagBuilder inputSubmit = new TagBuilder("input");
            inputRecord.Attributes.Add("type", "text");
            inputSubmit.Attributes.Add("type", "submit");
            inputRecord.Attributes.Add("name", "record");
            inputRecord.Attributes.Add("placeholder", "Новые данные...");
            inputRecord.Attributes.Add("value", name + ", "+ number);
            inputSubmit.Attributes.Add("value", "Save");
            inputRecord.AddCssClass("form-control add-record-input");
            inputSubmit.AddCssClass("btn change-button");
            divTag.AddCssClass("add-field");
            divTag.InnerHtml += inputRecord.ToString();
            outerDivTag.InnerHtml += divTag;
            outerDivTag.InnerHtml += inputSubmit.ToString();
            return new MvcHtmlString(outerDivTag.ToString());
        }
    }
}