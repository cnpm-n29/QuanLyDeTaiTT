using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class TopicModel
    {
        public long ID { get; set; }

        public long? TeacherID { get; set; }

        public long? PracticeTypeID { get; set; }

        public long? FieldID { get; set; }

        public long? SemesterID { get; set; }

        public long? PracticeID { get; set; }

        [StringLength(500)]
        public string TopicName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool Status { get; set; }
        
    }
}