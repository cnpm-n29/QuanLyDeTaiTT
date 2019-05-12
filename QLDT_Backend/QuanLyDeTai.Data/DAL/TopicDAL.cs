using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class TopicDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public IQueryable GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       where d.ID == id && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       select new
                       {
                           ID=d.ID,
                           TopicName = d.TopicName,
                           Description = d.Description,
                           Status = d.Status,
                           SemesterID = t.SemesterID,
                           PracticeID = t.PracticeID
                       };
            return user;
        }

        public Topic ChangeStatus(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.ID == id)
                .FirstOrDefault();
            user.Status = !user.Status;
            context.SaveChanges();
            return user;
        }

        public IEnumerable<Topic> GetByTT(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.PracticeTypeID == id)
                .ToList();
            return user;
        }

        public IEnumerable<Topic> GetListByTTvaMaGV(long? id_tt,long? id_gv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.PracticeTypeID == id_tt && i.TeacherID==id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .ToList();
            return user;
        }

        public IEnumerable<Topic> GetList(long ID)
        {
            var post = context.Topics
                .Where(i => i.TeacherID == ID && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .ToList();
            return post;
        }
        

        public bool Update(Topic model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Topics.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model

                item.PracticeTypeID = model.PracticeTypeID;
                item.TopicName = model.TopicName;
                item.Description = model.Description;
                item.Status = model.Status;
                

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Topic model)
        {
            try
            {
                //Initialization empty item
                var item = new Topic();

                //Set value for item with value from model
                item.TeacherID = model.TeacherID;
                item.PracticeTypeID = model.PracticeTypeID;
                item.TopicName = model.TopicName;
                item.Description = model.Description;
                item.Status = model.Status;

                //Add item to entity
                context.Topics.Add(item);
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
                var item = context.Topics.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;

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
