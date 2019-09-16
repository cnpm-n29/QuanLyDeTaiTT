using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class TopicStudentDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public TopicStudent GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.TopicStudents
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return user;
        }


        public TopicStudent GetByStudentPracticeId(long id)
        {
            //Get from database
            var user = context.TopicStudents
                .Where(i => i.StudentPracticeID == id && i.Status==true)
                .FirstOrDefault();
            return user;
        }

        public TopicStudent GetByStudentPracticeIdNoCheckStatus(long id)
        {
            //Get from database
            var user = context.TopicStudents
                .Where(i => i.StudentPracticeID == id)
                .FirstOrDefault();
            return user;
        }


        public TopicStudent CheckTopicUser(long id)
        {
            //Get from database
            var user = from d in context.TopicStudents
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       where d.StudentPracticeID == id 
                       select d;
            return user.FirstOrDefault();
        }

        public object getTopicChoose(long id)
        {
            //Get from database
            var user = from d in context.TopicStudents.Include("Topic")
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       join x in context.Topics on d.TopicID equals x.ID
                       where d.StudentPracticeID == id && d.Status==true
                       select new
                       {

                           TopicName = x.TopicName,
                           Description = x.Description,
                           Progress = d.Progress,
                           Result = d.Result
                       };
            return user.FirstOrDefault();
        }



        public IQueryable GetListByTopicId(long tpid)
        {

            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.TopicStudents
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       join s in context.Students on t.StudentID equals s.ID
                       join tp in context.Topics on d.TopicID equals tp.ID
                       where d.TopicID == tpid
                       select new
                       {
                           ID = d.ID,
                           StudentID = s.MaSV,
                           Order = d.Order,
                           Status = d.Status,
                           CreateTime=d.CreateTime,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Birthday = s.Birthday,
                           Email = s.Email,
                           Phone = s.Phone
                       };
            return user.OrderBy(i=>i.CreateTime);
        }

        public IQueryable GetListByTopicIdNotIncludeUser(long tpid,long userid)
        {

            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.TopicStudents
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       join s in context.Students on t.StudentID equals s.ID
                       join tp in context.Topics on d.TopicID equals tp.ID
                       where d.TopicID == tpid && s.ID!= userid
                       select new
                       {
                           ID = d.ID,
                           StudentID = s.MaSV,
                           Order = d.Order,
                           Status = d.Status,
                           CreateTime = d.CreateTime,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Birthday = s.Birthday,
                           Email = s.Email,
                           Phone = s.Phone
                       };
            return user.OrderBy(i => i.CreateTime);
        }

        public int getCount(long tpid)
        {

            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.TopicStudents
                       join t in context.StudentPracticeRelationships on d.StudentPracticeID equals t.ID
                       join s in context.Students on t.StudentID equals s.ID
                       join tp in context.Topics on d.TopicID equals tp.ID
                       where d.TopicID == tpid
                       select new
                       {
                           ID = d.ID,
                           StudentID = s.ID,
                           Order=d.Order,
                           Status=d.Status,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Birthday = s.Birthday,
                           Email = s.Email,
                           Phone = s.Phone
                       };
            return user.Count();
        }

        public bool Plus(long id, int progress)
        {
            try
            {
                //Get item user with Id from database
                var item = context.TopicStudents.Where(i => i.ID == id).FirstOrDefault();

                //Set value item with value from model
                item.Progress = progress;
                

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Result(long id, bool result)
        {
            try
            {
                //Get item user with Id from database
                var item = context.TopicStudents.Where(i => i.ID == id).FirstOrDefault();

                //Set value item with value from model
                item.Result = result;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TopicStudent ChangeStatus(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.TopicStudents
                .Where(i => i.ID == id)
                .FirstOrDefault();
            if (user.Status == null)
            {
                user.Status = true;
            }
            else
            {
                user.Status = !user.Status;
            }
            context.SaveChanges();
            return user;
        }

        public bool Update(TopicStudent model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.TopicStudents.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.Status = model.Status;
                
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = DateTime.Now;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(TopicStudent model)
        {
            try
            {
                //Initialization empty item
                var item = new TopicStudent();

                //Set value for item with value from model
                item.TopicID = model.TopicID;
                item.StudentPracticeID = model.StudentPracticeID;
                item.Order = model.Order;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;
                item.Progress = 0;

                //Add item to entity
                context.TopicStudents.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.TopicStudents.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                context.TopicStudents.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv, string search)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && d.TopicName.Contains(search) && d.TeacherID == id_gv && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           b.ID,
                           d.TopicName,
                           d.Status,
                           a.MaSV,
                           a.FirstName,
                           a.LastName,
                           b.Progress,
                           b.Result,
                       };
            return user;
        }

        public IQueryable GetListByTTvaBoMon(long? id_tt, long? id_bm, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       join st in context.StudentTeacherRelationships on a.ID equals st.StudentID
                       join t in context.Teachers on st.TeacherID equals t.ID
                       where d.PracticeTypeID == id_tt && b.Status == true &&a.MaSV.Contains(masv)&& (a.FirstName.Contains(studentname)||a.LastName.Contains(studentname)) && t.SubjectID == id_bm && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           ID=b.ID,
                           TopicName=d.TopicName,
                           Status=d.Status,
                           MaSV=a.MaSV,
                           FirstName=a.FirstName,
                           LastName=a.LastName,
                           Progress=b.Progress,
                           Result=b.Result,
                       };
            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize);
        }

        public int GetListByTTvaBoMonCount(long? id_tt, long? id_bm, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       join st in context.StudentTeacherRelationships on a.ID equals st.StudentID
                       join t in context.Teachers on st.TeacherID equals t.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && a.MaSV.Contains(masv) && (a.FirstName.Contains(studentname) || a.LastName.Contains(studentname)) && t.SubjectID == id_bm && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           ID = b.ID,
                           TopicName = d.TopicName,
                           Status = d.Status,
                           MaSV = a.MaSV,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           Progress = b.Progress,
                           Result = b.Result,
                       };
            return user.Count();
        }


        public IQueryable GetListByTT(long? id_tt, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       join st in context.StudentTeacherRelationships on a.ID equals st.StudentID
                       join t in context.Teachers on st.TeacherID equals t.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && a.MaSV.Contains(masv) && (a.FirstName.Contains(studentname) || a.LastName.Contains(studentname))  && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           b.ID,
                           d.TopicName,
                           d.Status,
                           a.MaSV,
                           a.FirstName,
                           a.LastName,
                           b.Progress,
                           b.Result,
                       };
            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize);
        }

        public int GetListByTTCount(long? id_tt, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       join st in context.StudentTeacherRelationships on a.ID equals st.StudentID
                       join t in context.Teachers on st.TeacherID equals t.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && a.MaSV.Contains(masv) && (a.FirstName.Contains(studentname) || a.LastName.Contains(studentname)) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           b.ID,
                           d.TopicName,
                           d.Status,
                           a.MaSV,
                           a.FirstName,
                           a.LastName,
                           b.Progress,
                           b.Result,
                       };
            return user.Count();
        }


        public int GetCount(long? id_tt, long? id_gv, string search)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && d.TopicName.Contains(search) && d.TeacherID == id_gv && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           b.ID,
                           d.TopicName,
                           d.Status,
                           a.MaSV,
                           a.FirstName,
                           a.LastName,
                           b.Progress,
                           b.Result
                       };
            return user.Count();
        }

        public IQueryable getExport(long? id_tt, long? id_gv, string search)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join b in context.TopicStudents on d.ID equals b.TopicID
                       join x in context.StudentPracticeRelationships on b.StudentPracticeID equals x.ID
                       join a in context.Students on x.StudentID equals a.ID
                       where d.PracticeTypeID == id_tt && b.Status == true && d.TopicName.Contains(search) && d.TeacherID == id_gv && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && (a.IsDeleted == false || a.IsDeleted.Equals(null))
                       select new
                       {
                           ID=b.ID,
                           TopicName=d.TopicName,
                           MaSV=a.MaSV,
                           FirstName=a.FirstName,
                           LastName=a.LastName,
                           Birthday=a.Birthday,
                           Progress=b.Progress,
                           Result=b.Result
                       };
            return user;
        }

    }
}
