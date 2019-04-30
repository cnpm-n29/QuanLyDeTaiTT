using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class ThucTapService
    {
        ThucTapDAL thucTapDAL = new ThucTapDAL();
        HocKyDAL HocKyDAL = new HocKyDAL();
        LoaiTTDAL LoaiTTDAL = new LoaiTTDAL();


        public IEnumerable<LoaiTT> GetAllLoaiTT()
        {
            return LoaiTTDAL.GetAll();
        }

        public IEnumerable<HocKy> GetAllHocKy()
        {
            return HocKyDAL.GetAll();
        }

        public ThucTap GetByLoaiTTvaHocKy(long? id_loaitt, long? id_hocky)
        {
            return thucTapDAL.GetByLoaiTTvaHocKy(id_loaitt, id_hocky);
        }

        public IEnumerable<LoaiTT> GetByHocKy(long? id_hocky)
        {
            return thucTapDAL.GetByHocKy( id_hocky);
        }
    }
}
