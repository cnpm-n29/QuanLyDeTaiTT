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

        public object GetById(long id)
        {
            return studentPracticeDAL.GetById(id);
        }

        public StudentPracticeRelationship GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            if (studentPracticeDAL.GetBySinhVienvaLoaiTT(idsv, idltt) != null)
            {
                return studentPracticeDAL.GetBySinhVienvaLoaiTT(idsv, idltt);
            }
            return null;
        }

        public List<StudentPracticeRelationship> getListByPracticeTypeId(long practiceTypeId)
        {
            return studentPracticeDAL.getListByPracticeTypeId(practiceTypeId);
        }


        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long idsv, long idktt)
        {
            return studentPracticeDAL.GetBySinhVienvaKieuTT(idsv, idktt);
        }

        public IQueryable getListByPracticeTypeIdSort(long practiceTypeId,string masv,string studentname, int pageNumber, int pageSize)
        {
            return studentPracticeDAL.getListByPracticeTypeIdSort(practiceTypeId,masv,studentname, pageNumber, pageSize);
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            return studentPracticeDAL.getListByPracticeTypeIdCount(practiceTypeId, masv, studentname);
        }

        public List<Student> getListByPracticeTypeIdAndTeacherIdSort(long practiceTypeId,long teacherid, string masv, string studentname, int pageNumber, int pageSize)
        {
            return studentPracticeDAL.getListByPracticeTypeIdAndTeacherIdSort(practiceTypeId, teacherid, masv, studentname, pageNumber, pageSize);
        }

        public int getListByPracticeTypeIdAndTeacherIdCount(long practiceTypeId, long teacherid, string masv, string studentname)
        {
            return studentPracticeDAL.getListByPracticeTypeIdAndTeacherIdCount(practiceTypeId, teacherid, masv, studentname);
        }

        public List<Student> getListByPracticeTypeIdReport(long practiceTypeId)
        {
            return studentPracticeDAL.getListByPracticeTypeIdReport(practiceTypeId);
        }

        public Teacher getByStudent(long studentID)
        {
            return studentPracticeDAL.getByStudent(studentID);
        }

        public List<Student> getByTeacherReport(long teacherID)
        {
            return studentPracticeDAL.getByTeacherReport(teacherID);
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

        public bool Update(StudentPracticeRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentPracticeDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReport(long teacherID, long ID)
        {
            try
            {
                var update = studentPracticeDAL.UpdateReport(teacherID,ID);
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
                var update = studentPracticeDAL.Delete(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteReport(long id)
        {
            try
            {
                var update = studentPracticeDAL.DeleteReport(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAll(long id, long person)
        {
            try
            {
                var update = studentPracticeDAL.DeleteAll(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
