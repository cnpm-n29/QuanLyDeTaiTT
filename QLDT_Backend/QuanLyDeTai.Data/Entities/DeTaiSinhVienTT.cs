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
        public long ID { get; set; }

        public long? ID_SinhVien { get; set; }

        public long? ID_DeTai { get; set; }
    }
}
