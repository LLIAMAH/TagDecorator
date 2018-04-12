using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TagDecorator
{
    public class TagWrapper
    {
        private readonly TagBuilder _tb;

        public TagBuilder Tag { get { return this._tb; } }

        public TagWrapper(string tag)
        {
            this._tb = new TagBuilder(tag);
        }

        public TagWrapper(TagBuilder tb)
        {
            this._tb = tb;
        }

        public IDictionary<string, string> Attributes
        {
            get
            {
                if (Tag == null)
                    throw new Exception("TagWrapper Attributes properties call on null internal object.");

                return Tag.Attributes;
            }
        }

        public override string ToString()
        {
            return this._tb.ToString(TagRenderMode.Normal);
        }
    }
}
