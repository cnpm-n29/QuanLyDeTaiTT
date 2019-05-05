using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class DeTaiSinhVienTTDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public DeTaiSinhVienTT GetById(long id)
        {
            //Get from database
            var user = context.DeTaiSinhVienTTs
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }

        public DeTaiSinhVienTT GetByDeTaivaSinhVien(long iddt, long idsv)
        {
            //Get from database
            var user = context.DeTaiSinhVienTTs
                .Where(i => i.ID_DeTai == iddt && i.ID_SinhVienTT==idsv)
                .FirstOrDefault();
            return user;
        }
        public bool Update(DeTaiSinhVienTT model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.DeTaiSinhVienTTs.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.Status = model.Status;
                
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = DateTime.Now;

                //Save change to database
                context.SaveChanges();
                return true;
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
                //Initialization empty item
                var item = new DeTaiSinhVienTT();

                //Set value for item with value from model
                item.ID_DeTai = model.ID_DeTai;
                item.ID_SinhVienTT = model.ID_SinhVienTT;
                item.DoUuTien = model.DoUuTien;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.DeTaiSinhVienTTs.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
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
                //Tương tự update
                var item = context.DeTaiSinhVienTTs.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                context.DeTaiSinhVienTTs.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
