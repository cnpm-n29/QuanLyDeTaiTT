using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class TopicController : BaseController
    {
        private TopicService topicService = new TopicService();
        private PracticeService practiceService  = new PracticeService();
        // GET: DeTai
        public ActionResult Index()
        {
            if (Session["Quyen"].ToString().Contains("Thêm, Sửa,Xóa đề tài"))
            {
                //listHocKy1();
                return View();
            }
            return Redirect("~/Error/Index");
        }

        

        public JsonResult Add(TopicModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.TeacherID = id_gv;
            var tt = practiceService.GetByLoaiTTvaHocKy(model.PracticeID, model.SemesterID);
            model.PracticeTypeID = tt.ID;
            var m = new Topic
            {
                TeacherID = model.TeacherID,
                PracticeTypeID = model.PracticeTypeID,
                TopicName = model.TopicName,
                Description = model.Description,
                Status = model.Status
            };
            return Json(topicService.Create(m), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(Models.TopicModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.TeacherID = id_gv;
            var tt = practiceService.GetByLoaiTTvaHocKy(model.PracticeID, model.SemesterID);
            model.PracticeTypeID = tt.ID;
            var m = new Topic
            {
                ID=model.ID,
                PracticeTypeID = model.PracticeTypeID,
                TopicName = model.TopicName,
                Description = model.Description,
                Status = model.Status
            };
            return Json(topicService.Update(m), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            return Json(topicService.Delete(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listLoaiTT()
        {
            var result= practiceService.GetAllLoaiTT();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public void listHocKy1(long? id = null)
        //{
        //    ViewBag.ID_HocKy = new SelectList(thucTapService.GetAllHocKy(), "ID", "TenHocKy", id);
        //}

        //public void listLoaiTT1(long? id = null)
        //{
        //    ViewBag.ID_LoaiTT = new SelectList(thucTapService.GetAllLoaiTT(), "ID", "TenThucTap", id);
        //}

        public JsonResult listHocKy()
        {
            var result = practiceService.GetAllHocKy();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listDeTai()
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            return Json(topicService.GetList(id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            return Json(topicService.GetById(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK,long IDTT)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var rs = topicService.GetListByTTvaMaGV(thuctap.ID, id_gv);
            return Json(topicService.GetListByTTvaMaGV(thuctap.ID,id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoaiTTByHK(long? ID)
        {   
            return Json(practiceService.GetByHocKy(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(long id)
        {
            return Json(topicService.ChangeStatus(id), JsonRequestBehavior.AllowGet);
        }
    }
}