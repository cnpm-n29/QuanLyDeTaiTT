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
    public class NotificationController : BaseController
    {
        private StudentService StudentService = new StudentService();
        private NotificationService notification = new NotificationService();
        private StudentNotificationService studentNotification = new StudentNotificationService();
        private PracticeService practiceService = new PracticeService();
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetbyStudentID()
        {
            long id = long.Parse(Session["UserId"].ToString());
            return Json(studentNotification.GetList(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(long id)
        {
            return Json(studentNotification.ChangeStatus(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyStudentIDLimit()
        {
            long id = long.Parse(Session["UserId"].ToString());
            return Json(studentNotification.GetListLimit(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            return Json(notification.GetById(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            
            var list = notification.GetListByTTvaMaGV(thuctap.ID, id_gv);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(list , JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(NotificationModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.TeacherID = id_gv;
            
            var tt = practiceService.GetByLoaiTTvaHocKy(model.PracticeID, model.SemesterID);
            model.PracticeTypeID = tt.ID;
            var student = StudentService.getListByTeacherIdAndPracticeId(id_gv,tt.ID);
            var m = new Notification
            {
                TeacherID = model.TeacherID,
                PracticeTypeID = model.PracticeTypeID,
                Title = model.Title,
                Content = model.Content,
                CreateBy=model.TeacherID
            };
            bool status=notification.Create(m);
            var nt = notification.returnId();
            foreach(var st in student)
            {
                StudentNotificationRelationship s = new StudentNotificationRelationship();
                s.StudentID = st.ID;
                s.NotificationID = nt;
                studentNotification.Create(s);
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(NotificationModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.TeacherID = id_gv;
            //var tt = practiceService.GetByLoaiTTvaHocKy(model.PracticeID, model.SemesterID);
            //model.PracticeTypeID = tt.ID;
            var m = new Notification
            {
                ID = model.ID,
                //PracticeTypeID = model.PracticeTypeID,
                Title = model.Title,
                Content = model.Content,
                CreateBy = model.TeacherID
            };
            return Json(notification.Update(m), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            return Json(notification.Delete(id,id_gv), JsonRequestBehavior.AllowGet);
        }
    }
}