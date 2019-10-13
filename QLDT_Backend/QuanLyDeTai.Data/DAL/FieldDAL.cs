using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace QuanLyDeTai.Data.DAL
{
    public class FieldDAL
    {
        private DefaultDbContext context = new DefaultDbContext();
        public Field GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Fields
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }

        public List<String> GetByStudentId(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentFieldRelationships.Include(i=>i.Field)
                .Where(i => i.StudentID == id).Select(i =>  i.Field.FieldName).ToList()
                ;
            return user;
        }

        public List<Field> GetListField()
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Fields.ToList();
            return user;
        }
    }
}
