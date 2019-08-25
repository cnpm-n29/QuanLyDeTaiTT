namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            TopicStudents = new HashSet<TopicStudent>();
        }

        public long ID { get; set; }

        public long? TeacherID { get; set; }

        public long? PracticeTypeID { get; set; }

        public long? FieldID { get; set; }

        [StringLength(500)]
        public string TopicName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? Status { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Field Field { get; set; }

        public virtual PracticeType PracticeType { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicStudent> TopicStudents { get; set; }
    }
}
