using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class FunctionDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public IQueryable GetById(long? id)
        {
            //Get from database
            //var user = context.Quyens
            //    .Where(i => i.ID == id)
            //    .FirstOrDefault();
            var user = from d in context.Functions
                       join c in context.FunctionRoleRelationships on d.ID equals c.FunctionID
                       join s in context.TeacherRoleRelationships on c.RoleID equals s.RoleID
                       where s.TeacherID == id
                       select d.FunctionName;
            return user;
        }

    }
}
