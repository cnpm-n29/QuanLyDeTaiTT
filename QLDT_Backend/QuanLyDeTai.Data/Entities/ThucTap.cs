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
        public long ID { get; set; }

        public long? ID_HocKy { get; set; }

        public long? ID_LoaiTT { get; set; }
    }
}
