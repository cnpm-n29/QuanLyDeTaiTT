using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class PhanCongGVDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public PhanCongGV GetBySinhVien(long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.PhanCongGVs
                .Where(i => i.ID_SinhVien == idsv)
                .FirstOrDefault();
            return user;
        }
    }
}
