using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class LoaiTTDAL
    {

        private DefaultDbContext context = new DefaultDbContext();

        public LoaiTT GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.LoaiTTs
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<LoaiTT> GetAll()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.LoaiTTs
                .ToList();
            return user;
        }
    }
}
