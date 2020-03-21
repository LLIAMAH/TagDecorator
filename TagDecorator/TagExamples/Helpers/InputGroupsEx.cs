using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class InputGroupsEx
    {
        public static MvcHtmlString InputGroup1(this HtmlHelper html, string inputText = "Username", string addonText = "@")
        {
            return "div".ToTag()
                .AddCss(new[] {"input-group", "mb-3"})
                .InnerHtml(new[]
                {
                    "div".ToTag().AddCss("input-group-prepend").InnerHtml("span".ToTag().AddCss("input-group-text")
                        .AddId("basic-addon1").SetText(addonText)),
                    "input".ToTag().AddType("text").AddCss("form-control").AddAttribute("placeholder", inputText)
                        .AddAria("label", inputText).AddAria("describedby", "basic-addon1")
                })
                .ToHtmlString();
        }

        public static MvcHtmlString InputGroup2(this HtmlHelper html, string inputText = "Recipient's username", string spanValue= "@example.com")
        {
            return "div".ToTag()
                .AddCss(new[] {"input-group", "mb-3"})
                .InnerHtml(new[]
                {
                    "input".ToTag().AddType("text").AddCss("form-control").AddAttribute("placeholder", inputText)
                        .AddAria("label", inputText).AddAria("describedby", "basic-addon2"),
                    "div".ToTag().AddCss("input-group-append").InnerHtml("span".ToTag().AddCss("input-group-text")
                        .AddId("basic-addon2").SetText(spanValue))
                })
                .ToHtmlString();
        }

        public static MvcHtmlString InputGroup3Label(this HtmlHelper html, string text = "Your vanity URL")
        {
            return "label".ToTag().AddFor("basic-url").SetText(text).ToHtmlString();
        }

        public static MvcHtmlString InputGroup3Source(this HtmlHelper html, string spanParameter = "https://example.com/users/")
        {
            return "div".ToTag()
                .AddCss(new[] { "input-group", "mb-3" })
                .InnerHtml(new[]
                {
                    "div".ToTag().AddCss("input-group-prepend").InnerHtml("span".ToTag().AddCss("input-group-text").AddId("basic-addon3").SetText(spanParameter)),
                    "input".ToTag().AddType("text").AddCss("form-control").AddId("basic-url").AddAria("describedby","basic-addon3")
                })
                .ToHtmlString();
        }

        public static MvcHtmlString InputGroup4(this HtmlHelper html, string spanParameter1 = "$", string spanParameter2 = ".00", string inputText= "Amount (to the nearest dollar)")
        {
            return "div".ToTag()
                .AddCss(new[] { "input-group", "mb-3" })
                .InnerHtml(new[]
                {
                    "div".ToTag().AddCss("input-group-prepend").InnerHtml("span".ToTag().AddCss("input-group-text").SetText(spanParameter1)),
                    "input".ToTag().AddType("text").AddCss("form-control").AddAria("label",inputText),
                    "div".ToTag().AddCss("input-group-append").InnerHtml("span".ToTag().AddCss("input-group-text").SetText(spanParameter2)),
                })
                .ToHtmlString();
        }

        public static MvcHtmlString InputGroup5(this HtmlHelper html, string spanParameter = "With textarea")
        {
            return "div".ToTag().AddCss( "input-group")
                .InnerHtml(new[]
                {
                    "div".ToTag().AddCss("input-group-prepend").InnerHtml("span".ToTag().AddCss("input-group-text").SetText(spanParameter)),
                    "textarea".ToTag().AddCss("form-control").AddAria("label",spanParameter)
                })
                .ToHtmlString();
        }
    }
}