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
    }
}
