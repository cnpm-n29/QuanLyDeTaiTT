using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class FieldService
    {
        FieldDAL fieldDAL = new FieldDAL();

        public Field GetById(long id)
        {
            return fieldDAL.GetById(id);
        }
        public List<Field> GetListField()
        {
            return fieldDAL.GetListField();
        }

        public List<String> GetByStudentId(long id)
        {
            return fieldDAL.GetByStudentId(id);
        }
    }
}
