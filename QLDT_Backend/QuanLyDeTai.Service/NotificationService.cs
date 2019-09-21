using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class NotificationService
    {
        private NotificationDAL notificationDAL = new NotificationDAL();

        public IEnumerable<Notification> GetListByTTvaMaGV(long? id_tt, long? id_gv)
        {
            return notificationDAL.GetListByTTvaMaGV(id_tt, id_gv);
        }



        public bool Create(Notification model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = notificationDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }
        public long returnId()
        {
            return notificationDAL.returnId();
        }

        public bool Update(Notification model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = notificationDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id,long person)
        {
            try
            {
                var update = notificationDAL.Delete(id,person);
                return update;
            }
            catch
            {
                return false;
            }
        }

        //public Topic ChangeStatus(long id)
        //{
        //    return topicDAL.ChangeStatus(id);
        //}

        public IQueryable GetById(long id)
        {
            return notificationDAL.GetById(id);
        }
        

        public IEnumerable<Notification> GetList(long ID)
        {
            return notificationDAL.GetList(ID);
        }
    }
}
