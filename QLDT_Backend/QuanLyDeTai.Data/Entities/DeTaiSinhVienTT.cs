namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeTaiSinhVienTT")]
    public partial class DeTaiSinhVienTT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeTaiSinhVienTT()
        {
            DiemTTs = new HashSet<DiemTT>();
        }

        public long ID { get; set; }

        public long? ID_SinhVienTT { get; set; }

        public long? ID_DeTai { get; set; }

        public int? DoUuTien { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual DeTai DeTai { get; set; }

        public virtual SinhVienTT SinhVienTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemTT> DiemTTs { get; set; }
    }
}
