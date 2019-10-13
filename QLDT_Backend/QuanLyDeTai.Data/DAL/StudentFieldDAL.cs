using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class StudentFieldDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public StudentFieldRelationship GetByStudentandField(long idsv,long fieldid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.StudentFieldRelationships
                .Where(i => i.StudentID == idsv && i.FieldID==fieldid)
                .FirstOrDefault();
            return user;
        }

        public List<StudentFieldRelationship> GetByStudent(long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.StudentFieldRelationships
                .Where(i => i.StudentID == idsv)
                .ToList();
            return user;
        }

        public bool Create(StudentFieldRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new StudentFieldRelationship();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.FieldID = model.FieldID;


                //Add item to entity
                context.StudentFieldRelationships.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentFieldRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = context.StudentFieldRelationships.Where(i => i.ID == model.ID ).FirstOrDefault();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.FieldID = model.FieldID;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.StudentFieldRelationships.Where(i => i.ID == id ).FirstOrDefault();

                //Remove item.

                context.StudentFieldRelationships.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
