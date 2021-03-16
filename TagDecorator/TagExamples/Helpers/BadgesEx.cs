using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class BadgesEx
    {
        public enum BadgeType
        {
            Normal,
            Pill
        }

        public static MvcHtmlString Badge(this HtmlHelper html, string text, 
            Bs4StandardColors badgeType = Bs4StandardColors.Secondary, BadgeType type = BadgeType.Normal)
        {
            return "span".ToTag()
                .AddCss(new[] {"badge", GetBadgeTypeCss(type), GetBadgeColorCss(badgeType)})
                .SetText(text)
                .ToHtmlString();
        }

        private static string GetBadgeColorCss(Bs4StandardColors badgeColor)
        {
            switch (badgeColor)
            {
                case Bs4StandardColors.Primary: return "badge-primary";
                case Bs4StandardColors.Secondary: return "badge-secondary";
                case Bs4StandardColors.Success: return "badge-success";
                case Bs4StandardColors.Danger: return "badge-danger";
                case Bs4StandardColors.Warning: return "badge-warning";
                case Bs4StandardColors.Info: return "badge-info";
                case Bs4StandardColors.Light: return "badge-light";
                case Bs4StandardColors.Dark: return "badge-dark";
                default: return "badge-primary";
            }
        }

        private static string GetBadgeTypeCss(BadgeType type)
        {
            switch (type)
            {
                case BadgeType.Pill: return "badge-pill";
                default: return string.Empty;
            }
        }
    }
}