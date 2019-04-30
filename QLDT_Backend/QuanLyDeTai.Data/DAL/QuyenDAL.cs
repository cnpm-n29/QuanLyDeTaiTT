using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class QuyenDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public IQueryable GetById(long? id)
        {
            //Get from database
            //var user = context.Quyens
            //    .Where(i => i.ID == id)
            //    .FirstOrDefault();
            var user = from d in context.Quyens
                       join c in context.Quyen_CV on d.ID equals c.ID_Quyen
                       join s in context.ChucVuGVs on c.ID_ChucVu equals s.ID_ChucVu
                       where s.ID_GV == id
                       select d.Quyen1;
            return user;
        }
    }
}
