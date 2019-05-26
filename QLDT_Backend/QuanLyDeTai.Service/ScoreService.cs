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

        public IEnumerable<Object> getListByPracticeTypeIdSort(long practiceTypeId, string masv, string studentname, int pageNumber, int pageSize)
        {
            return scoreDAL.getListByPracticeTypeIdSort(practiceTypeId, masv, studentname, pageNumber, pageSize);
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            return scoreDAL.getListByPracticeTypeIdCount(practiceTypeId, masv, studentname);
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
    }
}
