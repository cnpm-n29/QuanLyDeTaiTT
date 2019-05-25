using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class SubjectDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public Subject GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Subjects
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<Subject> GetAll()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Subjects
                .ToList();
            return user;
        }
    }
}
