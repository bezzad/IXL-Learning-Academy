using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using IXL.Resources;

namespace IXL.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = Localization.Home;
            ViewBag.BodyClass = "main";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = Localization.About;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = Localization.Contact;
            return View();
        }
    }
}