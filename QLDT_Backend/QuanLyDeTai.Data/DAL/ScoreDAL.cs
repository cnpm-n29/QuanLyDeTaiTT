using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class ScoreDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Score GetByTopicStudent2(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Scores
                .Where(i => i.TopicStudentID == id && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }

        public Score GetByTopicStudent(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Scores
                .Where(i => i.TopicStudentID == id)
                .FirstOrDefault();
            return user;
        }

        public Object GetBySinhvienAndLoaiTT(long idltt,long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Topics
                       join c in context.TopicStudents on s.ID equals c.TopicID
                       join x in context.StudentPracticeRelationships on c.StudentPracticeID equals x.ID
                       join a in context.PracticeTypes on x.PracticeTypeID equals a.ID
                       join y in context.Scores on c.ID equals y.TopicStudentID
                       where  a.PracticeID == idltt &&x.StudentID==idsv && (y.IsDeleted == false || y.IsDeleted.Equals(null))
                       &&(c.Status==true)&& (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select new {
                           TopicName=s.TopicName,
                           CompanyScore=y.CompanyScore,
                           TeacherScore=y.TeacherScore,
                           ReportScore=y.ReportScore,
                           TotalScore=y.TotalScore
                       };
            return user.FirstOrDefault();
        }

        public IEnumerable<object> getListByPracticeTypeIdAll(long practiceTypeId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Scores
                       join x in context.TopicStudents on s.TopicStudentID equals x.ID
                       join b in context.StudentPracticeRelationships on x.StudentPracticeID equals b.ID
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       join y in context.Students on b.StudentID equals y.ID
                       join a in context.Topics on x.TopicID equals a.ID
                       where s.PracticeTypeID == practiceTypeId && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select new
                       {
                           ID = s.ID,
                           MaSV = y.MaSV,
                           FirstName = y.FirstName,
                           LastName = y.LastName,
                           TopicName = a.TopicName,
                           CompanyScore = s.CompanyScore,
                           TeacherScore = s.TeacherScore,
                           ReportScore = s.ReportScore,
                           TotalScore = s.TotalScore
                       };

            return user.OrderBy(i => i.LastName).ToList();
        }

        public IEnumerable<Object> getListByPracticeTypeIdSort(long practiceTypeId, string masv, string studentname, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Scores
                       join x in context.TopicStudents on s.TopicStudentID equals x.ID
                       join b in context.StudentPracticeRelationships on x.StudentPracticeID equals b.ID
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       join y in context.Students on b.StudentID equals y.ID
                       join a in context.Topics on x.TopicID equals a.ID
                       where s.PracticeTypeID == practiceTypeId && y.MaSV.Contains(masv) && (y.FirstName.Contains(studentname) || y.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select new {
                           ID = s.ID,
                           Masv =y.MaSV,
                           FirstName = y.FirstName,
                           LastName = y.LastName,
                           TopicName =a.TopicName,
                           CompanyScore=s.CompanyScore,
                           TeacherScore=s.TeacherScore,
                           ReportScore=s.ReportScore,
                           TotalScore=s.TotalScore,
                           s.IsDeleted
                       };

            return user.OrderBy(i => i.LastName).Skip(pageNumber * pageSize).Take(pageSize).ToList(); ;
        }

        public int getListByPracticeTypeIdCount(long practiceTypeId, string masv, string studentname)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Scores
                       join x in context.TopicStudents on s.TopicStudentID equals x.ID
                       join b in context.StudentPracticeRelationships on x.StudentPracticeID equals b.ID
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       join y in context.Students on b.StudentID equals y.ID
                       join a in context.Topics on x.TopicID equals a.ID
                       where s.PracticeTypeID == practiceTypeId && y.MaSV.Contains(masv) && (y.FirstName.Contains(studentname) || y.LastName.Contains(studentname)) && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select new
                       {
                           Masv = y.MaSV,
                           FirstName = y.FirstName,
                           LastName= y.LastName,
                           TopicName = a.TopicName,
                           CompanyScore = s.CompanyScore,
                           TeacherScore = s.TeacherScore,
                           ReportScore = s.ReportScore,
                           TotalScore = s.TotalScore
                       };


            return user.ToList().Count();
        }

        public Object GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from s in context.Scores
                       join x in context.TopicStudents on s.TopicStudentID equals x.ID
                       join b in context.StudentPracticeRelationships on x.StudentPracticeID equals b.ID
                       join c in context.PracticeTypes on s.PracticeTypeID equals c.ID
                       join y in context.Students on b.StudentID equals y.ID
                       join a in context.Topics on x.TopicID equals a.ID
                       where s.ID == id && (s.IsDeleted == false || s.IsDeleted.Equals(null))
                       select new
                       {
                           ID = s.ID,
                           Masv = y.MaSV,
                           FirstName = y.FirstName,
                           LastName = y.LastName,
                           TopicName = a.TopicName,
                           CompanyScore = s.CompanyScore,
                           TeacherScore = s.TeacherScore,
                           ReportScore = s.ReportScore,
                           TotalScore = s.TotalScore
                       };
            return user.FirstOrDefault();
        }

        public bool CreateNewScore(Score model)
        {
            try
            {
                //Initialization empty item
                var item = new Score();

                //Set value for item with value from model
                item.TopicStudentID = model.TopicStudentID;
                item.PracticeTypeID = model.PracticeTypeID;
                item.TeacherScore = model.TeacherScore;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.Scores.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Score model)
        {
            try
            {
                //Initialization empty item
                var item = new Score();

                //Set value for item with value from model
                item.TopicStudentID = model.TopicStudentID;
                item.PracticeTypeID = model.PracticeTypeID;
                item.CompanyScore = model.CompanyScore;
                item.TeacherScore = model.TeacherScore;
                item.ReportScore = model.ReportScore;
                item.TotalScore = model.TotalScore;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;

                //Add item to entity
                context.Scores.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Score model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Scores.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.CompanyScore = model.CompanyScore;
                item.TeacherScore = model.TeacherScore;
                item.ReportScore = model.ReportScore;
                item.TotalScore = model.TotalScore;
                
                item.ModifyBy = model.ModifyBy;
                item.ModifyTime = DateTime.Now;
                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNewScore(Score model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Scores.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.TeacherScore = model.TeacherScore;

                item.ModifyBy = model.ModifyBy;
                item.ModifyTime = DateTime.Now;

                item.IsDeleted = false;
                item.DeletedBy = null;
                item.DeletedTime = null;
                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOldScore(Score model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Scores.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.CompanyScore = model.CompanyScore;
                item.ReportScore = model.ReportScore;
                item.TotalScore = model.TotalScore;

                item.ModifyBy = model.ModifyBy;
                item.ModifyTime = DateTime.Now;
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
                var item = context.Scores.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
                item.DeletedBy = person;
                item.DeletedTime = DateTime.Now;

                //Change database
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                var a = e.Message;
                return false;
            }
        }

        public bool DeleteAll(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.Scores.Where(i => i.PracticeTypeID == id).ToList();

                //Remove item.
                foreach (var i in item)
                {
                    i.CompanyScore = null;
                    i.ReportScore = null;
                    i.TotalScore = null;
                    context.SaveChanges();
                }
                
                return true;
            }
            catch (Exception e)
            {
                var a = e.Message;
                return false;
            }
        }
        public bool DeleteOldScore(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.Scores.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.CompanyScore = null;
                item.ReportScore = null;
                item.TotalScore = null;

                //Change database
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var a = e.Message;
                return false;
            }
        }
    }
}
