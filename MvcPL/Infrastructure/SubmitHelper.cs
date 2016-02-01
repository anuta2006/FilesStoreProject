using System.Web.Mvc;

namespace MvcPL.Infrastructure
{
    public static class SubmitHelper
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper html, string value)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "submit");
            tag.MergeAttribute("value", value);
            tag.AddCssClass("btn btn-success");

            return new MvcHtmlString(tag.ToString());
        }
    }
}