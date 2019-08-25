using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class NotificationModel
    {
        public long ID { get; set; }

        public long? TeacherID { get; set; }

        public long? PracticeTypeID { get; set; }

        public long? SemesterID { get; set; }

        public long? PracticeID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
    }
}