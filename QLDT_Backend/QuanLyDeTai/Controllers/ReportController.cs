using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class ReportController : Controller
    {
        private ReportService reportService = new ReportService();
        // GET: Report
        public ActionResult Index()
        {
            ViewBag.actice = "ReportIndex";
            return View();
        }

        public JsonResult Add(Report model)
        {
            model.CreateBy = long.Parse(Session["UserId"].ToString());
            bool status = reportService.Create(model);

            return Json(status, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(Report model)
        {
            model.ModifyBy = long.Parse(Session["UserId"].ToString());

            bool status = reportService.Update(model);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            return Json(reportService.Delete(id, long.Parse(Session["UserId"].ToString())), JsonRequestBehavior.AllowGet);
        }
    }
}