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
        private DefaultDbContent context = new DefaultDbContent();

        public Object GetBySinhvienAndLoaiTT(long idltt,long idsv)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.Topics
                       join c in context.TopicStudents on s.ID equals c.TopicID
                       join x in context.StudentPracticeRelationships on c.StudentPracticeID equals x.PracticeTypeID
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
                           Masv=y.MaSV,
                           FirstName = y.FirstName,
                           LastName = y.LastName,
                           TopicName =a.TopicName,
                           CompanyScore=s.CompanyScore,
                           TeacherScore=s.TeacherScore,
                           ReportScore=s.ReportScore,
                           TotalScore=s.TotalScore
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
    }
}
