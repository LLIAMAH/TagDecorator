using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class AlertsEx
    {
        public enum Bs4AlertType
        {
            Primary,
            Secondary,
            Success,
            Danger,
            Warning,
            Info,
            Light,
            Dark
        };
        
        public static MvcHtmlString Alert(this HtmlHelper html, Bs4AlertType alertType, string text)
        {
            return "div".ToTag().AddCss(new[] {"alert", GetAlertTypeCss(alertType)}).AddRole("alert").SetText(text)
                .ToHtmlString();
        }

        private static string GetAlertTypeCss(Bs4AlertType alertType)
        {
            switch (alertType)
            {
                case Bs4AlertType.Primary: return "alert-primary";
                case Bs4AlertType.Secondary: return "alert-secondary";
                case Bs4AlertType.Success: return "alert-success";
                case Bs4AlertType.Danger: return "alert-danger";
                case Bs4AlertType.Warning: return "alert-warning";
                case Bs4AlertType.Info: return "alert-info";
                case Bs4AlertType.Light: return "alert-light";
                case Bs4AlertType.Dark: return "alert-dark";
                default: return "alert-primary";
            }
        }
    }
}