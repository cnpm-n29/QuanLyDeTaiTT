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
    public class TopicStudentController : BaseController
    {
        private TopicService deTaiService = new TopicService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        private StudentPracticeService sinhVienTTService = new StudentPracticeService();
        private StudentTeacherService phanCongGVService = new StudentTeacherService();
        // GET: DeTaiSinhVienTT
        public ActionResult ChooseTopic()
        {
            return View();
        }

        public JsonResult GetByThucTap(long IDTT)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
            var Giangvien = phanCongGVService.GetBySinhVien(idsv);
            long? idgv = Giangvien.TeacherID;
            long? IDLoaiTT = 0;
            IDLoaiTT = svtt.ID_TT;
            return Json(deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listLoaiTT(long? id = null)
        {
            PracticeService thucTapService = new PracticeService();
            return Json(thucTapService.GetAllLoaiTT(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(List<TopicStudentModel> list)
        {
            foreach (TopicStudentModel topicStudent in list)
            {
                long id_student = long.Parse(Session["UserId"].ToString());
                var sinhvienTT = sinhVienTTService.GetBySinhVienvaLoaiTT(id_student, topicStudent.SemesterID);
                topicStudent.StudentPracticeID = sinhvienTT.ID;
                var m = new TopicStudent
                {
                    StudentPracticeID = topicStudent.StudentPracticeID,
                    TopicID = topicStudent.TopicID,
                    Order = topicStudent.Order,
                    CreateBy = topicStudent.CreateBy,
                    CreateTime = topicStudent.CreateTime,
                };
                topicStudentService.Create(m);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTopic()
        {
            return View();
        }

        public JsonResult GetListByStudentPracticeID(long IDTT)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
            var Giangvien = phanCongGVService.GetBySinhVien(idsv);
            long? idgv = Giangvien.TeacherID;
            long? IDLoaiTT = 0;
            IDLoaiTT = svtt.ID_TT;
            return Json(deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv), JsonRequestBehavior.AllowGet);
        }
    }
}