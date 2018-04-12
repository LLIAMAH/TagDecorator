using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TagDecorator
{
    public static class TagDecorator
    {
        public static TagWrapper ToTag(this TagBuilder tb)
        {
            return new TagWrapper(tb);
        }

        public static TagWrapper ToTag(this string tag)
        {
            return new TagWrapper(tag);
        }

        public static TagWrapper SetText(this TagWrapper tag, string text)
        {
            tag.Tag.SetInnerText(text);
            return tag;
        }

        public static TagWrapper AddCss(this TagWrapper tag, string css)
        {
            tag.Tag.AddCssClass(css);

            return tag;
        }

        public static TagWrapper AddCss(this TagWrapper tag, string[] css)
        {
            foreach (var s in css)
                tag.AddCss(s);

            return tag;
        }

        public static TagWrapper AddId(this TagWrapper tag, string value)
        {
            return tag.AddAttribute("id", value);
        }

        public static TagWrapper AddAttribute(this TagWrapper tag, string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new Exception("TagDecorator function AddAttribute error: key undefined");

            tag.Attributes.Add(key, value);
            return tag;
        }

        public static TagWrapper AddAttributes(this TagWrapper tag, string[][] data)
        {
            foreach (var s in data)
                if (s.Length == 2)
                    tag.AddAttribute(s[0], s[1]);

            return tag;
        }

        public static TagWrapper AddAttributes(this TagWrapper tag, IDictionary<string, string> data)
        {
            foreach (var s in data)
                tag.AddAttribute(s.Key, s.Value);

            return tag;
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, string html)
        {
            tag.Tag.InnerHtml += html;

            return tag;
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, string[] htmls)
        {
            foreach (var s in htmls)
                tag.InnerHtml(s);

            return tag;
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, TagWrapper innerTag)
        {
            return tag.InnerHtml(innerTag.ToString());
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, TagWrapper[] innerTags)
        {
            foreach (var s in innerTags)
                tag.InnerHtml(s.ToString());

            return tag;
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, TagBuilder tagBuilder)
        {
            return tag.InnerHtml(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static TagWrapper InnerHtml(this TagWrapper tag, TagBuilder[] tagBuilders)
        {
            foreach (var s in tagBuilders)
                tag.InnerHtml(s);

            return tag;
        }
    }
}
