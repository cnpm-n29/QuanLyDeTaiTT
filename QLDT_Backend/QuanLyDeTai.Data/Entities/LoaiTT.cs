namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTT")]
    public partial class LoaiTT
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string TenThucTap { get; set; }
    }
}
