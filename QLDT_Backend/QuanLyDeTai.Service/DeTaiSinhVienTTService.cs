using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class DeTaiSinhVienTTService
    {
        private DeTaiSinhVienTTDAL deTaiSinhVienTTDAL = new DeTaiSinhVienTTDAL();

        public DeTaiSinhVienTT GetById(long id)
        {
            return deTaiSinhVienTTDAL.GetById(id);
        }

        public DeTaiSinhVienTT GetByDeTaivaSinhVien(long iddt, long idsv)
        {
            return deTaiSinhVienTTDAL.GetByDeTaivaSinhVien(iddt,idsv);
        }
        public bool Update(DeTaiSinhVienTT model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = deTaiSinhVienTTDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(DeTaiSinhVienTT model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = deTaiSinhVienTTDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var update = deTaiSinhVienTTDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
