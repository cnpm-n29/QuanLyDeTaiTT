using QuanLyDeTai.Core;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class StudentDAL
    {
        private DefaultDbContext context = new DefaultDbContext();
        
        public IEnumerable<Student> GetByFacultyID(long facultyID)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Students
                 .Where(i => i.FacultyID == facultyID && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                 .OrderBy(i=>i.LastName)
                 .ToList();
            return user; 
        }

        public IEnumerable<Student> getListByFacultyIdSort(long facultyid, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Students
                 .Where(i => i.FacultyID == facultyid && i.MaSV.Contains(masv) &&( i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                 .OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList();

            return user ;
        }

        public int getListByFacultyIdCount(long facultyid,string masv,string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.Students
                 .Where(i => i.FacultyID == facultyid && i.MaSV.Contains(masv) &&( i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                 .ToList().Count();

            return user;
        }

        public IEnumerable<Student> GetByFacultyIDandSubjectId(long facultyID,long? SubjectID)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentSubjectRelationships on i.ID equals j.StudentID
                       where i.FacultyID == facultyID &&j.SubjectID==SubjectID&& (i.IsDeleted == false || i.IsDeleted.Equals(null)&& (j.IsDeleted == false || j.IsDeleted.Equals(null)))
                       select i;
            return user.OrderBy(i=>i.LastName).ToList();
        }

        public Student GetByMasv(string Masv)
        {
            //Get from database
            var user = context.Students
                .Where(i => i.MaSV == Masv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }

        public Student GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Students
                .Where(i => i.ID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<Student> getListBySubjectIdAndFacultyIdSort(long? id,long facultyid, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentSubjectRelationships on i.ID equals j.StudentID
                       where j.SubjectID == id && i.FacultyID == facultyid && i.MaSV.Contains(masv) && (i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)) && (j.IsDeleted == false || j.IsDeleted.Equals(null))
                       select i;
                
            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList(); ;
        }

        public int getListBySubjectIdAndFacultyIdCount(long? id, long facultyid, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentSubjectRelationships on i.ID equals j.StudentID
                       where j.SubjectID == id && i.FacultyID == facultyid && i.MaSV.Contains(masv) && (i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)) && (j.IsDeleted == false || j.IsDeleted.Equals(null))
                       select i;

            return user.ToList().Count();
        }

        public IEnumerable<Student> getListByTeacherIdAndFacultyIdSort(long? id, long facultyid, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentTeacherRelationships on i.ID equals j.StudentID
                       where j.TeacherID == id && i.FacultyID == facultyid && i.MaSV.Contains(masv) && (i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)) && (j.IsDeleted == false || j.IsDeleted.Equals(null))
                       select i;

            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList(); ;
        }

        public int getListByTeacherIdAndFacultyIdCount(long? id, long facultyid, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentTeacherRelationships on i.ID equals j.StudentID
                       where j.TeacherID == id && i.FacultyID == facultyid && i.MaSV.Contains(masv) && (i.FirstName.Contains(studentname) || i.LastName.Contains(studentname)) && (i.IsDeleted == false || i.IsDeleted.Equals(null)) && (j.IsDeleted == false || j.IsDeleted.Equals(null))
                       select i;

            return user.ToList().Count();
        }

        public IEnumerable<Student> getListByTeacherIdAndPracticeId(long id, long practiceid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from i in context.Students
                       join j in context.StudentTeacherRelationships on i.ID equals j.StudentID
                       join x in context.StudentPracticeRelationships on i.ID equals x.StudentID
                       where j.TeacherID == id && x.PracticeTypeID == practiceid && (i.IsDeleted == false || i.IsDeleted.Equals(null)) && (j.IsDeleted == false || j.IsDeleted.Equals(null)) && (x.IsDeleted == false || x.IsDeleted.Equals(null))
                       select i;

            return user.ToList();
        }

        public bool Update(Student model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Students.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.MaSV = model.MaSV;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.Birthday = model.Birthday;
                item.Address = model.Address;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.Password = PasswordHash.EncryptionPasswordWithSalt(model.MaSV, PasswordHash.GeneratePasswordSalt());
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = DateTime.Now;
                item.FacultyID = model.FacultyID;
                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Student model)
        {
            try
            {
                //Initialization empty item
                var item = new Student();

                //Set value for item with value from model
                item.MaSV = model.MaSV;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.Birthday = model.Birthday;
                item.Address = model.Address;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.Password = PasswordHash.EncryptionPasswordWithSalt(model.MaSV, PasswordHash.GeneratePasswordSalt());
                item.CreateBy = model.ModifiedBy;
                item.CreateTime = DateTime.Now;
                item.FacultyID = model.FacultyID;

                //Add item to entity
                context.Students.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id,long person)
        {
            try
            {
                //Tương tự update
                var item = context.Students.Where(i => i.ID == id).FirstOrDefault();

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
