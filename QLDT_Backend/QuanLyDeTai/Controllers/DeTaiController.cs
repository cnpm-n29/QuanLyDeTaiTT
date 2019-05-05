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
    public class DeTaiController : BaseController
    {
        private DeTaiService deTaiService = new DeTaiService();
        private ThucTapService thucTapService  = new ThucTapService();
        // GET: DeTai
        public ActionResult Index()
        {
            if (Session["Thêm, Sửa,Xóa đề tài"] != null)
            {
                //listHocKy1();
                return View();
            }
            return Redirect("~/Error/Index");
        }

        

        public JsonResult Add(DeTaiModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.ID_GiangVien = id_gv;
            var tt = thucTapService.GetByLoaiTTvaHocKy(model.ID_LoaiTT, model.ID_HocKy);
            model.ID_ThucTap = tt.ID;
            var m = new DeTai
            {
                ID_GiangVien = model.ID_GiangVien,
                ID_ThucTap = model.ID_ThucTap,
                TenDeTai = model.TenDeTai,
                MoTa = model.MoTa,
                TrangThai = model.TrangThai
            };
            return Json(deTaiService.Create(m), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(DeTaiModel model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.ID_GiangVien = id_gv;
            var tt = thucTapService.GetByLoaiTTvaHocKy(model.ID_LoaiTT, model.ID_HocKy);
            model.ID_ThucTap = tt.ID;
            var m = new DeTai
            {
                ID=model.ID,
                ID_ThucTap = model.ID_ThucTap,
                TenDeTai = model.TenDeTai,
                MoTa = model.MoTa,
                TrangThai = model.TrangThai
            };
            return Json(deTaiService.Update(m), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            return Json(deTaiService.Delete(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listLoaiTT()
        {
            var result= thucTapService.GetAllLoaiTT();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public void listHocKy1(long? id = null)
        //{
        //    ViewBag.ID_HocKy = new SelectList(thucTapService.GetAllHocKy(), "ID", "TenHocKy", id);
        //}

        //public void listLoaiTT1(long? id = null)
        //{
        //    ViewBag.ID_LoaiTT = new SelectList(thucTapService.GetAllLoaiTT(), "ID", "TenThucTap", id);
        //}

        public JsonResult listHocKy()
        {
            var result = thucTapService.GetAllHocKy();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listDeTai()
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            return Json(deTaiService.GetList(id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            return Json(deTaiService.GetById(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK,long IDTT)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = thucTapService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var rs = deTaiService.GetListByTTvaMaGV(thuctap.ID, id_gv);
            return Json(deTaiService.GetListByTTvaMaGV(thuctap.ID,id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoaiTTByHK(long? ID)
        {   
            return Json(thucTapService.GetByHocKy(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(long id)
        {
            return Json(deTaiService.ChangeStatus(id), JsonRequestBehavior.AllowGet);
        }
    }
}