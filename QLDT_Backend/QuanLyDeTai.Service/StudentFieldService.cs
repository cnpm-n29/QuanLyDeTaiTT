using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class StudentFieldService
    {
        private StudentFieldDAL studentFieldDAL = new StudentFieldDAL();

        public StudentFieldRelationship GetByStudentandField(long idsv, long fieldid)
        {
            return studentFieldDAL.GetByStudentandField(idsv, fieldid);
        }

        public List<StudentFieldRelationship> GetByStudent(long idsv)
        {
            return studentFieldDAL.GetByStudent(idsv);
        }

        public bool Create(StudentFieldRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = studentFieldDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentFieldRelationship model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = studentFieldDAL.Update(model);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var update = studentFieldDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }
    }
}
