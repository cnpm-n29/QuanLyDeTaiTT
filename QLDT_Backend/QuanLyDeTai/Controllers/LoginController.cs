using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.RemoveAll();
            return View();
        }

        public ActionResult LoginByCredential(LoginModel model)
        {
            StudentService sinhVienService = new StudentService();
            TeacherService giangVienService = new TeacherService();
            if (ModelState.IsValid)
            {
                var login = sinhVienService.LoginByCredential(model.Username,model.Password);
                if (login == null)
                {
                    var lg = giangVienService.LoginByCredential(model.Username, model.Password);
                    if (lg == null)
                    {
                        ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
                    }
                    else
                    {
                        //List<String> list = giangVienService.XetQuyen(lg.ID);
                        IQueryable list = giangVienService.XetQuyen(lg.ID);
                        Session["Quyen"] = "";
                        foreach (string item in list)
                        {
                            Session["Quyen"] += " "+item;
                        }
                        Session["UserId"] = lg.ID;
                        Session["Username"] = lg.MaGV;
                        Session["Fullname"] = lg.FirstName + " " + lg.LastName;
                        return Redirect("/Home/Index");
                    }
                }
                else
                {
                    Session["UserId"] = login.ID;
                    Session["Username"] = login.MaSV;
                    Session["Fullname"] = login.FirstName + " " + login.LastName;
                    return Redirect("/Home/Student");
                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return View("Index");
        }
    }
}