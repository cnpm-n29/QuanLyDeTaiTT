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
        private DefaultDbContext context = new DefaultDbContext();

        public StudentTeacherRelationship GetBySinhVien(long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = context.StudentTeacherRelationships
                .Where(i => i.StudentID == idsv&& (i.IsDeleted == false || i.IsDeleted.Equals(null)))
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
        

        public Teacher getByStudentId(long studentid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var query = from i in context.StudentTeacherRelationships
                        join j in context.Teachers on i.TeacherID equals j.ID
                        where i.StudentID == studentid && (i.IsDeleted == false || i.IsDeleted.Equals(null))
                        select j;
            return query.SingleOrDefault();
        }

        public Object GetInfoStudentAndTeacher(long studentid)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var query = from i in context.StudentTeacherRelationships
                        join j in context.Teachers on i.TeacherID equals j.ID
                        join x in context.Students on i.StudentID equals x.ID
                        join y in context.Subjects on j.SubjectID equals y.ID
                        where i.StudentID == studentid && (i.IsDeleted == false || i.IsDeleted.Equals(null))
                        select new {
                            MaSV=x.MaSV,
                            StFirstName=x.FirstName,
                            StLastName=x.LastName,
                            StBirthday = x.Birthday.Value.Day+"/"+ x.Birthday.Value.Month+"/"+ x.Birthday.Value.Year,
                            StAddress=x.Address,
                            StEmail=x.Email,
                            StPhone=x.Phone,
                            TcFirstName = j.FirstName,
                            TcLastName = j.LastName,
                            TcSubject=y.SubjectName,
                            TcBirthday = j.Birthday.Value.Day + "/" + j.Birthday.Value.Month + "/" + j.Birthday.Value.Year,
                            TcAddress = j.Address,
                            TcEmail = j.Email,
                            TcPhone = j.Phone,
                        };
            return query.FirstOrDefault();
        }

        public bool Create(StudentTeacherRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new StudentTeacherRelationship();

                //Set value for item with value from model
                item.StudentID = model.StudentID;
                item.TeacherID = model.TeacherID;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;


                //Add item to entity
                context.StudentTeacherRelationships.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StudentTeacherRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = context.StudentTeacherRelationships.Where(i => i.StudentID == model.StudentID && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

                //Set value for item with value from model
                item.TeacherID = model.TeacherID;
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
                var item = context.StudentTeacherRelationships.Where(i => i.StudentID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null))).FirstOrDefault();

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
