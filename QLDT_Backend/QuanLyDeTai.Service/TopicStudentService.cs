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

        public TopicStudent GetByStudentPracticeId(long id)
        {
            return topicStudentDAL.GetByStudentPracticeId(id);
        }

        public IQueryable GetListByTopicId(long tpid)
        {
            return topicStudentDAL.GetListByTopicId(tpid);
        }

        public int getCount(long tpid)
        {
            return topicStudentDAL.getCount(tpid);
        }

        public TopicStudent ChangeStatus(long id)
        {
            return topicStudentDAL.ChangeStatus(id);
        }

        public TopicStudent CheckTopicUser(long id)
        {
            return topicStudentDAL.CheckTopicUser(id);
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv, string search)
        {
            return topicStudentDAL.GetListByTTvaMaGV(id_tt,id_gv,search);
        }

        public Topic getTopicChoose(long id)
        {
            return topicStudentDAL.getTopicChoose(id);
        }

        public bool Plus(long id, int progress)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }
                var update = topicStudentDAL.Plus(id,progress);
                return update;
            }
            catch
            {
                return false;
            }
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
