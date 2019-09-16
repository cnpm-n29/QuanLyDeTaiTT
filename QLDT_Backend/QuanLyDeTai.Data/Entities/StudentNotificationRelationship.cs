namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentNotificationRelationship")]
    public partial class StudentNotificationRelationship
    {
        public long ID { get; set; }

        public long? StudentID { get; set; }

        public long? NotificationID { get; set; }

        public bool? Status { get; set; }

        public virtual Notification Notification { get; set; }

        public virtual Student Student { get; set; }
    }
}
