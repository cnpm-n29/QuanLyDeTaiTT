namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherRoleRelationship")]
    public partial class TeacherRoleRelationship
    {
        public long ID { get; set; }

        public long? TeacherID { get; set; }

        public long? RoleID { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public virtual Role Role { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
