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
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       where s.StudentID == idsv && c.PracticeID==idltt
                       select s;
            return user.FirstOrDefault();
        }

        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long? idsv, long idktt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentPracticeRelationships
                .Where(i => i.StudentID == idsv && i.PracticeTypeID==idktt)
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<Student> getListByPracticeTypeIdSort(long practiceTypeId,string masv,string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       where c.PracticeTypeID == practiceTypeId && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select s;

            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList(); ;
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       where c.PracticeTypeID == practiceTypeId && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select s;


            return user.ToList().Count();
        }

        public bool Create(StudentPracticeRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new StudentPracticeRelationship();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.PracticeTypeID = model.PracticeTypeID;

                //Add item to entity
                context.StudentPracticeRelationships.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
