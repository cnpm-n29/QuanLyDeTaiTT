using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class FacultyService
    {
        private FacultyDAL facultyDA = new FacultyDAL();
        public IEnumerable<Faculty> GetAllFaculty()
        {
            return facultyDA.GetAll();
        }
    }
}
