using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class PracticeService
    {
        PracticeTypeDAL practiceTypeDAL = new PracticeTypeDAL();
        SemesterDAL semesterDAL = new SemesterDAL();
        PracticeDAL practiceDAL = new PracticeDAL();


        public IEnumerable<Practice> GetAllLoaiTT()
        {
            return practiceDAL.GetAll();
        }

        public IEnumerable<Semester> GetAllHocKy()
        {
            return semesterDAL.GetAll();
        }

        public PracticeType GetByLoaiTTvaHocKy(long? id_loaitt, long? id_hocky)
        {
            return practiceTypeDAL.GetByLoaiTTvaHocKy(id_loaitt, id_hocky);
        }

        public IEnumerable<Practice> GetByHocKy(long? id_hocky)
        {
            return practiceTypeDAL.GetByHocKy( id_hocky);
        }

        public bool Create(PracticeType model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = practiceTypeDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }
    }
}
