using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class PhanCongGVService
    {
        private PhanCongGVDAL phanCongGVDAL = new PhanCongGVDAL();
        public PhanCongGV GetBySinhVien(long idsv)
        {
            return phanCongGVDAL.GetBySinhVien(idsv);
        }
    }
}
