using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class ReportService
    {
        private ReportDAL reportDAL = new ReportDAL();

        public bool Create(Report model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = reportDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Report model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = reportDAL.Update(model);
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
                var update = reportDAL.Delete(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
