using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class ScoreExcelModel
    {
        public long ID { get; set; }

        public long? TopicStudentID { get; set; }

        public string MaSV { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? PracticeTypeID { get; set; }

        public string TopicName { get; set; }

        public float? CompanyScore { get; set; }

        public float? TeacherScore { get; set; }

        public float? ReportScore { get; set; }

        public float? TotalScore { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
    }
}