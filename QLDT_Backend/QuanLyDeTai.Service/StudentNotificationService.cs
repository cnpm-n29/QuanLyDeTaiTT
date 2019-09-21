using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentNotificationService
    {
        private StudentNotificationDAL studentNotificationDAL = new StudentNotificationDAL();

        public StudentNotificationRelationship ChangeStatus(long id)
        {
            return studentNotificationDAL.ChangeStatus(id);
        }

        public bool Create(StudentNotificationRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentNotificationDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentNotificationRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentNotificationDAL.Update(model);
                return update;
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
                var update = studentNotificationDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public StudentNotificationRelationship GetById(long id)
        {
            return studentNotificationDAL.GetById(id);
        }

        public IQueryable GetList(long ID)
        {
            return studentNotificationDAL.GetList(ID);
        }

        public IQueryable GetListLimit(long ID)
        {
            return studentNotificationDAL.GetListLimit(ID);
        }
    }
}
