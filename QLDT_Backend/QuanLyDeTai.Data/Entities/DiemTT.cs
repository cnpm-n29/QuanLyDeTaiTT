namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiemTT")]
    public partial class DiemTT
    {
        public long ID { get; set; }

        public long? ID_DeTaiSinhVienTT { get; set; }

        public long? ID_ThucTap { get; set; }

        public float? DiemCongTy { get; set; }

        public float? DiemGVHD { get; set; }

        public float? DiemBaoCao { get; set; }

        public float? DiemTong { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public virtual DeTaiSinhVienTT DeTaiSinhVienTT { get; set; }
    }
}
