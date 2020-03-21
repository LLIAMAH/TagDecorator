using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TagDecorator
{
    /// <summary>
    /// Static class which provide whole lis of Helpers for <see cref="TagWrapper"/>
    /// </summary>
    public static class TagDecorator
    {
        /// <summary>
        /// Converts <see cref="TagBuilder"/> to <see cref="TagWrapper"/>
        /// </summary>
        /// <param name="tb"><see cref="TagBuilder"/></param>
        /// <returns><see cref="TagWrapper"/></returns>
        public static TagWrapper ToTag(this TagBuilder tb)
        {
            return new TagWrapper(tb);
        }

        /// <summary>
        /// Converts <see cref="TagBuilder"/> to <see cref="TagWrapper"/>
        /// </summary>
        /// <param name="tag">String name for tag, which must be created</param>
        /// <returns><see cref="TagWrapper"/></returns>
        public static TagWrapper ToTag(this string tag)
        {
            return new TagWrapper(tag);
        }

        /// <summary>
        /// Creates <see cref="MvcHtmlString"/> from <see cref="TagWrapper"/>
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <returns><see cref="MvcHtmlString"/></returns>
        public static MvcHtmlString ToHtmlString(this TagWrapper tag)
        {
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Set internal text for tag
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="text">Text</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper SetText(this TagWrapper tag, string text)
        {
            tag.Tag.SetInnerText(text);
            return tag;
        }

        /// <summary>
        /// Add CSS class to tag
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="css">CSS class to add</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddCss(this TagWrapper tag, string css)
        {
            if (!string.IsNullOrEmpty(css))
                tag.Tag.AddCssClass(css);

            return tag;
        }

        /// <summary>
        /// Add CSS classes to tag
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="css">The array of CSS class to add</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddCss(this TagWrapper tag, string[] css)
        {
            if (css != null)
                foreach (var s in css)
                    tag.AddCss(s);

            return tag;
        }

        /// <summary>
        /// Add CSS class to tag only if <paramref name="condition"/> - <c>true</c>
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="css">CSS class to add</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddCssIf(this TagWrapper tag, bool condition, string css)
        {
            if (condition && !string.IsNullOrEmpty(css))
                tag.Tag.AddCssClass(css);

            return tag;
        }

        /// <summary>
        /// Add CSS classes to tag only if <paramref name="condition"/> - <c>true</c>
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="css">The array of CSS class to add</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddCssIf(this TagWrapper tag, bool condition, string[] css)
        {
            if (css != null)
                foreach (var item in css)
                    tag.AddCssIf(condition, item);

            return tag;
        }

        /// <summary>
        /// Add "data-*" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="suffix">Suffix for "data-*" attribute</param>
        /// <param name="value">"data-*" attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddData(this TagWrapper tag, string suffix, string value)
        {
            if (string.IsNullOrEmpty(suffix))
                return tag;            

            if (string.IsNullOrEmpty(value))
                return tag;

            tag.AddAttribute($"data-{suffix}", value);
            return tag;
        }

        /// <summary>
        /// Add "aria-*" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="suffix">Suffix for "aria-*" attribute</param>
        /// <param name="value">"aria-*" attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAria(this TagWrapper tag, string suffix, string value)
        {
            if (string.IsNullOrEmpty(suffix))
                return tag;

            if (string.IsNullOrEmpty(value))
                return tag;

            tag.AddAttribute($"aria-{suffix}", value);
            return tag;
        }

        /// <summary>
        /// Add "role" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value">Role attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddRole(this TagWrapper tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return tag;

            tag.AddAttribute("role", value);
            return tag;
        }

        /// <summary>
        /// Add "id" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value">Id attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddId(this TagWrapper tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return tag;

            value = value.TrimStart(new[] { '#' });
            return tag.AddAttribute("id", value);
        }

        /// <summary>
        /// Add "id" attribute with value only if <paramref name="condition"/> - <c>true</c>
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="value">Id attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddIdIf(this TagWrapper tag, bool condition, string value)
        {
            if(condition && !string.IsNullOrEmpty(value))
                return tag.AddId(value);

            return tag;
        }

        /// <summary>
        /// Add "name" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value">Name attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddName(this TagWrapper tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return tag;

            value = value.TrimStart(new[] { '#' });
            return tag.AddAttribute("name", value);
        }

        /// <summary>
        /// Add "type" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value">Type attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddType(this TagWrapper tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return tag;

            return tag.AddAttribute("type", value);
        }

        /// <summary>
        /// Add <c>for</c> attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value">Type attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddFor(this TagWrapper tag, string value)
        {
            if (string.IsNullOrEmpty(value))
                return tag;

            return tag.AddAttribute("for", value);
        }

        /// <summary>
        /// Add "href" attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="reference">Href attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddReference(this TagWrapper tag, string reference)
        {
            if (string.IsNullOrEmpty(reference))
                return tag;

            return tag.AddAttribute("href", reference);
        }

        /// <summary>
        /// Add attribute with any name.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAttribute(this TagWrapper tag, string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new Exception("TagDecorator function AddAttribute error: key undefined");

            if (!string.IsNullOrEmpty(value))
                tag.Attributes.Add(key, value);

            return tag;
        }

        /// <summary>
        /// Add attribute with any name only if <paramref name="condition"/> - <c>true</c>.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAttributeIf(this TagWrapper tag, bool condition, string key, string value)
        {
            if (condition)
                tag.AddAttribute(key, value);

            return tag;
        }

        /// <summary>
        /// Add the array of attributes which name and value defines by internal array[2].
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="data">Array of array[2] - key/value pair</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAttributes(this TagWrapper tag, string[][] data)
        {
            if (data != null)
                foreach (var s in data)
                    if (s.Length == 2)
                        tag.AddAttribute(s[0], s[1]);

            return tag;
        }

        /// <summary>
        /// Add the key value dictionary.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="data"><see cref="IDictionary{TKey,TValue}"/></param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAttributes(this TagWrapper tag, IDictionary<string, string> data)
        {
            if (data != null)
                foreach (var s in data)
                    tag.AddAttribute(s.Key, s.Value);

            return tag;
        }

        /// <summary>
        /// Add the array of attributes which name and value defines by internal array[2] only if <paramref name="condition"/> - <c>true</c>.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="data">Array of array[2] - key/value pair</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AddAttributesIf(this TagWrapper tag, bool condition, string[][] data)
        {
            if (condition)
                tag.AddAttributes(data);

            return tag;
        }

        /// <summary>
        /// Add to current tag - inner HTML-string.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="html">Internal HTML-string</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, string html)
        {
            if (!string.IsNullOrEmpty(html))
                tag.Tag.InnerHtml += html;

            return tag;
        }

        /// <summary>
        /// Add to current tag - the array of HTML-string.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="htmls">Array of internal HTML-strings</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, string[] htmls)
        {
            foreach (var s in htmls)
                tag.InnerHtml(s);

            return tag;
        }

        /// <summary>
        /// Add to current tag - <see cref="TagWrapper"/> inner item
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="innerTag"><see cref="TagWrapper"/> inner item</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, TagWrapper innerTag)
        {
            if(innerTag != null)
                tag.InnerHtml(innerTag.ToString());

            return tag;
        }

        /// <summary>
        /// Add to current tag - <see cref="TagWrapper"/> inner item only if <paramref name="condition"/> - <c>true</c>
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="condition">Condition, which define will be added content or not </param>
        /// <param name="innerTag"><see cref="TagWrapper"/> inner item</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtmlIf(this TagWrapper tag, bool condition, TagWrapper innerTag)
        {
            if (condition)
                tag.InnerHtml(innerTag);

            return tag;
        }

        /// <summary>
        /// Add to current tag - list of <see cref="TagWrapper"/> inner items.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="innerTags">The list of <see cref="TagWrapper"/> inner item</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, List<TagWrapper> innerTags)
        {
            return tag.InnerHtml(innerTags.ToArray());
        }

        /// <summary>
        /// Add to current tag - array of <see cref="TagWrapper"/> inner items.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="innerTags">The array of <see cref="TagWrapper"/> inner item</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, TagWrapper[] innerTags)
        {
            foreach (var s in innerTags)
                tag.InnerHtml(s.ToString());

            return tag;
        }

        /// <summary>
        /// Add to current tag - <see cref="TagBuilder"/> inner item.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="tagBuilder"><see cref="TagBuilder"/> inner item</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, TagBuilder tagBuilder)
        {
            return tag.InnerHtml(tagBuilder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Add to current tag - array of <see cref="TagBuilder"/> inner items.
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="tagBuilders">The array of <see cref="TagBuilder"/> inner items</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper InnerHtml(this TagWrapper tag, TagBuilder[] tagBuilders)
        {
            foreach (var s in tagBuilders)
                tag.InnerHtml(s);

            return tag;
        }

        /// <summary>
        /// Adds <c>asp-for</c> Core attribute with name
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspFor(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-for", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-area</c> Core attribute with name
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspArea(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-area", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-controller</c> Core attribute with name
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspController(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-controller", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-action</c> Core attribute with name
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspAction(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-action", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-route-*</c> Core attribute with suffix and value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="suffix"><c>asp-route-*</c> suffix</param>
        /// <param name="value"><c>asp-route-*</c> value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspRoute(this TagWrapper tag, string suffix, string value)
        {
            tag.AddAttribute($"asp-route-{suffix}", value);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-route</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name"><c>asp-route</c> name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspRoute(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-route", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-fragment</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="value"><c>asp-fragment</c> value</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspFragment(this TagWrapper tag, string value)
        {
            tag.AddAttribute($"asp-fragment", value);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-protocol</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspProtocol(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-protocol", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-host</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspHost(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-host", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-page</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspPage(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-page", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>asp-page-handler</c> Core attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper AspPageHandler(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"asp-page-handler", name);
            return tag;
        }

        /// <summary>
        /// Adds <c>method</c> attribute with value
        /// </summary>
        /// <param name="tag"><see cref="TagWrapper"/></param>
        /// <param name="name">Attribute value name</param>
        /// <returns>Changed <see cref="TagWrapper"/></returns>
        public static TagWrapper Method(this TagWrapper tag, string name)
        {
            tag.AddAttribute($"method", name);
            return tag;
        }
    }
}
