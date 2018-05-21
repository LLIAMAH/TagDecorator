using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TagDecorator
{
    public class Tags
    {
        public string Begin { get; private set; }
        public string End { get; private set; }

        public Tags(TagBuilder tb)
        {
            this.Begin = tb.ToString(TagRenderMode.StartTag);
            this.End = tb.ToString(TagRenderMode.EndTag);
        }
    }
}
