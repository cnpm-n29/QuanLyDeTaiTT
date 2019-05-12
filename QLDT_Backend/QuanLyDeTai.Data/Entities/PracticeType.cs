namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PracticeType")]
    public partial class PracticeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PracticeType()
        {
            Topics = new HashSet<Topic>();
        }

        public long ID { get; set; }

        public long? SemesterID { get; set; }

        public long? PracticeID { get; set; }

        public virtual Practice Practice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }

        public virtual Semester Semester { get; set; }
    }
}
