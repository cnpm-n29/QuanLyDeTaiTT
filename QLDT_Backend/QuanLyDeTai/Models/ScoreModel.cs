using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class ScoreModel
    {
        public long ID { get; set; }

        public long? TopicStudentID { get; set; }

        public string MaSV { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? PracticeTypeID { get; set; }

        public string TopicName { get; set; }

        public double? CompanyScore { get; set; }

        public double? TeacherScore { get; set; }

        public double? ReportScore { get; set; }

        public double? TotalScore { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public Score ToModel()
        {
            var st = new Score
            {
                TopicStudentID=TopicStudentID,
                PracticeTypeID=PracticeTypeID,
                CompanyScore=Convert.ToSingle(CompanyScore),
                TeacherScore= Convert.ToSingle(TeacherScore),
                ReportScore= Convert.ToSingle(ReportScore),
                TotalScore= Convert.ToSingle(TotalScore),
                CreateBy=CreateBy,
                ModifyBy=ModifyBy
            };
            return st;
        }
    }
}