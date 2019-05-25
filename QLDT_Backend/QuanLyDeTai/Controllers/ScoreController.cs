using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class ScoreController : Controller
    {
        private ScoreService scoreService = new ScoreService();
        // GET: Score
        public ActionResult StudentScore()
        {
            return View();
        }

        public ActionResult ListScore()
        {
            return View();
        }

        public JsonResult GetByThucTap(long IDTT)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = scoreService.GetBySinhvienAndLoaiTT(IDTT,idsv);
            if (svtt==null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json(svtt, JsonRequestBehavior.AllowGet);
        }
    }
}