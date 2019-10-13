using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.active = null;
            ViewBag.id = null;
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }
    }
}