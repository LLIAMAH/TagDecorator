using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class ButtonEx
    {
        public static MvcHtmlString Button(this HtmlHelper html, string text, Bs4StandardColors buttonColor)
        {
            return "button".ToTag()
                .AddType("button")
                .AddCss(new[] {"btn", GetButtonColorCss(buttonColor)})
                .SetText(text)
                .ToHtmlString();
        }

        internal static string GetButtonColorCss(Bs4StandardColors buttonColor)
        {
            switch (buttonColor)
            {
                case Bs4StandardColors.Primary: return "btn-primary";
                case Bs4StandardColors.Secondary: return "btn-secondary";
                case Bs4StandardColors.Success: return "btn-success";
                case Bs4StandardColors.Danger: return "btn-danger";
                case Bs4StandardColors.Warning: return "btn-warning";
                case Bs4StandardColors.Info: return "btn-info";
                case Bs4StandardColors.Light: return "btn-light";
                case Bs4StandardColors.Dark: return "btn-dark";
                case Bs4StandardColors.Link: return "btn-link";
                default: return "btn-primary";
            }
        }
    }
}