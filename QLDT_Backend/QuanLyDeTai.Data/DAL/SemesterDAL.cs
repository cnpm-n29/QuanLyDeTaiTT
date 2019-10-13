using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class SemesterDAL
    {
        private DefaultDbContext context = new DefaultDbContext();
        
        public Semester GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Semesters
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<Semester> GetAll()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user= context.Semesters
                .ToList();
            return user;
        }


    }
}
