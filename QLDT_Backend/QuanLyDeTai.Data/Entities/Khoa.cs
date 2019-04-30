namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        public long ID { get; set; }

        public long? ID_Nganh { get; set; }

        [StringLength(50)]
        public string TenKhoa { get; set; }
    }
}
