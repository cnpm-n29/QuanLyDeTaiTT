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
    public class StudentSubjectController : BaseController
    {
        private StudentService studentService = new StudentService();
        private StudentSubjectService studentSubjectService = new StudentSubjectService();
        // GET: StudentSubject
        public ActionResult Index()
        {
            ViewBag.active = "StudentSubjectIndex";
            return View();
        }

        public JsonResult GetByMaKhoaHoc(long IDKH,long IDBM)
        {
            var query=studentService.GetByFacultyID(IDKH);
            var subject=new List<string>();
            var student = new List<Object>();
            var studentsubject = new List<Object>();
            foreach (var i in query)
            {
                var sb=studentSubjectService.getByStudentId(i.ID);
                if (sb == null)
                {
                    student.Add(i);
                    subject.Add(null);
                }
                else if (sb.ID != IDBM)
                {
                    student.Add(i);
                    subject.Add(sb.SubjectName);
                }
                else
                {
                    studentsubject.Add(i);
                }
            }


            return Json(new {Studentsubject=studentsubject, Student = student,SubjectName=subject }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetForReturn(long IDSV)
        {
            var query = studentService.GetById(IDSV);
            var subject = new List<string>();
            var student = new List<Object>();
                var sb = studentSubjectService.getByStudentId(query.ID);
                if (sb == null)
                {
                    student.Add(query);
                    subject.Add(null);
                }
                else
                {
                    student.Add(query);
                    subject.Add(sb.SubjectName);
                }


            return Json(new { Student = student, SubjectName = subject }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(long IDSV)
        {
            return Json(studentSubjectService.Delete(IDSV, Convert.ToInt32(Session["UserId"])), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(List<string> list,string IDBM)
        {
            foreach(var i in list)
            {
                var sb = studentSubjectService.getByStudentId(Convert.ToInt32(i));
                if (sb == null)
                {
                    var model = new StudentSubjectRelationship{
                        StudentID = Convert.ToInt32(i),
                        SubjectID = Convert.ToInt32(IDBM),
                        CreateBy = Convert.ToInt32(Session["UserId"])
                    };
                    studentSubjectService.Create(model);
                }
                else
                {
                    var model = new StudentSubjectRelationship
                    {
                        StudentID = Convert.ToInt32(i),
                        SubjectID = Convert.ToInt32(IDBM),
                        ModifyBy = Convert.ToInt32(Session["UserId"])
                    };
                    studentSubjectService.Update(model);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        
    }
}