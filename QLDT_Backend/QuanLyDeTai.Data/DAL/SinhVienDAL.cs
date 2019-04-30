using QuanLyDeTai.Core;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class SinhVienDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public SinhVien GetByMasv(string Masv)
        {
            //Get from database
            var user = context.SinhViens
                .Where(i => i.MaSV == Masv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }

        public bool Update(SinhVien model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.SinhViens.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.MaSV = model.MaSV;
                item.Ho = model.Ho;
                item.Ten = model.Ten;
                item.GioiTinh = model.GioiTinh;
                item.NgaySinh = model.NgaySinh;
                item.DiaChi = model.DiaChi;
                item.Email = model.Email;
                item.SDT = model.SDT;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.MatKhau = PasswordHash.EncryptionPasswordWithSalt(model.MatKhau, PasswordHash.GeneratePasswordSalt());
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

        public bool Create(SinhVien model)
        {
            try
            {
                //Initialization empty item
                var item = new SinhVien();

                //Set value for item with value from model
                item.MaSV = model.MaSV;
                item.Ho = model.Ho;
                item.Ten = model.Ten;
                item.GioiTinh = model.GioiTinh;
                item.NgaySinh = model.NgaySinh;
                item.DiaChi = model.DiaChi;
                item.Email = model.Email;
                item.SDT = model.SDT;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.MatKhau = PasswordHash.EncryptionPasswordWithSalt(model.MatKhau, PasswordHash.GeneratePasswordSalt());
                item.CreateBy = model.ModifiedBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.SinhViens.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id,long person)
        {
            try
            {
                //Tương tự update
                var item = context.SinhViens.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
                item.DeletedBy = person;
                item.DeletedTime = DateTime.Now;

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
