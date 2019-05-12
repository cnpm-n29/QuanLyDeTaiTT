namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentTeacherRelationship")]
    public partial class StudentTeacherRelationship
    {
        public long ID { get; set; }

        public long? StudentID { get; set; }

        public long? TeacherID { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
