using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class PracticeDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public Practice GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Practices
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public IEnumerable<Practice> GetAll()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Practices
                .ToList();
            return user;
        }
    }
}
