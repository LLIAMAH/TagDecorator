using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TagExamples.Models
{
    public class ExampleTemplate
    {
        [Display(Name = "C#:")]
        // Done by: https://www.pvladov.com/p/syntax-highlighter.html
        public string CodeView { get; set; }
        [Display(Name = "HTML:")]
        public string HtmlView { get; set; }

        [Display(Name = "Result:")]
        public string ResultView { get; set; }
    }
}