namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopicStudent")]
    public partial class TopicStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TopicStudent()
        {
            Scores = new HashSet<Score>();
        }

        public long ID { get; set; }

        public long? StudentPracticeID { get; set; }

        public long? TopicID { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }

        public int? Progress { get; set; }

        public bool? Result { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Scores { get; set; }

        public virtual StudentPracticeRelationship StudentPracticeRelationship { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
