using QuanLyDeTai.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class SinhVienTTDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public IEnumerable GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.SinhVienTTs
                       join c in context.ThucTaps on s.ID_TT equals c.ID
                       where s.ID_SinhVien == idsv && c.ID_LoaiTT==idltt
                       select s;
            return user;
        }
    }
}
