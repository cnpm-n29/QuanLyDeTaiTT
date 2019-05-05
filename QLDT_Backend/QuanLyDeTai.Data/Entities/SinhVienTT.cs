namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVienTT")]
    public partial class SinhVienTT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVienTT()
        {
            DeTaiSinhVienTTs = new HashSet<DeTaiSinhVienTT>();
        }

        public long ID { get; set; }

        public long? ID_SinhVien { get; set; }

        public long? ID_TT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTaiSinhVienTT> DeTaiSinhVienTTs { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
