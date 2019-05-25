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
            if (studentTeacherDAL.GetBySinhVien(idsv)!=null){
                return studentTeacherDAL.GetBySinhVien(idsv);
            }
            return null;
        }

        public IEnumerable<StudentTeacherRelationship> GetByGiangVien(long idgv)
        {
            return studentTeacherDAL.GetByGiangVien(idgv);
        }

        public Teacher getByStudentId(long studentid)
        {
            return studentTeacherDAL.getByStudentId(studentid);
        }

        public Object GetInfoStudentAndTeacher(long id)
        {
            return studentTeacherDAL.GetInfoStudentAndTeacher(id);
        }

        public bool Create(StudentTeacherRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentTeacherDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentTeacherRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentTeacherDAL.Update(model);
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
                var update = studentTeacherDAL.Delete(id, person);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
