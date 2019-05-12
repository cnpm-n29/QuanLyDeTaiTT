using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class StudentTeacherDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public StudentTeacherRelationship GetBySinhVien(long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.StudentTeacherRelationships
                .Where(i => i.StudentID == idsv)
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<StudentTeacherRelationship> GetByGiangVien(long idgv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.StudentTeacherRelationships
                .Where(i => i.TeacherID == idgv)
                .ToList();
            return user;
        }
    }
}
