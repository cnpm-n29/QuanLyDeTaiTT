using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class TopicStudentDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public TopicStudent GetById(long id)
        {
            //Get from database
            var user = context.TopicStudents
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }

        public IQueryable GetListByTopicId(long tpid)
        {

            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.TopicStudents
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       join s in context.Students on t.ID_SinhVien equals s.ID
                       join tp in context.Topics on d.TopicID equals tp.ID
                       where d.TopicID == tpid
                       select new
                       {
                           ID = d.ID,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Sex = s.Sex,
                           Birthday = s.Birthday,
                           Email = s.Email,
                           Phone=s.Phone
                       };
            return user;
        }

        public bool Update(TopicStudent model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.TopicStudents.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.Status = model.Status;
                
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = DateTime.Now;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(TopicStudent model)
        {
            try
            {
                //Initialization empty item
                var item = new TopicStudent();

                //Set value for item with value from model
                item.TopicID = model.TopicID;
                item.StudentPracticeID = model.StudentPracticeID;
                item.Order = model.Order;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.TopicStudents.Add(item);
                //Save to database
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
                var item = context.TopicStudents.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                context.TopicStudents.Remove(item);

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
