using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class SubjectService
    {
        private SubjectDAL subjectDAL = new SubjectDAL();
        public IEnumerable<Subject> GetAllSubject()
        {
            return subjectDAL.GetAll();
        }
    }
}
