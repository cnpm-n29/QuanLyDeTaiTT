using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class HocKyDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public HocKy GetById(long id)
        {
            var user = context.HocKies
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<HocKy> GetAll()
        {
            var user= context.HocKies
                .ToList();
            return user;
        }


    }
}
