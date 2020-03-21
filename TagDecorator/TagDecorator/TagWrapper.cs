using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TagDecorator
{
    /// <summary>
    /// Class which has been created to avoid Intellisense to show helpers which assigned on TagBuilder
    /// </summary>
    public class TagWrapper
    {
        public TagBuilder Tag { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tag">The name of tag</param>
        public TagWrapper(string tag)
        {
            this.Tag = new TagBuilder(tag);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tb">The original MVC <see cref="TagBuilder"/></param>
        public TagWrapper(TagBuilder tb)
        {
            this.Tag = tb;
        }

        /// <summary>
        /// Tag Attributes
        /// </summary>
        public IDictionary<string, string> Attributes
        {
            get
            {
                if (Tag == null)
                    throw new Exception("TagWrapper Attributes properties call on null internal object.");

                return Tag.Attributes;
            }
        }

        /// <summary>
        /// Overriden ToString to return self closed tag
        /// </summary>
        /// <returns>Self closed tag</returns>
        public override string ToString()
        {
            return this.Tag.ToString(TagRenderMode.Normal);
        }

        /// <summary>
        /// Required to return unclosed tag (required for such cases)
        /// </summary>
        /// <returns>Unclosed tag</returns>
        public Tags TagsUnclosed()
        {
            return new Tags(this.Tag);
        }
    }
}
