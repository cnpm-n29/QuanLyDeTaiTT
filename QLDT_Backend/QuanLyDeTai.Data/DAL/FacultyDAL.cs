using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class FacultyDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Faculty GetById(long? id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Faculties
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<Faculty> GetAll()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Faculties
                .ToList();
            return user;
        }


    }
}
