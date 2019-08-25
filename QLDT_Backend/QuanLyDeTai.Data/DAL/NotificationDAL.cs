using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuanLyDeTai.Data.DAL
{
    public class NotificationDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public IQueryable GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from i in context.Notifications
                       join t in context.PracticeTypes on i.PracticeTypeID equals t.ID
                       join x in context.StudentNotificationRelationships on i.ID equals x.NotificationID
                       where i.ID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null))
                       select new
                       {
                           ID = i.ID,
                           StNotificationID=x.ID,
                           Title = i.Title,
                           Content = i.Content,
                           SemesterID = t.SemesterID,
                           PracticeID = t.PracticeID
                       };
            return user;
        }

        public IEnumerable<Notification> GetListByTTvaMaGV(long? id_tt, long? id_gv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Notifications
                .Where(i => i.PracticeTypeID == id_tt && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)));
            return user;
            
        }

        public IEnumerable<Notification> GetList(long ID)
        {
            var user = context.Notifications
                .Where(i => i.TeacherID == ID && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .ToList();
            return user;
        }



        static long id;
        public bool Update(Notification model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Notifications.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model

                item.Title = model.Title;
                item.Content = model.Content;
                //item.PracticeTypeID = model.PracticeTypeID;
                
                item.ModifyBy = model.ModifyBy;
                item.ModifyTime = DateTime.Now;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Notification model)
        {
            try
            {
                //Initialization empty item
                var item = new Notification();

                //Set value for item with value from model
                item.TeacherID = model.TeacherID;
                item.Title = model.Title;
                item.Content = model.Content;
                item.PracticeTypeID = model.PracticeTypeID;
                
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.Notifications.Add(item);
                
                context.SaveChanges();
                id = item.ID;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public long returnId()
        {
            return id;
        }

        public bool Delete(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.Notifications.Where(i => i.ID == id).FirstOrDefault();

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
