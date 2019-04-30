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
            return View();
        }

        public ActionResult LoginByCredential(LoginModel model)
        {
            SinhVienService sinhVienService = new SinhVienService();
            GiangVienService giangVienService = new GiangVienService();
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
                        foreach (string item in list)
                        {
                            Session[item] = item;
                        }
                        Session["UserId"] = lg.ID;
                        Session["Username"] = lg.MaGV;
                        Session["Fullname"] = lg.Ho + " " + lg.Ten;
                        return Redirect("/Home/Index");
                    }
                }
                else
                {
                    Session["UserId"] = login.ID;
                    Session["Username"] = login.MaSV;
                    Session["Fullname"] = login.Ho + " " + login.Ten;
                    return Redirect("/Home/SinhVien");
                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
            }
            return View("Index");
        }
    }
}