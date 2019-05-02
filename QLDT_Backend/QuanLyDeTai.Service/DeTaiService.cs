using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class DeTaiService
    {
        private DeTaiDAL DeTaiDAL = new DeTaiDAL();

        public bool Create(DeTai model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = DeTaiDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DeTai model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = DeTaiDAL.Update(model);
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
                var update = DeTaiDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable GetById(long id)
        {
            return DeTaiDAL.GetById(id);
        }

        public IEnumerable<DeTai> GetList(long ID)
        {
            return DeTaiDAL.GetList(ID);
        }

        public IEnumerable<DeTai> GetListByTTvaMaGV(long id_tt, long id_gv)
        {
            return DeTaiDAL.GetListByTTvaMaGV(id_tt,id_gv);
        }
    }
}
