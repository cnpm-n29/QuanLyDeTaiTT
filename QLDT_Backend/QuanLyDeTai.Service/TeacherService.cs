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
    public class TeacherService
    {
        private TeacherDAL teacherDAL = new TeacherDAL();
        public Teacher LoginByCredential(string magv, string password)
        {

            if (string.IsNullOrEmpty(magv) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var gv = teacherDAL.GetByMagv(magv);
            if (gv == null)
            {
                return null;
            }

            var passwordSalt = gv.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == gv.Password)
            {
                return gv;
            }
            else
            {
                return null;
            }
        }

        public Teacher GetByMagv(string magv)
        {
            return teacherDAL.GetByMagv(magv);
        }

        public Teacher GetById(long id)
        {
            return teacherDAL.GetById(id);
        }

        public bool GetRole(string magv,string rolename)
        {

            var role= teacherDAL.GetRole(magv, rolename);
            if (role.Count()>0)
            {
                return true;
            }
            return false;
        }


        public IQueryable XetQuyen(long id)
        {
            FunctionDAL function = new FunctionDAL();
            IQueryable list = function.GetById(id); 
            return list;
        }

        public IEnumerable<Teacher> getListBySubjectId(long? id)
        {
            if (id == null)
            {
                return null;
            }
            return teacherDAL.getListBySubjectId(id);
        }

        public IEnumerable<Teacher> getListBySubjectIdSort(long? id, string magv, string teachername, int pageNumber, int pageSize)
        {
            return teacherDAL.getListBySubjectIdSort(id,magv,teachername,pageNumber,pageSize);
        }

        public IEnumerable<Teacher> getList()
        {
            return teacherDAL.getList();
        }
    }
}
