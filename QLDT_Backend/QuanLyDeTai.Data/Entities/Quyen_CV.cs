namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quyen_CV
    {
        public long ID { get; set; }

        public long? ID_ChucVu { get; set; }

        public long? ID_Quyen { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
