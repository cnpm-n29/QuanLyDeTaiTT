namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeTai")]
    public partial class DeTai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeTai()
        {
            DeTaiSinhVienTTs = new HashSet<DeTaiSinhVienTT>();
        }

        public long ID { get; set; }

        public long? ID_GiangVien { get; set; }

        public long? ID_ThucTap { get; set; }

        [StringLength(500)]
        public string TenDeTai { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public bool? TrangThai { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual ThucTap ThucTap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTaiSinhVienTT> DeTaiSinhVienTTs { get; set; }
    }
}
