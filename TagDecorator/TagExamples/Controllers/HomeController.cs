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
        public ActionResult AlertsExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Alerts/AlertsHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Alerts/AlertsCode.txt"));
            var razor = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Alerts/AlertsRazor.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                RazorView = razor,
                ResultView = "~/Views/Alerts/Bs4AlertsViewPartial.cshtml"
            };

            return View(model);
        }

        public ActionResult BadgesExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Badges/BadgesHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Badges/BadgesCode.txt"));
            var razor = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Badges/BadgesRazor.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                RazorView = razor,
                ResultView = "~/Views/Badges/Bs4BadgesViewPartial.cshtml"
            };

            return View(model);
        }

        public ActionResult ButtonsExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Buttons/ButtonsHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Buttons/ButtonsCode.txt"));
            //var razor = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/Buttons/ButtonsRazor.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                //RazorView = razor,
                ResultView = "~/Views/Buttons/Bs4ButtonsViewPartial.cshtml"
            };

            return View(model);
        }

        public ActionResult InputGroupsExample()
        {
            var html = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/InputGroups/InputGroupsHtml.txt"));
            var code = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/InputGroups/InputGroupsCode.txt"));
            //var razor = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/InputGroups/InputGroupsRazor.txt"));
            var model = new ExampleTemplate()
            {
                HtmlView = html,
                CodeView = code,
                //RazorView = razor,
                ResultView = "~/Views/InputGroups/Bs4InputGroupsViewPartial.cshtml"
            };

            return View(model);
        }
    }
}