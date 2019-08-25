using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class StudentFieldController : BaseController
    {
        // GET: StudentField
        FieldService fieldService = new FieldService();
        StudentFieldService StudentFieldService = new StudentFieldService();
        private StudentService studentService = new StudentService();
        public ActionResult ChooseField()
        {
            return View();
        }

        public JsonResult GetList()
        {
            return Json(fieldService.GetListField(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListByStudent()
        {
            var idsv = studentService.GetByMasv(Session["Username"].ToString()).ID;
            return Json(StudentFieldService.GetByStudent(idsv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(long FieldId)
        {
            StudentFieldRelationship studentField = new StudentFieldRelationship();
            studentField.StudentID = studentService.GetByMasv(Session["Username"].ToString()).ID;
            studentField.FieldID = FieldId;
            return Json(StudentFieldService.Create(studentField), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long FieldId)
        {
            var idsv = studentService.GetByMasv(Session["Username"].ToString()).ID;
            var id = StudentFieldService.GetByStudentandField(idsv, FieldId).ID;
            return Json(StudentFieldService.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}