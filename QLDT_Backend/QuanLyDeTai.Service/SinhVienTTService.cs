using QuanLyDeTai.Data.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class SinhVienTTService
    {
        SinhVienTTDAL sinhVienTTDAL = new SinhVienTTDAL();
        public IEnumerable GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            return sinhVienTTDAL.GetBySinhVienvaLoaiTT(idsv, idltt);
        }
    }
}
