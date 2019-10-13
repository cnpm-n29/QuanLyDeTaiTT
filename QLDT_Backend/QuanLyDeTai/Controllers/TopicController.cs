using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace QuanLyDeTai.Controllers
{
    public class TopicController : BaseController
    {
        private TopicService topicService = new TopicService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        private PracticeService practiceService  = new PracticeService();
        private TeacherService teacherService = new TeacherService();
        // GET: DeTai
        public ActionResult Index()
        {
            ViewBag.id = "TopicIndex";
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
                FieldID=model.FieldID,
                TopicName = model.TopicName,
                Description = model.Description,
                Status = model.Status
            };
            return Json(topicService.Create(m), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(TopicModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.TeacherID = id_gv;
            var tt = practiceService.GetByLoaiTTvaHocKy(model.PracticeID, model.SemesterID);
            model.PracticeTypeID = tt.ID;
            var m = new Topic
            {
                ID=model.ID,
                PracticeTypeID = model.PracticeTypeID,
                FieldID = model.FieldID,
                TopicName = model.TopicName,
                Description = model.Description,
                Status = model.Status
            };
            return Json(topicService.Update(m), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            if (topicStudentService.CheckTopic(id))
            {
                return Json("ErrorCheck", JsonRequestBehavior.AllowGet);
            }
            return Json(topicService.Delete(id), JsonRequestBehavior.AllowGet);
        }
        

        //public void listHocKy1(long? id = null)
        //{
        //    ViewBag.ID_HocKy = new SelectList(thucTapService.GetAllHocKy(), "ID", "TenHocKy", id);
        //}

        //public void listLoaiTT1(long? id = null)
        //{
        //    ViewBag.ID_LoaiTT = new SelectList(thucTapService.GetAllLoaiTT(), "ID", "TenThucTap", id);
        //}
        

        public JsonResult listDeTai()
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            return Json(topicService.GetList(id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            return Json(topicService.GetById(ID), JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetByKHvaLoaiTT(long IDHK,long IDTT)
        //{
        //    long id_gv = long.Parse(Session["UserId"].ToString());
        //    var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
        //    var rs = topicService.GetListByTTvaMaGV(thuctap.ID, id_gv);
        //    return Json(topicService.GetListByTTvaMaGV(thuctap.ID,id_gv), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT,string search, int pageNumber=0, int pageSize=10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = topicService.getCount(thuctap.ID,id_gv,search);
            var list = topicService.GetListByTTvaMaGV1(thuctap.ID, id_gv,search,pageNumber,pageSize);    

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList(long IDHK, long IDTT,long? id_bm, string search, int pageNumber = 0, int pageSize = 10)
        {
            var tc = teacherService.GetByMagv(Session["Username"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            
            var i = 0;
            IQueryable listtc;
            if (teacherService.GetRole(Session["Username"].ToString(), "Trưởng bộ môn"))
            {
                listtc = topicService.GetListByTT(thuctap.ID, tc.ID, search, pageNumber, pageSize);
                i = topicService.GetListByTTCount(thuctap.ID, tc.ID, search, pageNumber, pageSize);
            }
            else if (teacherService.GetRole(Session["Username"].ToString(), "Viện trưởng")|| teacherService.GetRole(Session["Username"].ToString(), "Viện phó"))
            {
                listtc= topicService.GetListByTTAll(thuctap.ID,id_bm, search, pageNumber, pageSize);
                i = topicService.GetListByTTAllCount(thuctap.ID,id_bm, search, pageNumber, pageSize);
            }
            else { 
                listtc = topicService.GetListByTTAndSubjectId(thuctap.ID, tc.ID, tc.SubjectID, search, pageNumber, pageSize);
                i = topicService.GetListByTTAndSubjectIdCount(thuctap.ID, tc.ID, tc.SubjectID, search, pageNumber, pageSize);
                }
            return Json(new { TotalRecords = i, List = listtc }, JsonRequestBehavior.AllowGet);
            
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