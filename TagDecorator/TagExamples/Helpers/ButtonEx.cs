using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class ButtonEx
    {
        public static MvcHtmlString Button(this HtmlHelper html, string text, string cssClass)
        {
            return "button".ToTag()
                .AddType("button")
                .AddCss(new[] { "btn", cssClass })
                .AddCss(cssClass)
                .SetText(text)
                .ToHtmlString();
        }
    }
}