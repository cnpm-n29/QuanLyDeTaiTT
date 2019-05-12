using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentTeacherService
    {
        private StudentTeacherDAL studentTeacherDAL = new StudentTeacherDAL();
        public StudentTeacherRelationship GetBySinhVien(long idsv)
        {
            return studentTeacherDAL.GetBySinhVien(idsv);
        }

        public IEnumerable<StudentTeacherRelationship> GetByGiangVien(long idgv)
        {
            return studentTeacherDAL.GetByGiangVien(idgv);
        }
    }
}
