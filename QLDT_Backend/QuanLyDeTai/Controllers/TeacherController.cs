using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class TeacherController : BaseController
    {
        private TeacherService teacherService = new TeacherService();
        // GET: Teacher
        public ActionResult ListTeacherSubject()
        {
            return View();
        }

        public JsonResult GetListBySubjectId(string magv,string teachername,int pageNumber = 0, int pageSize = 10)
        {
            var tc = teacherService.GetByMagv(Session["Username"].ToString());
            var listtc = teacherService.getListBySubjectIdSort(tc.SubjectID,magv,teachername,pageNumber,pageSize);
            var list = new List<TeacherModel>();
            foreach(var i in listtc)
            {
                var teacher = new TeacherModel
                {
                    MaGV = i.MaGV,
                    FirstName = i.FirstName,
                    LastName=i.LastName,
                    Birthday= i.Birthday.Value.Day + "/" + i.Birthday.Value.Month + "/" + i.Birthday.Value.Year,
                    Sex=i.Sex,
                    Email=i.Email,
                    Phone=i.Phone,
                    Address=i.Address,
                    Note=i.Note
                };
                list.Add(teacher);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}