namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        public long ID { get; set; }

        public long? TopicStudentID { get; set; }

        public long? PracticeTypeID { get; set; }

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

        public virtual TopicStudent TopicStudent { get; set; }
    }
}
