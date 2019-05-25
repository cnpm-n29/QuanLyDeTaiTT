using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class TopicStudentController : BaseController
    {
        private PracticeService practiceService = new PracticeService();
        private TopicService deTaiService = new TopicService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        private StudentPracticeService sinhVienTTService = new StudentPracticeService();
        private StudentTeacherService phanCongGVService = new StudentTeacherService();
        // GET: DeTaiSinhVienTT
        public ActionResult ChooseTopic()
        {
            return View();
        }

        public JsonResult GetByThucTap(long IDTT,string search , int pageNumber = 0, int pageSize = 10)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
            if (svtt == null)
            {
                return Json(new { TotalRecords = 0, Error = "Chưa được phân thực tập" }, JsonRequestBehavior.AllowGet);
            }
            var status = topicStudentService.CheckTopicUser(svtt.ID);
            var detai = topicStudentService.getTopicChoose(svtt.ID);
            
            if (status!=null&&detai==null){
                return Json(new { TotalRecords = 0, Error = "Đã chọn đề tài, chờ giáo viên hướng dẫn chốt" }, JsonRequestBehavior.AllowGet);
            }
            else if (detai != null)
            {
                var dt = new TopicModel
                {
                    TopicName = detai.TopicName,
                    Description = detai.Description
                };
                return Json(new { TotalRecords = 0, Detai = dt }, JsonRequestBehavior.AllowGet);
            }
            var Giangvien = phanCongGVService.GetBySinhVien(idsv);
            if (Giangvien != null&&svtt!=null)
            {
                long? idgv = Giangvien.TeacherID;
                long? IDLoaiTT = svtt.PracticeTypeID;
                var total = deTaiService.getCount(IDLoaiTT, idgv, search);
                var list = deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv, search, pageNumber, pageSize);
                return Json(new { TotalRecords = total, List = list }, JsonRequestBehavior.AllowGet);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = 0, Error = "Chưa được phân giảng viên" }, JsonRequestBehavior.AllowGet);
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

        //public JsonResult GetListByStudentPracticeID(long IDTT)
        //{
        //    long idsv = long.Parse(Session["UserId"].ToString());
        //    var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
        //    var Giangvien = phanCongGVService.GetBySinhVien(idsv);
        //    long? idgv = Giangvien.TeacherID;
        //    long? IDLoaiTT = 0;
        //    IDLoaiTT = svtt.ID_TT;
        //    return Json(deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetListForSave(long IDHK, long IDTT,string search, int pageNumber=0, int pageSize=100)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = deTaiService.getCount(thuctap.ID, id_gv, search);
            var list = deTaiService.GetListByTTvaMaGV(thuctap.ID, id_gv, search, pageNumber, pageSize);
            var count=new List<int>();
            IQueryable listStudent;
            for(int i=0;i<list.Count();i++)
            {
                count.Add(topicStudentService.getCount(list.ToArray()[i].ID));
                listStudent = topicStudentService.GetListByTopicId(list.ToArray()[i].ID);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = list,Count=count}, JsonRequestBehavior.AllowGet);
            

        }

        public JsonResult getListByTopicId(long TopicID)
        {
            return Json(topicStudentService.GetListByTopicId(TopicID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(long id)
        {
            return Json(topicStudentService.ChangeStatus(id), JsonRequestBehavior.AllowGet);
        }
    }
}