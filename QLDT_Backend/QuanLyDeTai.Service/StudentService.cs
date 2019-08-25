using QuanLyDeTai.Core;
using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentService
    {
        private StudentDAL studentDAL = new StudentDAL();
        public Student LoginByCredential(string masv, string password)
        {


            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var sv = studentDAL.GetByMasv(masv);
            if (sv == null)
            {
                return null;
            }

            var passwordSalt = sv.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == sv.Password)
            {
                return sv;
            }
            else
            {
                return null;
            }
        }

        public bool Create(Student model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Student model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id,long person)
        {
            try
            {
                var update = studentDAL.Delete(id,person);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Student GetByMasv(string masv)
        {
            return studentDAL.GetByMasv(masv);
        }

        public IEnumerable<Student> GetByFacultyID(long facultyID)
        {
            return studentDAL.GetByFacultyID(facultyID);

        }

        public IEnumerable<Student> GetByFacultyIDandSubjectId(long facultyID,long? SubjectID)
        {
            return studentDAL.GetByFacultyIDandSubjectId(facultyID,SubjectID);
            
        }

        public IEnumerable<Student> getListBySubjectIdAndFacultyIdSort(long? SubjectID,long facultyID, string masv, string studentname, int pageNumber, int pageSize)
        {
            return studentDAL.getListBySubjectIdAndFacultyIdSort(SubjectID, facultyID,masv,studentname,pageNumber,pageSize);

        }

        public IEnumerable<Student> getListByTeacherIdAndFacultyIdSort(long? teacherID, long facultyID, string masv, string studentname, int pageNumber, int pageSize)
        {
            return studentDAL.getListByTeacherIdAndFacultyIdSort(teacherID, facultyID, masv, studentname, pageNumber, pageSize);

        }


        public IEnumerable<Student> getListByFacultyIdSort(long facultyID, string masv, string studentname, int pageNumber, int pageSize)
        {
            return studentDAL.getListByFacultyIdSort( facultyID,masv,studentname, pageNumber, pageSize);

        }

        public int getListBySubjectIdAndFacultyIdCount(long? SubjectID, long facultyID, string masv, string studentname)
        {
            return studentDAL.getListBySubjectIdAndFacultyIdCount(SubjectID, facultyID, masv, studentname);

        }

        public int getListByTeacherIdAndFacultyIdCount(long? teacherID, long facultyID, string masv, string studentname)
        {
            return studentDAL.getListByTeacherIdAndFacultyIdCount(teacherID, facultyID, masv, studentname);

        }


        public int getListByFacultyIdCount(long facultyID, string masv, string studentname)
        {
            return studentDAL.getListByFacultyIdCount(facultyID,masv,studentname);

        }

        public Student GetById(long id)
        {
            return studentDAL.GetById(id);
        }

        public IEnumerable<Student> getListByTeacherIdAndPracticeId(long id, long practiceid)
        {
            return studentDAL.getListByTeacherIdAndPracticeId(id,practiceid);
        }
    }
}
