using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class AdditionalController : Controller
    {
        // GET: Additional
        public ActionResult ListTopic()
        {
            return View("ListTopic");
        }

        public ActionResult ListPractice()
        {
            return View("ListPractice");
        }

        public ActionResult ListScore()
        {
            return View("ListScore");
        }
    }
}