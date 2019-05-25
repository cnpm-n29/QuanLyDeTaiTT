using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class StudentTeacherController : BaseController
    {
        private StudentService studentService = new StudentService();
        private TeacherService teacherService = new TeacherService();
        private StudentTeacherService StudentTeacherService = new StudentTeacherService();
        // GET: StudentTeacher
        public ActionResult AssignedTeacher()
        {
            return View();
        }

        public ActionResult InstructorInfo()
        {
            return View();
        }


        public JsonResult GetByMaKhoaHoc(long IDKH, long IDGV)
        {
            var tc = teacherService.GetByMagv(Session["Username"].ToString());
            var query = studentService.GetByFacultyIDandSubjectId(IDKH,tc.SubjectID);
            var teacher = new List<string>();
            var student = new List<Object>();
            var studentTeacher = new List<Object>();
            foreach (var i in query)
            {
                var sb = StudentTeacherService.getByStudentId(i.ID);
                if (sb == null)
                {
                    student.Add(i);
                    teacher.Add(null);
                }
                else if (sb.ID != IDGV)
                {
                    student.Add(i);
                    teacher.Add(sb.FirstName+" "+sb.LastName);
                }
                else
                {
                    studentTeacher.Add(i);
                }
            }


            return Json(new { StudentTeacher = studentTeacher, Student = student, TeacherName = teacher }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetForReturn(long IDSV)
        {
            var query = studentService.GetById(IDSV);
            var teacher = new List<string>();
            var student = new List<Object>();
            var sb = StudentTeacherService.getByStudentId(query.ID);
            if (sb == null)
            {
                student.Add(query);
                teacher.Add(null);
            }
            else
            {
                student.Add(query);
                teacher.Add(sb.FirstName + " " + sb.LastName);
            }


            return Json(new { Student = student, TeacherName = teacher }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(long IDSV)
        {
            return Json(StudentTeacherService.Delete(IDSV, Convert.ToInt32(Session["UserId"])), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(List<string> list, string IDGV)
        {
            foreach (var i in list)
            {
                var sb = StudentTeacherService.getByStudentId(Convert.ToInt32(i));
                if (sb == null)
                {
                    var model = new StudentTeacherRelationship
                    {
                        StudentID = Convert.ToInt32(i),
                        TeacherID = Convert.ToInt32(IDGV),
                        CreateBy = Convert.ToInt32(Session["UserId"])
                    };
                    StudentTeacherService.Create(model);
                }
                else
                {
                    var model = new StudentTeacherRelationship
                    {
                        StudentID = Convert.ToInt32(i),
                        TeacherID = Convert.ToInt32(IDGV),
                        ModifyBy = Convert.ToInt32(Session["UserId"])
                    };
                    StudentTeacherService.Update(model);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getInfo()
        {
            var st = Session["UserID"].ToString();
            return Json(StudentTeacherService.GetInfoStudentAndTeacher(Convert.ToInt32(st)), JsonRequestBehavior.AllowGet);
        }
    }
}