namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentFieldRelationship")]
    public partial class StudentFieldRelationship
    {
        public long ID { get; set; }

        public long? StudentID { get; set; }

        public long? FieldID { get; set; }

        public virtual Field Field { get; set; }

        public virtual Student Student { get; set; }
    }
}
