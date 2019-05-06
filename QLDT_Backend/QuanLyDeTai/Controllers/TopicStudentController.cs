using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class TopicStudentController : BaseController
    {
        private DeTaiService deTaiService = new DeTaiService();
        private SinhVienTTService sinhVienTTService = new SinhVienTTService();
        private PhanCongGVService phanCongGVService = new PhanCongGVService();
        // GET: DeTaiSinhVienTT
        public ActionResult ChooseTopic()
        {
            return View();
        }

        public JsonResult GetByThucTap(long IDTT)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt=sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
            var Giangvien = phanCongGVService.GetBySinhVien(idsv);
            long? idgv= Giangvien.ID_GiangVien;
            long? IDLoaiTT=0;
            foreach (SinhVienTT sv in svtt)
            {
                 IDLoaiTT =sv.ID_TT;
            }
            return Json(deTaiService.GetListByTTvaMaGV(IDLoaiTT,idgv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listLoaiTT(long? id = null)
        {
            ThucTapService thucTapService = new ThucTapService();
            return Json(thucTapService.GetAllLoaiTT(), JsonRequestBehavior.AllowGet);
        }
    }
}