using System.Web.Mvc;
using TagExamples.Models;

namespace TagExamples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ButtonsExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Buttons/ButtonsHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Buttons/ButtonsCode.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                ResultView = "~/Views/Buttons/Bs4ButtonsViewPartial.cshtml"
            };
            return View(model);
        }

        public ActionResult InputGroupsExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/InputGroups/InputGroupsHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/InputGroups/InputGroupsCode.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                ResultView = "~/Views/InputGroups/Bs4InputGroupsViewPartial.cshtml"
            };

            return View(model);
        }
    }
}