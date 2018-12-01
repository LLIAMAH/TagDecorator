﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                CodeView = code
            };
            return View(model);
        }
    }
}