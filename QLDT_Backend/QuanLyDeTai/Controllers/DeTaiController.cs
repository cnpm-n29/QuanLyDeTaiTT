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
            listHocKy1();
            listLoaiTT1();
        
            long ID = long.Parse(Session["UserId"].ToString());
            var listDeTai = deTaiService.GetList(ID);
            var model = listDeTai.Select(t => new DeTaiModel
            {
                ID=t.ID,
                ID_GiangVien=t.ID_GiangVien,
                ID_ThucTap = t.ID_ThucTap,
                TenDeTai=t.TenDeTai,
                MoTa=t.MoTa,
                TrangThai=t.TrangThai
            });
            var detaimodel = new DeTaiModelView
            {
                listDeTaiModels = model
            };
            return View(detaimodel);
        }

        [HttpPost]
        public ActionResult Create(DeTaiModelView model)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            model.deTaiModel.ID_GiangVien = id_gv;
            if (ModelState.IsValid)
            {
                try
                {
                    var tt = thucTapService.GetByLoaiTTvaHocKy(model.deTaiModel.ID_LoaiTT, model.deTaiModel.ID_HocKy);
                    model.deTaiModel.ID_ThucTap = tt.ID;
                    var m =  new DeTai
                    {
                        ID_GiangVien = model.deTaiModel.ID_GiangVien,
                        ID_ThucTap = model.deTaiModel.ID_ThucTap,
                        TenDeTai = model.deTaiModel.TenDeTai,
                        MoTa = model.deTaiModel.MoTa,
                        TrangThai = model.deTaiModel.TrangThai
                    };
                    var action = deTaiService.Create(m);
                    if (action)
                    {
                        return Redirect("/detai/index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }
            return Redirect("/detai/index");

        }

        

        public JsonResult listLoaiTT(long? id=null)
        {
            return Json(thucTapService.GetAllLoaiTT(), JsonRequestBehavior.AllowGet);
        }

        public void listHocKy1(long? id = null)
        {
            ViewBag.ID_HocKy = new SelectList(thucTapService.GetAllHocKy(), "ID", "TenHocKy", id);
        }

        public void listLoaiTT1(long? id = null)
        {
            ViewBag.ID_LoaiTT = new SelectList(thucTapService.GetAllLoaiTT(), "ID", "TenThucTap", id);
        }

        public JsonResult listHocKy(long? id = null)
        {
            return Json(thucTapService.GetAllHocKy(), JsonRequestBehavior.AllowGet);
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
    }
}