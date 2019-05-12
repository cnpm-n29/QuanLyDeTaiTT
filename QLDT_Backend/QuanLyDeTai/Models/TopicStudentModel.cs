using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class TopicStudentModel
    {
        public long? StudentPracticeID { get; set; }

        public long? TopicID { get; set; }

        public long SemesterID { get; set; }

        public int? Order { get; set; }

        public bool Status { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }
    }
}