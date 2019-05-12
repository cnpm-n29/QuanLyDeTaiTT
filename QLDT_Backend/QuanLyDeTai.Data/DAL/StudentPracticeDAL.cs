using QuanLyDeTai.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class StudentPracticeDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public StudentPracticeRelationship GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.StudentPracticeRelationships
                       join c in context.PracticeTypes on s.ID_TT equals c.ID
                       where s.ID_SinhVien == idsv && c.PracticeID==idltt
                       select s;
            return user.FirstOrDefault();
        }

        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long? idsv, long idktt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentPracticeRelationships
                .Where(i => i.ID_SinhVien == idsv && i.ID_TT==idktt)
                .FirstOrDefault();
            return user;
        }

    }
}
