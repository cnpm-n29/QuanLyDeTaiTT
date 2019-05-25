using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentSubjectService
    {
        private StudentSubjectDAL studentSubjectDAL = new StudentSubjectDAL();

        public Subject getByStudentId(long studentid)
        {
            return studentSubjectDAL.getByStudentId(studentid);
        }

        public bool Create(StudentSubjectRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentSubjectDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentSubjectRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentSubjectDAL.Update(model);
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
                var update = studentSubjectDAL.Delete(id,person);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
