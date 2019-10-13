using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class AdditionalController : BaseController
    {
        // GET: Additional
        public ActionResult ListTopic()
        {
            ViewBag.active = "ListTopic";
            return View("ListTopic");
        }

        public ActionResult ListPractice()
        {
            ViewBag.active = "ListPractice";
            return View("ListPractice");
        }

        public ActionResult ListScore()
        {
            ViewBag.active = "ListScoreNoEdit";
            return View("ListScore");
        }
    }
}