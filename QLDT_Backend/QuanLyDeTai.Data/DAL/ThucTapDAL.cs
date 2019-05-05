using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class ThucTapDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public ThucTap GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.ThucTaps
                .Where(i => i.ID == id )
                .FirstOrDefault();
            return user;
        }

        public ThucTap GetByLoaiTTvaHocKy(long? id_loaitt,long? id_hocky)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.ThucTaps
                .Where(i => i.ID_LoaiTT == id_loaitt && i.ID_HocKy==id_hocky)
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<LoaiTT> GetByHocKy( long? id_hocky)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from d in context.ThucTaps
                       join c in context.HocKies on d.ID_HocKy equals c.ID
                       join s in context.LoaiTTs on d.ID_LoaiTT equals s.ID
                       where d.ID_HocKy == id_hocky
                       select s;
            return user;
        }
    }
}
