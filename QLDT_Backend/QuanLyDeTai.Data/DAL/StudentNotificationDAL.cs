using System;
using QuanLyDeTai.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace QuanLyDeTai.Data.DAL
{
    public class StudentNotificationDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public StudentNotificationRelationship GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentNotificationRelationships
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }

        public StudentNotificationRelationship ChangeStatus(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentNotificationRelationships
                .Where(i => i.ID == id)
                .FirstOrDefault();
            user.Status = true;
            context.SaveChanges();
            return user;
        }

        public IQueryable GetList(long ID)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentNotificationRelationships.Include(i => i.Notification)
                .Where(i => i.StudentID == ID).Select(i => new { i.Notification.ID,i.Notification.Title,i.Notification.Content, i.Status });
            return user;
        }


        public bool Update(StudentNotificationRelationship model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.StudentNotificationRelationships.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model

                item.StudentID = model.StudentID;
                item.NotificationID = model.NotificationID;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(StudentNotificationRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new StudentNotificationRelationship();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.NotificationID = model.NotificationID;
                item.Status = false;
                //Add item to entity
                context.StudentNotificationRelationships.Add(item);
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
                var item = context.StudentNotificationRelationships.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                context.StudentNotificationRelationships.Remove(item);

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
