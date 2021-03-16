using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class AlertsEx
    {
        public static MvcHtmlString Alert(this HtmlHelper html, string text, Bs4StandardColors alertColor)
        {
            return "div".ToTag().AddCss(new[] {"alert", GetAlertColorCss(alertColor)}).AddRole("alert").SetText(text)
                .ToHtmlString();
        }

        private static string GetAlertColorCss(Bs4StandardColors alertColor)
        {
            switch (alertColor)
            {
                case Bs4StandardColors.Primary: return "alert-primary";
                case Bs4StandardColors.Secondary: return "alert-secondary";
                case Bs4StandardColors.Success: return "alert-success";
                case Bs4StandardColors.Danger: return "alert-danger";
                case Bs4StandardColors.Warning: return "alert-warning";
                case Bs4StandardColors.Info: return "alert-info";
                case Bs4StandardColors.Light: return "alert-light";
                case Bs4StandardColors.Dark: return "alert-dark";
                default: return "alert-primary";
            }
        }
    }
}