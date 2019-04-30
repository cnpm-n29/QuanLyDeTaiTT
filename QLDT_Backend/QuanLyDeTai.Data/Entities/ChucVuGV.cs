namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVuGV")]
    public partial class ChucVuGV
    {
        public long ID { get; set; }

        public long? ID_GV { get; set; }

        public long? ID_ChucVu { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual GiangVien GiangVien { get; set; }
    }
}
