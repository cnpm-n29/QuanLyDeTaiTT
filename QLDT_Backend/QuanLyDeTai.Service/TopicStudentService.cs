using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class TopicStudentService
    {
        private TopicStudentDAL topicStudentDAL = new TopicStudentDAL();

        public TopicStudent GetById(long id)
        {
            return topicStudentDAL.GetById(id);
        }

        public IQueryable GetListByTopicId(long tpid)
        {
            return topicStudentDAL.GetListByTopicId(tpid);
        }


        public bool Update(TopicStudent model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = topicStudentDAL.Update(model);
                return update;
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
                if (model == null)
                {
                    return false;
                }
                var create = topicStudentDAL.Create(model);
                return create;
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
                var update = topicStudentDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
