using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class DeTaiDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public IQueryable GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.DeTais
                       join t in context.ThucTaps on d.ID_ThucTap equals t.ID
                       where d.ID == id && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       select new
                       {
                           ID=d.ID,
                           TenDeTai = d.TenDeTai,
                           MoTa = d.MoTa,
                           TrangThai=d.TrangThai,
                           ID_HocKy=t.ID_HocKy,
                           ID_LoaiTT=t.ID_LoaiTT
                       };
            return user;
        }

        public DeTai ChangeStatus(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.DeTais
                .Where(i => i.ID == id)
                .FirstOrDefault();
            user.TrangThai = !user.TrangThai;
            context.SaveChanges();
            return user;
        }

        public IEnumerable<DeTai> GetByTT(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.DeTais
                .Where(i => i.ID_ThucTap == id)
                .ToList();
            return user;
        }

        public IEnumerable<DeTai> GetListByTTvaMaGV(long? id_tt,long? id_gv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.DeTais
                .Where(i => i.ID_ThucTap == id_tt && i.ID_GiangVien==id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .ToList();
            return user;
        }

        public IEnumerable<DeTai> GetList(long ID)
        {
            var post = context.DeTais
                .Where(i => i.ID_GiangVien == ID && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .ToList();
            return post;
        }
        

        public bool Update(DeTai model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.DeTais.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model

                item.ID_ThucTap = model.ID_ThucTap;
                item.TenDeTai = model.TenDeTai;
                item.MoTa = model.MoTa;
                item.TrangThai = model.TrangThai;
                

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(DeTai model)
        {
            try
            {
                //Initialization empty item
                var item = new DeTai();

                //Set value for item with value from model
                item.ID_GiangVien = model.ID_GiangVien;
                item.ID_ThucTap = model.ID_ThucTap;
                item.TenDeTai = model.TenDeTai;
                item.MoTa = model.MoTa;
                item.TrangThai = model.TrangThai;

                //Add item to entity
                context.DeTais.Add(item);
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
                var item = context.DeTais.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;

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
