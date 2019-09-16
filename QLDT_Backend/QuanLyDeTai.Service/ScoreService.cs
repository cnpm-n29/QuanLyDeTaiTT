using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class ScoreService
    {
        private ScoreDAL scoreDAL = new ScoreDAL();
        public Object GetBySinhvienAndLoaiTT(long idltt, long idsv)
        {
            return scoreDAL.GetBySinhvienAndLoaiTT(idltt,idsv);
        }

        public Score GetByTopicStudent(long id)
        {
            return scoreDAL.GetByTopicStudent(id);
        }

        public Score GetByTopicStudent2(long id)
        {
            return scoreDAL.GetByTopicStudent2(id);
        }


        public IEnumerable<Object> getListByPracticeTypeIdSort(long practiceTypeId, string masv, string studentname, int pageNumber, int pageSize)
        {
            return scoreDAL.getListByPracticeTypeIdSort(practiceTypeId, masv, studentname, pageNumber, pageSize);
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            return scoreDAL.getListByPracticeTypeIdCount(practiceTypeId, masv, studentname);
        }

        public IEnumerable<Object> getListByPracticeTypeIdAll(long practiceTypeId)
        {
            return scoreDAL.getListByPracticeTypeIdAll(practiceTypeId);
        }

        public bool Create(Score model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = scoreDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateNewScore(Score model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = scoreDAL.CreateNewScore(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Score model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = scoreDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNewScore(Score model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = scoreDAL.UpdateNewScore(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOldScore(Score model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = scoreDAL.UpdateOldScore(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id, long person)
        {
            try
            {
                var update = scoreDAL.Delete(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Object GetById(long id)
        {
            return scoreDAL.GetById(id);
        }

        public bool DeleteAll(long id, long person)
        {
            try
            {
                var update = scoreDAL.DeleteAll(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOldScore(long id, long person)
        {
            try
            {
                var update = scoreDAL.DeleteOldScore(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
