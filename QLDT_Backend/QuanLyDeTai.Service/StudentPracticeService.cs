using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentPracticeService
    {
        StudentPracticeDAL studentPracticeDAL = new StudentPracticeDAL();
        public StudentPracticeRelationship GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            return studentPracticeDAL.GetBySinhVienvaLoaiTT(idsv, idltt);
        }

        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long idsv, long idktt)
        {
            return studentPracticeDAL.GetBySinhVienvaKieuTT(idsv, idktt);
        }
    }
}
