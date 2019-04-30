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
        public long ID { get; set; }

        public long? ID_SinhVien { get; set; }

        public long? ID_TT { get; set; }
    }
}
