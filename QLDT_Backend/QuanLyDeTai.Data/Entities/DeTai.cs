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
        public long ID { get; set; }

        public long? ID_GiangVien { get; set; }

        public long? ID_ThucTap { get; set; }

        [StringLength(500)]
        public string TenDeTai { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public bool TrangThai { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
