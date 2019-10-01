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
        

        public TopicStudent GetByStudentPracticeIdNoCheckStatus(long id)
        {
            return topicStudentDAL.GetByStudentPracticeIdNoCheckStatus(id);
        }

        public IQueryable GetListByTopicId(long tpid)
        {
            return topicStudentDAL.GetListByTopicId(tpid);
        }

        public IQueryable GetListByTopicIdNotIncludeUser(long tpid, long userid)
        {
            return topicStudentDAL.GetListByTopicIdNotIncludeUser(tpid, userid);
        }

            public bool CheckTopic(long tpid)
        {
            var model=topicStudentDAL.GetListByTopicId(tpid);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        public int getCount(long tpid)
        {
            return topicStudentDAL.getCount(tpid);
        }

        public TopicStudent ChangeStatus(long id)
        {
            return topicStudentDAL.ChangeStatus(id);
        }

        public IQueryable CheckTopicUser(long id)
        {
            return topicStudentDAL.CheckTopicUser(id);
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv, string search)
        {
            return topicStudentDAL.GetListByTTvaMaGV(id_tt,id_gv,search);
        }

        public IQueryable GetListByTTvaBoMon(long? id_tt, long? id_bm, string masv, string studentname, int pageNumber, int pageSize)
        {
            return topicStudentDAL.GetListByTTvaBoMon(id_tt, id_bm, masv, studentname, pageNumber, pageSize);
        }

        public IQueryable GetListByTT(long? id_tt, string masv, string studentname, int pageNumber, int pageSize)
        {
            return topicStudentDAL.GetListByTT(id_tt, masv, studentname, pageNumber, pageSize);
        }

        public int GetListByTTvaBoMonCount(long? id_tt, long? id_bm, string masv, string studentname, int pageNumber, int pageSize)
        {
            return topicStudentDAL.GetListByTTvaBoMonCount(id_tt, id_bm, masv, studentname, pageNumber, pageSize);
        }

        public int GetListByTTCount(long? id_tt, string masv, string studentname, int pageNumber, int pageSize)
        {
            return topicStudentDAL.GetListByTTCount(id_tt, masv, studentname, pageNumber, pageSize);
        }

        public int GetCount(long? id_tt, long? id_gv, string search)
        {
            return topicStudentDAL.GetCount(id_tt, id_gv, search);
        }


        public IQueryable getExport(long? id_tt, long? id_gv, string search)
        {
            return topicStudentDAL.getExport(id_tt, id_gv, search);
        }

            public object getTopicChoose(long id)
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

        public bool Result(long id, bool result)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }
                var update = topicStudentDAL.Result(id, result);
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
