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
        private DefaultDbContext context = new DefaultDbContext();

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
            return user.ToList().LastOrDefault();
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

        public List<Student> getListByPracticeTypeIdAndTeacherIdSort(long practiceTypeId,long teacherid, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       join t in context.StudentTeacherRelationships on s.ID equals t.StudentID
                       join f in context.Faculties on s.FacultyID equals f.ID
                       where c.PracticeTypeID == practiceTypeId && t.TeacherID == teacherid && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
                       select s;

            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        public List<Student> getListByPracticeTypeIdAndTeacherId(long practiceTypeId, long teacherid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       join f in context.Faculties on s.FacultyID equals f.ID
                       where c.PracticeTypeID == practiceTypeId && c.TeacherID == teacherid  && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
                       select s;

            return user.OrderBy(i => i.LastName).ToList();
        }

        public int getListByPracticeTypeIdAndTeacherIdCount(long practiceTypeId, long teacherid, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       join t in context.StudentTeacherRelationships on s.ID equals t.StudentID
                       join f in context.Faculties on s.FacultyID equals f.ID
                       where c.PracticeTypeID == practiceTypeId && t.TeacherID == teacherid && s.MaSV.Contains(masv) && (s.FirstName.Contains(studentname) || s.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
                       select s;

            return user.ToList().Count();
        }



        public List<StudentPracticeRelationship> getListByPracticeTypeId(long practiceTypeId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       where c.PracticeTypeID == practiceTypeId && (c.IsDeleted == false || c.IsDeleted.Equals(null))
                       select c;

            return user.ToList();
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

        public List<Student> getListByPracticeTypeIdReport(long practiceTypeId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Students
                       join c in context.StudentPracticeRelationships on s.ID equals c.StudentID
                       join t in context.TopicStudents on c.ID equals t.StudentPracticeID
                       where t.Status==true && c.PracticeTypeID == practiceTypeId && (s.IsDeleted == false || s.IsDeleted.Equals(null) && (c.IsDeleted == false || c.IsDeleted.Equals(null)))
                       select s;


            return user.ToList();
        }

        public Teacher getByStudent(long studentID)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.StudentPracticeRelationships
                       join t in context.Teachers on s.TeacherID equals t.ID
                       where s.StudentID == studentID && (s.IsDeleted == false || s.IsDeleted.Equals(null)) && (t.IsDeleted == false || t.IsDeleted.Equals(null))
                       select t;


            return user.FirstOrDefault();
        }

        public List<Student> getByTeacherReport(long teacherID)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.StudentPracticeRelationships
                       join st in context.Students on s.StudentID equals st.ID 
                       where s.TeacherID == teacherID && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select st;


            return user.ToList();
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
                item.CreateTime = DateTime.Now;

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

        public bool UpdateReport(long teacherID,long ID)
        {
            try
            {
                //Initialization empty item
                var item = context.StudentPracticeRelationships.Where(i => i.ID == ID && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Set value for item with value from model
                //item.StudentID = model.StudentID;
                item.TeacherID = teacherID;


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

        public bool DeleteReport(long id)
        {
            try
            {
                //Tương tự update
                var item = context.StudentPracticeRelationships.Where(i => i.ID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Remove item.

                item.TeacherID = null;

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAll(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.StudentPracticeRelationships.Where(i => i.PracticeTypeID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null))).ToList();

                //Remove item.
                foreach (var i in item)
                {
                    i.IsDeleted = true;
                    i.DeletedBy = person;
                    i.DeletedTime = DateTime.Now;
                }

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
