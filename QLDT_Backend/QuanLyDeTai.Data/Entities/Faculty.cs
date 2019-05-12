namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty
    {
        public long ID { get; set; }

        public long? BranchID { get; set; }

        [StringLength(50)]
        public string FacultyName { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
