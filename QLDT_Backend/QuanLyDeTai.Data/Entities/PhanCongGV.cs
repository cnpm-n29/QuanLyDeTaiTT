namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCongGV")]
    public partial class PhanCongGV
    {
        public long ID { get; set; }

        public long? ID_SinhVien { get; set; }

        public long? ID_GiangVien { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
