using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class TopicService
    {
        private TopicDAL topicDAL = new TopicDAL();

        public bool Create(Topic model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = topicDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Topic model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = topicDAL.Update(model);
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
                var update = topicDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Topic ChangeStatus(long id)
        {
            return topicDAL.ChangeStatus(id);
        }

        public IQueryable GetById(long id)
        {
            return topicDAL.GetById(id);
        }

        public IEnumerable<Topic> GetList(long ID)
        {
            return topicDAL.GetList(ID);
        }

        public IQueryable GetListByTT(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTT(id_tt, id_gv, search, pageNumber, pageSize);
        }

        public IQueryable GetListByTTAll(long? id_tt,long? id_bm, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTAll(id_tt,id_bm, search, pageNumber, pageSize);
        }

        public int GetListByTTCount(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTCount(id_tt, id_gv, search, pageNumber, pageSize);
        }

        public int GetListByTTAllCount(long? id_tt, long? id_bm, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTAllCount(id_tt,id_bm, search, pageNumber, pageSize);
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv,long? fieldId, string search, int pageNumber, int pageSize)
        {

            return topicDAL.GetListByTTvaMaGV(id_tt, id_gv,fieldId, search, pageNumber, pageSize);

        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {

            return topicDAL.GetListByTTvaMaGV(id_tt, id_gv, search, pageNumber, pageSize);

        }

        public IEnumerable<Topic> GetListByTTvaMaGV2(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTvaMaGV2(id_tt, id_gv, search, pageNumber, pageSize);
        }

            public IQueryable GetListByTTvaMaGV1(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {

            return topicDAL.GetListByTTvaMaGV1(id_tt, id_gv, search, pageNumber, pageSize);

        }

        public int getCount(long? id_tt, long? id_gv, string search)
        {
            return topicDAL.getCount(id_tt, id_gv, search);
        }

        public IQueryable GetListByTTAndSubjectId(long? id_tt, long? id_gv, long? id_bm, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTAndSubjectId(id_tt,id_gv, id_bm, search, pageNumber, pageSize);
        }

        public int GetListByTTAndSubjectIdCount(long? id_tt, long? id_gv, long? id_bm, string search, int pageNumber, int pageSize)
        {
            return topicDAL.GetListByTTAndSubjectIdCount(id_tt, id_gv, id_bm, search, pageNumber, pageSize);
        }

    }
}
