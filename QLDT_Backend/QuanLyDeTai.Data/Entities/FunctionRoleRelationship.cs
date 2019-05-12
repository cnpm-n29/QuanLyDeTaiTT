namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FunctionRoleRelationship")]
    public partial class FunctionRoleRelationship
    {
        public long ID { get; set; }

        public long? RoleID { get; set; }

        public long? FunctionID { get; set; }

        public virtual Function Function { get; set; }

        public virtual Role Role { get; set; }
    }
}
