using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class StudentSubjectDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Subject getByStudentId(long studentid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var query = from i in context.StudentSubjectRelationships
                        join j in context.Subjects on i.SubjectID equals j.ID
                        where i.StudentID == studentid &&(i.IsDeleted==false|| i.IsDeleted.Equals(null))
                        select j;
            return query.SingleOrDefault();
        }

        public bool Create(StudentSubjectRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new StudentSubjectRelationship();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.SubjectID = model.SubjectID;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;
                

                //Add item to entity
                context.StudentSubjectRelationships.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentSubjectRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = context.StudentSubjectRelationships.Where(i => i.StudentID == model.StudentID&&(i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Set value for item with value from model
                item.SubjectID = model.SubjectID;
                item.ModifyBy = model.ModifyBy;
                item.CreateTime = DateTime.Now;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.StudentSubjectRelationships.Where(i => i.StudentID == id&&(i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
                item.DeletedBy = person;
                item.DeletedTime = DateTime.Now;

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
