using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class ButtonEx
    {
        public static MvcHtmlString Button(this HtmlHelper html, string text)
        {
            return "button".ToTag()
                .AddType("button")
                .SetText(text)
                .ToHtmlString();
        }
    }
}