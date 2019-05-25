using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class ListController : BaseController
    {
        private PracticeService practiceService = new PracticeService();
        private FacultyService facultyService = new FacultyService();
        private SubjectService subjectService = new SubjectService();
        private TeacherService teacherService = new TeacherService();
        public JsonResult listLoaiTT()
        {
            var result = practiceService.GetAllLoaiTT();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listHocKy()
        {
            var result = practiceService.GetAllHocKy();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listKhoaHoc()
        {
            var result = facultyService.GetAllFaculty();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listBoMon()
        {
            var result = subjectService.GetAllSubject();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListGiangVien()
        {
            var teacher = teacherService.GetByMagv(Session["Username"].ToString());
            var result = teacherService.getListBySubjectId(teacher.SubjectID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}