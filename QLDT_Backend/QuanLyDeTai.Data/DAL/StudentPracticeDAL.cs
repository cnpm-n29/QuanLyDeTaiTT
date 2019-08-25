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

        public Object GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.StudentPracticeRelationships
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Students on d.StudentID equals x.ID
                       where d.ID == id && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       select new
                       {
                           ID = d.ID,
                           MaSV=x.MaSV,
                           FirstName=x.FirstName,
                           LastName=x.LastName,
                           SemesterID = t.SemesterID,
                           PracticeID = t.PracticeID
                       };
            return user.FirstOrDefault();
        }

        public StudentPracticeRelationship GetBySinhVienvaLoaiTT(long idsv, long idltt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.StudentPracticeRelationships
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       where s.StudentID == idsv && c.PracticeID==idltt && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select s;
            return user.FirstOrDefault();
        }

        public StudentPracticeRelationship GetBySinhVienvaKieuTT(long? idsv, long idktt)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.StudentPracticeRelationships
                .Where(i => i.StudentID == idsv && i.PracticeTypeID==idktt && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }

        public IQueryable getListByPracticeTypeIdSort(long practiceTypeId,string masv,string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       where c.PracticeTypeID == practiceTypeId && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
                       select new {
                           ID = c.ID,
                           MaSV = s.MaSV,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Birthday = s.Birthday.Value.Day + "/" + s.Birthday.Value.Month + "/" + s.Birthday.Value.Year,
                           Address = s.Address,
                           Email = s.Email,
                           Phone = s.Phone,
                           Note=s.Note
                       };

            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize) ;
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       where c.PracticeTypeID == practiceTypeId && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
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
                item.CreateBy = model.CreateBy;
                item.CreateTime = model.CreateTime;

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

        public bool Update(StudentPracticeRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = context.StudentPracticeRelationships.Where(i => i.ID == model.ID && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Set value for item with value from model
                //item.StudentID = model.StudentID;
                item.PracticeTypeID = model.PracticeTypeID;
                item.ModifyBy = model.ModifyBy;
                item.CreateTime = DateTime.Now;


                //Save change to database
                context.SaveChanges();
                return true;
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
                //Tương tự update
                var item = context.StudentPracticeRelationships.Where(i => i.ID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
                item.DeletedBy = person;
                item.DeletedTime = DateTime.Now;

                //Change database
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
