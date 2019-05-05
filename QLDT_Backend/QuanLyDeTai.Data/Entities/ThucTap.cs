namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucTap")]
    public partial class ThucTap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucTap()
        {
            DeTais = new HashSet<DeTai>();
        }

        public long ID { get; set; }

        public long? ID_HocKy { get; set; }

        public long? ID_LoaiTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTai> DeTais { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual LoaiTT LoaiTT { get; set; }
    }
}
