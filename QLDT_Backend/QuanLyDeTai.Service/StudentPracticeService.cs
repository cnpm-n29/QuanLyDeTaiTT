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
            if (studentPracticeDAL.GetBySinhVienvaLoaiTT(idsv, idltt) != null)
            {
                return studentPracticeDAL.GetBySinhVienvaLoaiTT(idsv, idltt);
            }
            return null;
        }

        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long idsv, long idktt)
        {
            return studentPracticeDAL.GetBySinhVienvaKieuTT(idsv, idktt);
        }

        public IEnumerable<Student> getListByPracticeTypeIdSort(long practiceTypeId,string masv,string studentname, int pageNumber, int pageSize)
        {
            return studentPracticeDAL.getListByPracticeTypeIdSort(practiceTypeId,masv,studentname, pageNumber, pageSize);
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            return studentPracticeDAL.getListByPracticeTypeIdCount(practiceTypeId, masv, studentname);
        }

        public bool Create(StudentPracticeRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentPracticeDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }
    }
}
