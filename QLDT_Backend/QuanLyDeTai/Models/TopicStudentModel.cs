using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class TopicStudentModel
    {
        public long ID { get; set; }

        public long? StudentPracticeID { get; set; }

        public long? TopicID { get; set; }

        public long SemesterID { get; set; }

        public int? Order { get; set; }

        public bool Status { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public float? TeacherScore { get; set; }

        public string MaSV { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public string TopicName { get; set; }

        public int? Progress { get; set; }

        public bool? Result { get; set; }
    }
}