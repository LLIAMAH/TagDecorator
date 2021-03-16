using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TagDecorator;

namespace TagExamples.Helpers
{
    public static class CollapsesEx
    {
        public static MvcHtmlString Accordion(this HtmlHelper html, AccordionBlock accordion)
        {
            if (accordion == null)
                throw new Exception("Such helper initialization failed.");

            if (string.IsNullOrEmpty(accordion.Id))
                accordion.Id = $"accordion_{DateTime.Now.Ticks}";

            var result = "div".ToTag()
                .AddCss("accordion")
                .AddId(accordion.Id)
                .InnerHtml(CreateCard(html, accordion.Id, accordion.Cards))
                .ToHtmlString();

            return result;
        }

        private static List<TagWrapper> CreateCard(HtmlHelper html, string accordionId, List<AccordionCard> cards)
        {
            var result = new List<TagWrapper>();

            for (var i = 0; i < cards.Count; i++)
            {
                var cardId = $"{accordionId}_Card{i + 1}";
                var collapseId = $"{accordionId}_Collapse{i + 1}";
                result.Add(
                    "div".ToTag()
                        .AddCss("card")
                        .InnerHtml(new[]
                        {
                            "div".ToTag().AddCss("card-header").AddId(cardId)
                                .InnerHtml(new[]
                                {
                                    "h2".ToTag().AddCss("mb-0").InnerHtml(
                                        "button".ToTag()
                                            .AddCss(new[]
                                            {
                                                "btn", ButtonEx.GetButtonColorCss(Bs4StandardColors.Link), "text-left"
                                            })
                                            .AddType("button")
                                            .AddData("toggle", "collapse")
                                            .AddData("target", $"#{collapseId}")
                                            .AddAria("expanded", cards[i].IsOpened ? "true" : "false")
                                            .AddAria("controls", collapseId)
                                            .SetText(cards[i].Title)
                                    )
                                }),
                            "div".ToTag()
                                .AddId(collapseId)
                                .AddCss("collapse")
                                .AddCssIf(cards[i].IsOpened, "show")
                                .AddAria("labelledby", cardId)
                                .AddData("parent", $"#{accordionId}")
                                .InnerHtml(new[]
                                {
                                    "div".ToTag()
                                        .AddCss("card-body")
                                        .InnerHtml(HttpUtility.HtmlDecode(cards[i].Details))
                                })
                        })
                );
            }

            return result;
        }

        public class AccordionBlock
        {
            public string Id { get; set; }
            public List<AccordionCard> Cards { get; set; }

            public AccordionBlock()
            {
                Cards = new List<AccordionCard>();
            }

            public AccordionBlock(string id) : this()
            {
                this.Id = id;
            }

            public AccordionBlock(string id, List<AccordionCard> cards) : this(id)
            {
                Cards = cards;
            }
        }

        public class AccordionCard
        {
            public string Title { get; set; }
            [AllowHtml]
            public string Details { get; set; }
            public bool IsOpened { get; set; }

            public AccordionCard() { }

            public AccordionCard(string title, string details, bool isOpened = false)
            {
                this.Title = title;
                this.Details = details;
                this.IsOpened = isOpened;
            }
        }
    }
}