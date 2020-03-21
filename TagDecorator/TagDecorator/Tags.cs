using System.Web.Mvc;

namespace TagDecorator
{
    /// <summary>
    /// Class for tag blocks
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// Begin tag
        /// </summary>
        public string Begin { get; }

        /// <summary>
        /// Close tag
        /// </summary>
        public string End { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tb"><see cref="TagBuilder"/></param>
        public Tags(TagBuilder tb)
        {
            this.Begin = tb.ToString(TagRenderMode.StartTag);
            this.End = tb.ToString(TagRenderMode.EndTag);
        }
    }
}
