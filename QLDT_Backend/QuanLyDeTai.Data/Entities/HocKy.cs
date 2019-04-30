namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocKy")]
    public partial class HocKy
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string TenHocKy { get; set; }
    }
}
